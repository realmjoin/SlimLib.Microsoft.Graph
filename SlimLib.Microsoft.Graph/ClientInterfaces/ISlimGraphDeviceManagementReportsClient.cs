using SlimLib.Auth.Azure;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SlimLib.Microsoft.Graph
{
    /// <summary>
    /// See reports at <see href="https://learn.microsoft.com/en-us/mem/intune/fundamentals/reports-export-graph-available-reports" />.
    /// </summary>
    public interface ISlimGraphDeviceManagementReportsClient
    {
        Task<JsonDocument?> GetDeviceInstallStatusByAppAsync(IAzureTenant tenant, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<JsonDocument?> GetUserInstallStatusAggregateByAppAsync(IAzureTenant tenant, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
    }
}