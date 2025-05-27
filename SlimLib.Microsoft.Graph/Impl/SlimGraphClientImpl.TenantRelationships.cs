using SlimLib.Auth.Azure;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;

namespace SlimLib.Microsoft.Graph
{
    partial class SlimGraphClientImpl
    {
        GraphArrayOperation<JsonDocument> ISlimGraphTenantRelationshipsClient.GetDelegatedAdminRelationshipsAsync(IAzureTenant tenant, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, "tenantRelationships/delegatedAdminRelationships");
            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc => doc);
        }
    }
}
