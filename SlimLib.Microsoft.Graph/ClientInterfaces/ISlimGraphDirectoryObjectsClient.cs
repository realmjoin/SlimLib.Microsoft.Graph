using SlimLib.Auth.Azure;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SlimLib.Microsoft.Graph
{
    public interface ISlimGraphDirectoryObjectsClient
    {
        Task<JsonDocument?> GetObjectAsync(IAzureTenant tenant, Guid objectID, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);

        IAsyncEnumerable<JsonDocument> GetObjectsAsync(IAzureTenant tenant, string type, ListRequestOptions? options = default, CancellationToken cancellationToken = default);

        IAsyncEnumerable<Guid[]> CheckMemberGroupsAsync(IAzureTenant tenant, Guid objectID, ICollection<Guid> groupIDs, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<Guid[]> GetMemberGroupsAsync(IAzureTenant tenant, Guid objectID, bool securityEnabledOnly, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);

        IAsyncEnumerable<Guid[]> CheckMemberObjectsAsync(IAzureTenant tenant, Guid objectID, ICollection<Guid> ids, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<Guid[]> GetMemberObjectsAsync(IAzureTenant tenant, Guid objectID, bool securityEnabledOnly, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
    }
}