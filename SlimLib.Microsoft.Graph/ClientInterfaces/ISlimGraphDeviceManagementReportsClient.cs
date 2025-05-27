using SlimLib.Auth.Azure;
using System.Text.Json;
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
    }
}