using SlimLib.Auth.Azure;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SlimLib.Microsoft.Graph
{
    public interface ISlimGraphServicePrincipalsClient : ISlimGraphDirectoryObjectsClient
    {
        Task<JsonDocument?> GetServicePrincipalAsync(IAzureTenant tenant, Guid servicePrincipalID, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonDocument> GetServicePrincipalsAsync(IAzureTenant tenant, ListRequestOptions? options = default, CancellationToken cancellationToken = default);

        IAsyncEnumerable<JsonDocument> GetAppRoleAssignmentsAsync(IAzureTenant tenant, Guid servicePrincipalID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonDocument> GetAppRoleAssignedToAsync(IAzureTenant tenant, Guid servicePrincipalID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
    }
}