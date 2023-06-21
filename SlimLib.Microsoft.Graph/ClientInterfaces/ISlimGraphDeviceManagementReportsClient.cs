using SlimLib.Auth.Azure;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SlimLib.Microsoft.Graph
{
    public interface ISlimGraphDeviceManagementReportsClient
    {
        Task<JsonElement> GetDeviceInstallStatusByAppAsync(IAzureTenant tenant, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<JsonElement> GetUserInstallStatusAggregateByAppAsync(IAzureTenant tenant, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
    }
}