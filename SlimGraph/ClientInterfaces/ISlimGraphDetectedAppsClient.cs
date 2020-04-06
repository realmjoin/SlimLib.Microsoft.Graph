using SlimGraph.Auth;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SlimGraph
{
    public interface ISlimGraphDetectedAppsClient
    {
        Task<JsonElement> GetDetectedAppAsync(IAzureTenant tenant, string appID, ScalarRequestOptions options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonElement> GetDetectedAppsAsync(IAzureTenant tenant, ListRequestOptions options = default, CancellationToken cancellationToken = default);
    }
}