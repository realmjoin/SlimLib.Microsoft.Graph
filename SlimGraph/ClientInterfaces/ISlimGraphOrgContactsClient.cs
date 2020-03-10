using SlimGraph.Auth;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SlimGraph
{
    public interface ISlimGraphOrgContactsClient
    {
        Task<JsonElement> GetOrgContactAsync(IAzureTenant tenant, Guid contactID, ScalarRequestOptions options = default, CancellationToken cancellationToken = default);

        IAsyncEnumerable<JsonElement> GetOrgContactsAsync(IAzureTenant tenant, ListRequestOptions options = default, CancellationToken cancellationToken = default);
    }
}