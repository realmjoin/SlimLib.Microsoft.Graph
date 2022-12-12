using SlimLib.Auth.Azure;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SlimLib.Microsoft.Graph
{
    public interface ISlimGraphDetectedAppsClient
    {
        Task<JsonElement> GetDetectedAppAsync(IAzureTenant tenant, string appID, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonElement> GetDetectedAppsAsync(IAzureTenant tenant, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonElement> GetManagedDevicesAsync(IAzureTenant tenant, string appID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
    }
}