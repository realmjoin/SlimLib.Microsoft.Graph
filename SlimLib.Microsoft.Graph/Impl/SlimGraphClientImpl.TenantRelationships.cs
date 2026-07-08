using SlimLib.Auth.Azure;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;

namespace SlimLib.Microsoft.Graph
{
    partial class SlimGraphClientImpl
    {
        GraphArrayOperation<JsonDocument> ISlimGraphTenantRelationshipsClient.GetDelegatedAdminRelationshipsAsync(IAzureTenant tenant, ListRequestOptions? options, CancellationToken cancellationToken)
        {
            var nextLink = ODataLinkBuilder.BuildLink(options, "tenantRelationships/delegatedAdminRelationships");
            return new(this, tenant, HttpMethod.Get, nextLink, options, default, static doc => doc);
        }
    }
}
