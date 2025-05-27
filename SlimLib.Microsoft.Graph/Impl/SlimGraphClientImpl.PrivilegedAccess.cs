using SlimLib.Auth.Azure;
using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;

namespace SlimLib.Microsoft.Graph
{
    partial class SlimGraphClientImpl
    {
        GraphOperation<JsonDocument?> ISlimGraphPrivilegedAccessClient.GetResourceAsync(IAzureTenant tenant, Guid tenantID, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"privilegedAccess/aadRoles/resources/{tenantID}");

            return new(this, tenant, HttpMethod.Get, link, options, static doc => doc);
        }

        GraphArrayOperation<JsonDocument> ISlimGraphPrivilegedAccessClient.GetRoleAssignmentsAsync(IAzureTenant tenant, Guid tenantID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"privilegedAccess/aadRoles/resources/{tenantID}/roleAssignments");

            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc => doc);
        }

        GraphOperation<JsonDocument?> ISlimGraphPrivilegedAccessClient.CreateRoleAssignmentRequestAsync(IAzureTenant tenant, JsonObject data, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, "privilegedAccess/aadRoles/roleAssignmentRequests");

            return new(this, tenant, HttpMethod.Post, link, options, JsonSerializer.SerializeToUtf8Bytes(data), static doc => doc);
        }
    }
}