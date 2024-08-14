using SlimLib.Auth.Azure;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SlimLib.Microsoft.Graph
{
    partial class SlimGraphClientImpl
    {
        async Task<JsonDocument?> ISlimGraphSubscribedSkusClient.GetSubscribedSkuAsync(IAzureTenant tenant, Guid subscribedSkuID, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"subscribedSkus/{subscribedSkuID}");

            return await GetAsync(tenant, link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }

        IAsyncEnumerable<JsonDocument> ISlimGraphSubscribedSkusClient.GetSubscribedSkusAsync(IAzureTenant tenant, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, "subscribedSkus");

            return GetArrayAsync(tenant, nextLink, options, cancellationToken);
        }
    }
}