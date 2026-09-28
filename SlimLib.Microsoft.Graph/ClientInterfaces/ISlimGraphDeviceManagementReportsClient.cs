using SlimLib.Auth.Azure;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;

namespace SlimLib.Microsoft.Graph
{
    /// <summary>
    /// See reports at <see href="https://learn.microsoft.com/en-us/mem/intune/fundamentals/reports-export-graph-available-reports" />.
    /// </summary>
    public interface ISlimGraphDeviceManagementReportsClient
    {
        GraphOperation<JsonDocument?> GetDeviceInstallStatusByAppAsync(IAzureTenant tenant, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphOperation<JsonDocument?> GetUserInstallStatusAggregateByAppAsync(IAzureTenant tenant, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphOperation<JsonDocument?> GetDevicePoliciesComplianceReportAsync(IAzureTenant tenant, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphOperation<JsonDocument?> GetDevicePolicySettingsComplianceReportAsync(IAzureTenant tenant, ListRequestOptions? options = default, CancellationToken cancellationToken = default);

        /// <summary>
        /// Starts an export of any report, e.g. <c>{ "reportName": "AppInstallStatusAggregate", "format": "json" }</c>.
        /// Poll <see cref="GetExportJobAsync"/> with the returned <c>id</c> until <c>status</c> is <c>completed</c>, then download the zip from <c>url</c>.
        /// See <see href="https://learn.microsoft.com/en-us/intune/intune-service/fundamentals/reports-export-graph-apis" />.
        /// </summary>
        GraphOperation<JsonDocument?> CreateExportJobAsync(IAzureTenant tenant, JsonObject data, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphOperation<JsonDocument?> GetExportJobAsync(IAzureTenant tenant, string id, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
    }
}