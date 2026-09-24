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

            return new(this, tenant, HttpMethod.Post, link, options, BuildReportBody(options), static doc => doc);
        }

        GraphOperation<JsonDocument?> ISlimGraphDeviceManagementReportsClient.GetUserInstallStatusAggregateByAppAsync(IAzureTenant tenant, ListRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = "deviceManagement/reports/getUserInstallStatusReport";

            return new(this, tenant, HttpMethod.Post, link, options, BuildReportBody(options), static doc => doc);
        }

        GraphOperation<JsonDocument?> ISlimGraphDeviceManagementReportsClient.GetDevicePoliciesComplianceReportAsync(IAzureTenant tenant, ListRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = "deviceManagement/reports/getDevicePoliciesComplianceReport";

            return new(this, tenant, HttpMethod.Post, link, options, BuildReportBody(options), static doc => doc);
        }

        GraphOperation<JsonDocument?> ISlimGraphDeviceManagementReportsClient.GetDevicePolicySettingsComplianceReportAsync(IAzureTenant tenant, ListRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = "deviceManagement/reports/getDevicePolicySettingsComplianceReport";

            return new(this, tenant, HttpMethod.Post, link, options, BuildReportBody(options), static doc => doc);
        }

        private static byte[] BuildReportBody(ListRequestOptions? options)
        {
            var data = new JsonObject();

            if (options?.Select.Count > 0)
                data["select"] = JsonSerializer.SerializeToNode(options.Select);

            if (options?.Filter is not null)
                data["filter"] = options.Filter;

            if (options?.OrderBy.Count > 0)
                data["orderBy"] = JsonSerializer.SerializeToNode(options.OrderBy);

            if (options?.Skip is not null)
                data["skip"] = options.Skip;

            if (options?.Top is not null)
                data["top"] = options.Top;

            return JsonSerializer.SerializeToUtf8Bytes(data);
        }
    }
}