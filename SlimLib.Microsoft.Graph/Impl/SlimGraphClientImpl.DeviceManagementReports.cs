using SlimLib.Auth.Azure;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;

namespace SlimLib.Microsoft.Graph
{
    partial class SlimGraphClientImpl
    {
        async Task<JsonDocument?> ISlimGraphDeviceManagementReportsClient.GetDeviceInstallStatusByAppAsync(IAzureTenant tenant, ListRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = "deviceManagement/reports/microsoft.graph.retrieveDeviceAppInstallationStatusReport";

            var data = options?.ToJson() ?? new JsonObject();

            return await PostAsync(tenant, JsonSerializer.SerializeToUtf8Bytes(data), link, options, cancellationToken).ConfigureAwait(false);
        }

        async Task<JsonDocument?> ISlimGraphDeviceManagementReportsClient.GetUserInstallStatusAggregateByAppAsync(IAzureTenant tenant, ListRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = "deviceManagement/reports/getUserInstallStatusReport";

            var data = options?.ToJson() ?? new JsonObject();

            return await PostAsync(tenant, JsonSerializer.SerializeToUtf8Bytes(data), link, options, cancellationToken).ConfigureAwait(false);
        }
    }
}