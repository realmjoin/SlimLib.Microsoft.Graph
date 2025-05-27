using SlimLib.Auth.Azure;
using System;
using System.Text.Json;
using System.Threading;

namespace SlimLib.Microsoft.Graph
{
    public interface ISlimGraphDirectoryRolesClient
    {
        GraphOperation<JsonDocument?> GetDirectoryRoleAsync(IAzureTenant tenant, Guid directoryRoleID, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);

        GraphArrayOperation<JsonDocument> GetDirectoryRolesAsync(IAzureTenant tenant, ListRequestOptions? options = default, CancellationToken cancellationToken = default);

        GraphArrayOperation<JsonDocument> GetMembersAsync(IAzureTenant tenant, Guid directoryRoleID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
    }
}