using SlimLib.Auth.Azure;
using System.Text.Json;
using System.Threading;

namespace SlimLib.Microsoft.Graph
{
    public interface ISlimGraphDetectedAppsClient
    {
        GraphOperation<JsonDocument?> GetDetectedAppAsync(IAzureTenant tenant, string appID, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphArrayOperation<JsonDocument> GetDetectedAppsAsync(IAzureTenant tenant, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphArrayOperation<JsonDocument> GetManagedDevicesAsync(IAzureTenant tenant, string appID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
    }
}