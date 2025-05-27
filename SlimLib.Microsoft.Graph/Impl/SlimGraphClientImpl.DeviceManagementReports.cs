using SlimLib.Auth.Azure;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;

namespace SlimLib.Microsoft.Graph
{
    partial class SlimGraphClientImpl
    {
        GraphOperation<JsonDocument?> ISlimGraphDeviceManagementReportsClient.GetDeviceInstallStatusByAppAsync(IAzureTenant tenant, ListRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = "deviceManagement/reports/microsoft.graph.retrieveDeviceAppInstallationStatusReport";

            var data = new JsonObject();
            
            if (options?.Select is not null)
                data["select"] = JsonSerializer.SerializeToNode(options.Select);

            if (options?.Filter is not null)
                data["filter"] = JsonSerializer.SerializeToNode(options.Filter);

            return new(this, tenant, HttpMethod.Post, link, options, JsonSerializer.SerializeToUtf8Bytes(data), static doc => doc);
        }

        GraphOperation<JsonDocument?> ISlimGraphDeviceManagementReportsClient.GetUserInstallStatusAggregateByAppAsync(IAzureTenant tenant, ListRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = "deviceManagement/reports/getUserInstallStatusReport";

            var data = new JsonObject();
            
            if (options?.Select is not null)
                data["select"] = JsonSerializer.SerializeToNode(options.Select);

            if (options?.Filter is not null)
                data["filter"] = JsonSerializer.SerializeToNode(options.Filter);

            return new(this, tenant, HttpMethod.Post, link, options, JsonSerializer.SerializeToUtf8Bytes(data), static doc => doc);
        }
    }
}