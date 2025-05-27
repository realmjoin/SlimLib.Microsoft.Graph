using SlimLib.Auth.Azure;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;

namespace SlimLib.Microsoft.Graph
{
    public interface ISlimGraphDirectoryObjectsClient
    {
        GraphOperation<JsonDocument?> GetObjectAsync(IAzureTenant tenant, Guid objectID, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);

        GraphArrayOperation<JsonDocument> GetObjectsAsync(IAzureTenant tenant, string type, ListRequestOptions? options = default, CancellationToken cancellationToken = default);

        GraphArrayOperation<Guid[]> CheckMemberGroupsAsync(IAzureTenant tenant, Guid objectID, ICollection<Guid> groupIDs, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphArrayOperation<Guid[]> GetMemberGroupsAsync(IAzureTenant tenant, Guid objectID, bool securityEnabledOnly, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);

        GraphArrayOperation<Guid[]> CheckMemberObjectsAsync(IAzureTenant tenant, Guid objectID, ICollection<Guid> ids, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphArrayOperation<Guid[]> GetMemberObjectsAsync(IAzureTenant tenant, Guid objectID, bool securityEnabledOnly, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
    }
}