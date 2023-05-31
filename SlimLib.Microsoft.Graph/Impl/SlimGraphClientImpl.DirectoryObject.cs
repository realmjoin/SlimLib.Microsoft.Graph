using SlimLib.Auth.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;

namespace SlimLib.Microsoft.Graph
{
    partial class SlimGraphClientImpl
    {
        async IAsyncEnumerable<Guid> ISlimGraphDirectoryObjectsClient.CheckMemberGroupsAsync(IAzureTenant tenant, Guid objectID, ICollection<Guid> groupIDs, InvokeRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"directoryObjects/{objectID}/checkMemberGroups");

            var data = new JsonObject
            {
                ["groupIds"] = new JsonArray(groupIDs.Select(x => JsonValue.Create(x)).ToArray())
            };

            await foreach (var item in PostArrayAsync(tenant, JsonSerializer.SerializeToUtf8Bytes(data), nextLink, new RequestHeaderOptions(), cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item.GetGuid();
            }
        }
    }
}