using SlimLib.Auth.Azure;
using System;
using System.Collections.Generic;
using System.Threading;

namespace SlimLib.Microsoft.Graph
{
    public interface ISlimGraphDirectoryObjectsClient
    {
        IAsyncEnumerable<Guid> CheckMemberGroupsAsync(IAzureTenant tenant, Guid objectID, ICollection<Guid> groupIDs, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<Guid> GetMemberGroupsAsync(IAzureTenant tenant, Guid objectID, bool securityEnabledOnly, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);

        IAsyncEnumerable<Guid> CheckMemberObjectsAsync(IAzureTenant tenant, Guid objectID, ICollection<Guid> ids, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<Guid> GetMemberObjectsAsync(IAzureTenant tenant, Guid objectID, bool securityEnabledOnly, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
    }
}