using SlimLib.Auth.Azure;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SlimLib.Microsoft.Graph
{
    public interface ISlimGraphDetectedAppsClient
    {
        Task<JsonDocument?> GetDetectedAppAsync(IAzureTenant tenant, string appID, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonDocument> GetDetectedAppsAsync(IAzureTenant tenant, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonDocument> GetManagedDevicesAsync(IAzureTenant tenant, string appID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
    }
}