using SlimGraph.Auth;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SlimGraph
{
    public interface ISlimGraphServicePrincipalsClient
    {
        Task<JsonElement> GetServicePrincipalAsync(IAzureTenant tenant, Guid servicePrincipalID, ScalarRequestOptions options = default, CancellationToken cancellationToken = default);

        IAsyncEnumerable<JsonElement> GetServicePrincipalsAsync(IAzureTenant tenant, ListRequestOptions options = default, CancellationToken cancellationToken = default);
    }
}