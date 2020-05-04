using SlimGraph.Auth;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SlimGraph
{
    partial class SlimGraphClientImpl
    {
        async Task<JsonElement> ISlimGraphServicePrincipalsClient.GetServicePrincipalAsync(IAzureTenant tenant, Guid servicePrincipalID, ScalarRequestOptions options, CancellationToken cancellationToken)
        {
            var link = options.BuildLink($"servicePrincipals/{servicePrincipalID}");

            return await GetAsync(tenant, link, cancellationToken).ConfigureAwait(false);
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphServicePrincipalsClient.GetServicePrincipalsAsync(IAzureTenant tenant, ListRequestOptions options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = options.BuildLink("servicePrincipals");

            await foreach (var item in GetArrayAsync(tenant, nextLink, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item;
            }
        }
    }
}