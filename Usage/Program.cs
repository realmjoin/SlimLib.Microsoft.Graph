using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polly;
using SlimLib;
using SlimLib.Auth.Azure;
using SlimLib.Microsoft.Graph;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Usage
{
    public class Program
    {
        private static readonly JsonSerializerOptions GraphJsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

        public static IConfigurationRoot? Configuration { get; private set; }

        public static async Task Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            builder.AddUserSecrets<Program>();

            Configuration = builder.Build();

            var services = new ServiceCollection();

            services.AddLogging(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddFilter("SlimGraph", LogLevel.Trace)
                    .AddConsole();
            });

            var clientCredentials = new AzureClientCredentials();
            Configuration.GetSection("AzureAD").Bind(clientCredentials);

            services.AddHttpClient();
            services.AddMemoryCache();
            services.AddSingleton<IAuthenticationProvider>(sp => new CachingAzureAuthenticationClient(clientCredentials, sp.GetRequiredService<IHttpClientFactory>().CreateClient(nameof(CachingAzureAuthenticationClient)), sp.GetRequiredService<IMemoryCache>()));
            services.AddHttpClient<ISlimGraphClient, SlimGraphClient>(client => client.BaseAddress = new Uri(SlimGraphConstants.EndpointBeta)).AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(500)));

            using var container = services.BuildServiceProvider();
            using var serviceScope = container.CreateScope();

            var tenant = new AzureTenant(Configuration.GetValue<string>("Tenant")!);

            var client = serviceScope.ServiceProvider.GetRequiredService<ISlimGraphClient>();
            var logger = serviceScope.ServiceProvider.GetRequiredService<ILogger<Program>>();

            // Basic usage

            var groupId = Guid.Empty;

            var options = new ListRequestOptions
            {
                Select = { "id", "displayName", "description", "createdDateTime" },
                Top = 10
            };

            // Raw call using the updated API based on JsonDocument. Don't forget to dispose the JsonDocument when done!
            {
                await foreach (var page in client.Groups.GetGroupsAsync(tenant, options))
                {
                    using (page)
                    {
                        if (page.RootElement.GetProperty("value").Deserialize<Group[]>(GraphJsonOptions) is { } items)
                        {
                            foreach (var item in items)
                            {
                                if (groupId == default) groupId = item.Id;

                                Console.WriteLine(item.DisplayName);
                            }
                        }
                    }

                    // Only get the first page of results.
                    break;
                }
            }


            // Using the new Deserialize<T>() extension method to simplify the code.
            // This method will automatically set JsonNamingPolicy.CamelCase for you.
            {
                await foreach (var items in client.Groups.GetGroupsAsync(tenant, options).Deserialize<Group>())
                {
                    foreach (var item in items)
                    {
                        Console.WriteLine(item.DisplayName);
                    }

                    // Only get the first page of results.
                    break;
                }
            }


            var i = 0;

            // Using the new AsJsonElement() extension method to migrate the old API.
            {
                await foreach (var item in client.Groups.GetGroupsAsync(tenant, options).AsJsonElements())
                {
                    Console.WriteLine(item.GetProperty("displayName").GetString());

                    // Only get the first 10 elements (usually 1 page of results).
                    if (++i >= 10) break;
                }
            }


            // The same works with single items.
            {
                using var page = await client.Groups.GetGroupAsync(tenant, groupId);
                Console.WriteLine(page?.RootElement.GetProperty("displayName").GetString());
            }

            {
                var group = await client.Groups.GetGroupAsync(tenant, groupId).Deserialize<Group>();
                Console.WriteLine(group?.DisplayName);
            }

            {
                var json = await client.Groups.GetGroupAsync(tenant, groupId).AsJsonElement();
                Console.WriteLine(json.GetProperty("displayName").GetString());
            }


            // Example how to use new Intune app reporting
            // See for more: https://techcommunity.microsoft.com/t5/intune-customer-success/support-tip-retrieving-intune-apps-reporting-data-from-microsoft/ba-p/3851578

            var appID = new Guid("f38e72d5-b55d-45cd-8496-5224215f031c");

            // In this example we parse the raw response (which is reminiscent of CSV) using Report.ReportResult
            // which results in list of rows, with each row containing a list of values as raw JsonElement.

            var raw = await client.DeviceManagementReports.GetUserInstallStatusAggregateByAppAsync(tenant, new() { Filter = $"(ApplicationId eq '{appID}')" });

            if (raw is not null)
            {
                var report = SlimLib.Microsoft.Graph.Results.Report.ReportResult.Create(raw);

                foreach (var row in report.Values!)
                {
                    foreach (var item in row)
                    {
                        Console.WriteLine(item);
                    }
                }
            }

            /*
Output similar to:
7d46f4b4-2e5d-44ff-8f40-bc977fd0b994
f38e72d5-b55d-45cd-8496-5224215f031c
John Doe
john.doe@contoso.com
1
0
0
0
0
             */

            // This examples uses ToDynamicResult() to create dynamic objects from each list of JsonElements.
            // It also uses the new SelectList feature to only return the columns we need.
            // Note that for this report, when you request AppInstallState, you also get AppInstallState_loc which is the localized version of the state.
            // You can not request AppInstallState_loc directly, it will fail with an UnknownError.

            raw = await client.DeviceManagementReports.GetDeviceInstallStatusByAppAsync(tenant, new() { Select = { "DeviceName", "AppInstallState" }, OrderBy = { "DeviceName asc" }, Filter = $"(ApplicationId eq '{appID}')" });

            if (raw is not null)
            {
                var report = SlimLib.Microsoft.Graph.Results.Report.ReportResult.Create(raw);

                foreach (var item in report.ToDynamicResult())
                {
                    Console.WriteLine($"{item.DeviceName,-30} {item.AppInstallState_loc}");
                }
            }

            /*
Output similar to:
DESKTOP-ABCDEF1                Failed
DESKTOP-ZXY                    Installed
             */
        }
    }
}
