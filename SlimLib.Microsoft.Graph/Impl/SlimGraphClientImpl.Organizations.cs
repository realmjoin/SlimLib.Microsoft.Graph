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
        async Task<JsonDocument?> ISlimGraphOrganizationsClient.GetOrganizationAsync(IAzureTenant tenant, Guid organizationID, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"organization/{organizationID}");

            return await GetAsync(tenant, link, new RequestHeaderOptions(), null, cancellationToken).ConfigureAwait(false);
        }

        IAsyncEnumerable<JsonDocument> ISlimGraphOrganizationsClient.GetOrganizationsAsync(IAzureTenant tenant, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, "organization");

            return GetArrayAsync(tenant, nextLink, options, cancellationToken);
        }
    }
}