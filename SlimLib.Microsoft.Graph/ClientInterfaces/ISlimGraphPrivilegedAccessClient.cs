using SlimLib.Auth.Azure;
using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;

namespace SlimLib.Microsoft.Graph
{
    public interface ISlimGraphPrivilegedAccessClient
    {
        GraphOperation<JsonDocument?> GetResourceAsync(IAzureTenant tenant, Guid tenantID, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphArrayOperation<JsonDocument> GetRoleAssignmentsAsync(IAzureTenant tenant, Guid tenantID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);

        GraphOperation<JsonDocument?> CreateRoleAssignmentRequestAsync(IAzureTenant tenant, JsonObject data, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
    }
}