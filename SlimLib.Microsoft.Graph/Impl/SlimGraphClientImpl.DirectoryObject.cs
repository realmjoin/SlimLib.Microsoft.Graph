using SlimLib.Auth.Azure;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;

namespace SlimLib.Microsoft.Graph
{
    partial class SlimGraphClientImpl
    {
        async IAsyncEnumerable<Guid> ISlimGraphDirectoryObjectsClient.CheckMemberGroupsAsync(IAzureTenant tenant, Guid objectID, IEnumerable<Guid> groupIDs, InvokeRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"directoryObjects/{objectID}/checkMemberGroups");

            var buffer = new ArrayBufferWriter<byte>();
            using (var writer = new Utf8JsonWriter(buffer))
            {
                writer.WriteStartObject();
                writer.WritePropertyName("groupIds");

                writer.WriteStartArray();

                foreach (var groupID in groupIDs)
                {
                    writer.WriteStringValue(groupID);
                }

                writer.WriteEndArray();

                writer.WriteEndObject();
            }

            await foreach (var item in PostArrayAsync(tenant, buffer.WrittenMemory, nextLink, new RequestHeaderOptions(), cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item.GetGuid();
            }
        }
    }
}