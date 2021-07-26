using SlimLib.Auth.Azure;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SlimLib.Microsoft.Graph
{
    public interface ISlimGraphDirectoryRolesClient
    {
        Task<JsonElement> GetDirectoryRoleAsync(IAzureTenant tenant, Guid directoryRoleID, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);

        IAsyncEnumerable<JsonElement> GetDirectoryRolesAsync(IAzureTenant tenant, ListRequestOptions? options = default, CancellationToken cancellationToken = default);

        IAsyncEnumerable<JsonElement> GetMembersAsync(IAzureTenant tenant, Guid directoryRoleID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
    }
}