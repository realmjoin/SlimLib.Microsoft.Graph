using SlimLib.Auth.Azure;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SlimLib.Microsoft.Graph
{
    public interface ISlimGraphPrivilegedAccessClient
    {
        Task<JsonElement> GetResourceAsync(IAzureTenant tenant, Guid tenantID, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonElement> GetRoleAssignmentsAsync(IAzureTenant tenant, Guid tenantID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);

        Task<JsonElement> CreateRoleAssignmentRequestAsync(IAzureTenant tenant, JsonElement data, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
    }
}