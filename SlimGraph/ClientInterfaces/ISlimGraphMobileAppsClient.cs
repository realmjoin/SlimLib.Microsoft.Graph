using SlimGraph.Auth;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SlimGraph
{
    public interface ISlimGraphMobileAppsClient
    {
        Task<JsonElement> GetMobileAppAsync(IAzureTenant tenant, Guid appID, ScalarRequestOptions options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonElement> GetMobileAppsAsync(IAzureTenant tenant, ListRequestOptions options = default, CancellationToken cancellationToken = default);
    }
}