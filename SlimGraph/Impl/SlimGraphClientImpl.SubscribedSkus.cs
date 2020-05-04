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
        async Task<JsonElement> ISlimGraphSubscribedSkusClient.GetSubscribedSkuAsync(IAzureTenant tenant, Guid subscribedSkuID, ScalarRequestOptions options, CancellationToken cancellationToken)
        {
            var link = options.BuildLink($"subscribedSkus/{subscribedSkuID}");

            return await GetAsync(tenant, link, cancellationToken).ConfigureAwait(false);
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphSubscribedSkusClient.GetSubscribedSkusAsync(IAzureTenant tenant, ListRequestOptions options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = options.BuildLink("subscribedSkus");

            await foreach (var item in GetArrayAsync(tenant, nextLink, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item;
            }
        }
    }
}