using SlimLib.Auth.Azure;
using System;
using System.Text.Json;
using System.Threading;

namespace SlimLib.Microsoft.Graph
{
    public interface ISlimGraphServicePrincipalsClient : ISlimGraphDirectoryObjectsClient
    {
        GraphOperation<JsonDocument?> GetServicePrincipalAsync(IAzureTenant tenant, Guid servicePrincipalID, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphArrayOperation<JsonDocument> GetServicePrincipalsAsync(IAzureTenant tenant, ListRequestOptions? options = default, CancellationToken cancellationToken = default);

        GraphArrayOperation<JsonDocument> GetAppRoleAssignmentsAsync(IAzureTenant tenant, Guid servicePrincipalID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphArrayOperation<JsonDocument> GetAppRoleAssignedToAsync(IAzureTenant tenant, Guid servicePrincipalID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
    }
}