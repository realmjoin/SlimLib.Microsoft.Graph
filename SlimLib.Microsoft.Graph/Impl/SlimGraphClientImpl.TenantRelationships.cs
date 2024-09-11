using SlimLib.Auth.Azure;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;

namespace SlimLib.Microsoft.Graph
{
    partial class SlimGraphClientImpl
    {
        IAsyncEnumerable<JsonDocument> ISlimGraphTenantRelationshipsClient.GetDelegatedAdminRelationshipsAsync(IAzureTenant tenant, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, "tenantRelationships/delegatedAdminRelationships");
            return GetArrayAsync(tenant, nextLink, options, cancellationToken);
        }
    }
}
