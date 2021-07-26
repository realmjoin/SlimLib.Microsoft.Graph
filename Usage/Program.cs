using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polly;
using SlimLib.Auth.Azure;
using SlimLib.Microsoft.Graph;
using System;
using System.Net.Http;
using System.Threading;
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

            var tenant = new AzureTenant(Configuration.GetValue<string>("Tenant"));
            var clientCredentials = new AzureClientCredentials();
            Configuration.GetSection("AzureAD").Bind(clientCredentials);

            services.AddMemoryCache();
            services.AddTransient<IAuthenticationProvider>(sp => new AzureAuthenticationClient(clientCredentials, sp.GetRequiredService<IHttpClientFactory>().CreateClient(nameof(AzureAuthenticationClient)), sp.GetService<IMemoryCache>()));
            services.AddHttpClient<ISlimGraphClient, SlimGraphClient>(client => client.BaseAddress = new Uri(SlimGraphConstants.EndpointBeta)).AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(500)));

            var container = services.BuildServiceProvider();

            using (var scope = container.CreateScope())
            {
                var client = scope.ServiceProvider.GetRequiredService<ISlimGraphClient>();
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

                var count = 0;
                await foreach (var item in client.Users.GetUsersAsync(tenant, new ListRequestOptions { Top = 10, OrderBy = "displayName desc" }))
                {
                    // Since $top = 10 is set, each page will have at most 10 items. This means GetUsersAsync will execute two HTTP calls.
                    logger.LogInformation("Got {fn} item: {id}", nameof(client.Users.GetUsersAsync), item.GetProperty("id").GetGuid());
                    if (++count >= 20) break;
                }

                count = 0;
                await foreach (var item in client.Groups.GetGroupsAsync(tenant, new ListRequestOptions { Top = 20 }))
                {
                    logger.LogInformation("Got {fn} item: {id}", nameof(client.Groups.GetGroupsAsync), item.GetProperty("id").GetGuid());
                    if (++count >= 20) break;
                }

                var cts = new CancellationTokenSource();
                Console.CancelKeyPress += (sender, e) =>
                {
                    logger.LogInformation("Aborting...");
                    e.Cancel = true;
                    cts.Cancel();
                };

                try
                {
                    var deltaInitial = await client.Users.GetUsersDeltaAsync(tenant, new DeltaRequestOptions { PreferMinimal = true }, cancellationToken: cts.Token);
                    var deltaLink = deltaInitial.DeltaLink;

                    logger.LogInformation("Got users initial state: {n} items", deltaInitial.Items.Count);

                    while (!string.IsNullOrEmpty(deltaLink) && !cts.IsCancellationRequested)
                    {
                        Console.ReadLine();

                        var deltaChanges = await client.Users.GetUsersDeltaChangeAsync(tenant, deltaLink, new DeltaRequestOptions { PreferMinimal = true }, cancellationToken: cts.Token);
                        logger.LogInformation("Got users changes: {n} items", deltaChanges.Items.Count);

                        foreach (var item in deltaChanges.Items)
                        {
                            if (cts.IsCancellationRequested) return;
                            logger.LogInformation("Got user change: {item}", item.GetRawText());
                        }

                        deltaLink = deltaChanges.DeltaLink;
                    }
                }
                catch (OperationCanceledException)
                {
                }
            }
        }
    }
}
