using SlimLib.Auth.Azure;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;

namespace SlimLib.Microsoft.Graph
{
    partial class SlimGraphClientImpl
    {
        async Task<JsonDocument?> ISlimGraphPrivilegedAccessClient.GetResourceAsync(IAzureTenant tenant, Guid tenantID, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"privilegedAccess/aadRoles/resources/{tenantID}");

            return await GetAsync(tenant, link, new RequestHeaderOptions(), null, cancellationToken).ConfigureAwait(false);
        }

        IAsyncEnumerable<JsonDocument> ISlimGraphPrivilegedAccessClient.GetRoleAssignmentsAsync(IAzureTenant tenant, Guid tenantID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"privilegedAccess/aadRoles/resources/{tenantID}/roleAssignments");

            return GetArrayAsync(tenant, nextLink, options, cancellationToken);
        }

        async Task<JsonDocument?> ISlimGraphPrivilegedAccessClient.CreateRoleAssignmentRequestAsync(IAzureTenant tenant, JsonObject data, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, "privilegedAccess/aadRoles/roleAssignmentRequests");

            return await PostAsync(tenant, JsonSerializer.SerializeToUtf8Bytes(data), link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }
    }
}