using SlimLib.Auth.Azure;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;

namespace SlimLib.Microsoft.Graph
{
    public interface ISlimGraphPrivilegedAccessClient
    {
        Task<JsonDocument?> GetResourceAsync(IAzureTenant tenant, Guid tenantID, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonDocument> GetRoleAssignmentsAsync(IAzureTenant tenant, Guid tenantID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);

        Task<JsonDocument?> CreateRoleAssignmentRequestAsync(IAzureTenant tenant, JsonObject data, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
    }
}