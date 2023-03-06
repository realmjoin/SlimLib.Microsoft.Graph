using SlimLib.Auth.Azure;
using System;
using System.Collections.Generic;
using System.Threading;

namespace SlimLib.Microsoft.Graph
{
    public interface ISlimGraphDirectoryObjectsClient
    {
        IAsyncEnumerable<Guid> CheckMemberGroupsAsync(IAzureTenant tenant, Guid objectID, IEnumerable<Guid> groupIDs, InvokeRequestOptions? options, CancellationToken cancellationToken);
    }
}