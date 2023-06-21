using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polly;
using SlimLib.Auth.Azure;
using SlimLib.Microsoft.Graph;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Usage
{
    public class Program
    {
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
            services.AddSingleton<IAuthenticationProvider>(sp => new AzureAuthenticationClient(clientCredentials, sp.GetRequiredService<IHttpClientFactory>().CreateClient(nameof(AzureAuthenticationClient)), sp.GetService<IMemoryCache>()));
            services.AddHttpClient<ISlimGraphClient, SlimGraphClient>(client => client.BaseAddress = new Uri(SlimGraphConstants.EndpointBeta)).AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(500)));

            using var container = services.BuildServiceProvider();
            using var serviceScope = container.CreateScope();

            var tenant = new AzureTenant(Configuration.GetValue<string>("Tenant"));

            var client = serviceScope.ServiceProvider.GetRequiredService<ISlimGraphClient>();
            var logger = serviceScope.ServiceProvider.GetRequiredService<ILogger<Program>>();

            var appID = new Guid("f38e72d5-b55d-45cd-8496-5224215f031c");

            var raw = await client.DeviceManagementReports.GetUserInstallStatusAggregateByAppAsync(tenant, new() { Filter = $"(ApplicationId eq '{appID}')" });
            var report = SlimLib.Microsoft.Graph.Results.Report.ReportResult.Create(raw);

            foreach (var row in report.Values!)
            {
                foreach (var item in row)
                {
                    Console.WriteLine(item);
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

            raw = await client.DeviceManagementReports.GetDeviceInstallStatusByAppAsync(tenant, new() { Filter = $"(ApplicationId eq '{appID}')" });
            report = SlimLib.Microsoft.Graph.Results.Report.ReportResult.Create(raw);

            foreach (var item in report.ToDynamicResult())
            {
                Console.WriteLine($"{item.DeviceName,-30} {item.AppInstallState_loc}");
            }

            /*
Output similar to:
DESKTOP-ABCDEF1                Failed
DESKTOP-ZXY                    Installed
             */
        }
    }
}
