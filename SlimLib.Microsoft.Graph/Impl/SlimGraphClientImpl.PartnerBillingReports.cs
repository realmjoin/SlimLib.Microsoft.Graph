using SlimLib.Auth.Azure;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;

namespace SlimLib.Microsoft.Graph
{
    partial class SlimGraphClientImpl
    {
        private const int ZERO_NUMBER_OF_SECONDS = 0;
        async Task<string?> ISlimGraphPartnerBillingReportsClient.ExportBilledReconciliationAsync(IAzureTenant tenant, JsonObject data, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, "reports/partners/billing/reconciliation/billed/export");
            string? location = null;


            await PostAsync(tenant, JsonSerializer.SerializeToUtf8Bytes(data), link, new RequestHeaderOptions(), response =>
            {
                if (response.StatusCode == HttpStatusCode.Accepted && response.Headers.TryGetValues("location", out var locationHeaders))
                {
                    location = locationHeaders.Single();
                }
                return Task.CompletedTask;
            }, cancellationToken);

            return location;
        }

        Task<JsonDocument?> ISlimGraphPartnerBillingReportsClient.GetOperationAsync(IAzureTenant tenant, string operationID, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"reports/partners/billing/operations/{operationID}");

            var maxRetry = RequestRetryOptions.DefaultMaxRetries;
            Func<(int SendAttempt, HttpResponseMessage Response), Task<(bool shouldRetry, int numberOfSecondsToWaitBeforeRetry)>> retryFunction = async ((int SendAttempt, HttpResponseMessage Response) input) =>
            {
                if (input.SendAttempt == maxRetry)
                {
                    return (false, ZERO_NUMBER_OF_SECONDS);
                }
                if (input.Response.StatusCode == HttpStatusCode.OK && input.Response.Headers.TryGetValues("Retry-After", out var retryAfterValue))
                {
                    using var content = await input.Response.Content.ReadAsStreamAsync().ConfigureAwait(false);
                    var doc = await JsonSerializer.DeserializeAsync<JsonDocument>(content, cancellationToken: cancellationToken);
                    var status = doc?.RootElement.GetProperty("status").GetString();
                    if (status == "running" || status == "notStarted")
                    {
                        return (true, int.Parse(retryAfterValue.Single()));
                    }
                }

                return (false, ZERO_NUMBER_OF_SECONDS);
            };

            var retryOptions = new RequestRetryOptions(retryFunction);

            return GetAsync(tenant, link, new RequestHeaderOptions(), retryOptions, cancellationToken);
        }
    }
}
