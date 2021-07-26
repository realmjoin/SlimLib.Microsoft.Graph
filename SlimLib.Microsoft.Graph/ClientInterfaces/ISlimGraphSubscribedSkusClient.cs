using SlimLib.Auth.Azure;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SlimLib.Microsoft.Graph
{
    public interface ISlimGraphSubscribedSkusClient
    {
        Task<JsonElement> GetSubscribedSkuAsync(IAzureTenant tenant, Guid subscribedSkuID, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);

        IAsyncEnumerable<JsonElement> GetSubscribedSkusAsync(IAzureTenant tenant, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
    }
}