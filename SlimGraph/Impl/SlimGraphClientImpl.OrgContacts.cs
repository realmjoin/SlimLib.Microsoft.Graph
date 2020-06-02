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
        async Task<JsonElement> ISlimGraphOrgContactsClient.GetOrgContactAsync(IAzureTenant tenant, Guid orgContactID, ScalarRequestOptions options, CancellationToken cancellationToken)
        {
            var link = options.BuildLink($"contacts/{orgContactID}");

            return await GetAsync(tenant, link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphOrgContactsClient.GetOrgContactsAsync(IAzureTenant tenant, ListRequestOptions options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = options.BuildLink("contacts");

            await foreach (var item in GetArrayAsync(tenant, nextLink, new RequestHeaderOptions { ConsistencyLevelEventual = options.ConsistencyLevelEventual }, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item;
            }
        }
    }
}