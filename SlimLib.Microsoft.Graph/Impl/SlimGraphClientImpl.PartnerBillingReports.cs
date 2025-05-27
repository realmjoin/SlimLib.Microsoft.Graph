using SlimLib.Auth.Azure;
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


            await SendAsync(tenant, HttpMethod.Post, link, JsonSerializer.SerializeToUtf8Bytes(data), options, response =>
            {
                if (response.StatusCode == HttpStatusCode.Accepted && response.Headers.TryGetValues("location", out var locationHeaders))
                {
                    location = locationHeaders.Single();
                }
                return Task.CompletedTask;
            }, cancellationToken);

            return location;
        }

        GraphOperation<JsonDocument?> ISlimGraphPartnerBillingReportsClient.GetOperationAsync(IAzureTenant tenant, string operationID, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"reports/partners/billing/operations/{operationID}");
            return new(this, tenant, HttpMethod.Get, link, options, static doc => doc);
        }
    }
}
