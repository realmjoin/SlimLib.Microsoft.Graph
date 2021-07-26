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
        async Task<JsonElement> ISlimGraphPrivilegedAccessClient.GetResourceAsync(IAzureTenant tenant, Guid tenantID, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"privilegedAccess/aadRoles/resources/{tenantID}");

            return await GetAsync(tenant, link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphPrivilegedAccessClient.GetRoleAssignmentsAsync(IAzureTenant tenant, Guid tenantID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"privilegedAccess/aadRoles/resources/{tenantID}/roleAssignments");

            await foreach (var item in GetArrayAsync(tenant, nextLink, options, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item;
            }
        }

        async Task<JsonElement> ISlimGraphPrivilegedAccessClient.CreateRoleAssignmentRequestAsync(IAzureTenant tenant, JsonElement data, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, "privilegedAccess/aadRoles/roleAssignmentRequests");

            return await PostAsync(tenant, JsonSerializer.SerializeToUtf8Bytes(data), link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }
    }
}