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
        IAsyncEnumerable<Guid[]> ISlimGraphDirectoryObjectsClient.CheckMemberGroupsAsync(IAzureTenant tenant, Guid objectID, ICollection<Guid> groupIDs, InvokeRequestOptions? options, CancellationToken cancellationToken)
            => CheckMemberGroupsImplAsync(tenant, "directoryObjects", objectID.ToString(), groupIDs, options, cancellationToken);

        IAsyncEnumerable<Guid[]> ISlimGraphDirectoryObjectsClient.GetMemberGroupsAsync(IAzureTenant tenant, Guid objectID, bool securityEnabledOnly, InvokeRequestOptions? options, CancellationToken cancellationToken)
            => GetMemberGroupsImplAsync(tenant, "directoryObjects", objectID.ToString(), securityEnabledOnly, options, cancellationToken);

        IAsyncEnumerable<Guid[]> ISlimGraphDirectoryObjectsClient.CheckMemberObjectsAsync(IAzureTenant tenant, Guid objectID, ICollection<Guid> ids, InvokeRequestOptions? options, CancellationToken cancellationToken)
            => CheckMemberObjectsImplAsync(tenant, "directoryObjects", objectID.ToString(), ids, options, cancellationToken);

        IAsyncEnumerable<Guid[]> ISlimGraphDirectoryObjectsClient.GetMemberObjectsAsync(IAzureTenant tenant, Guid objectID, bool securityEnabledOnly, InvokeRequestOptions? options, CancellationToken cancellationToken)
            => GetMemberObjectsImplAsync(tenant, "directoryObjects", objectID.ToString(), securityEnabledOnly, options, cancellationToken);

        async IAsyncEnumerable<Guid[]> CheckMemberGroupsImplAsync(IAzureTenant tenant, string type, string id, ICollection<Guid> groupIDs, InvokeRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"{type}/{id}/checkMemberGroups");

            var data = new JsonObject
            {
                ["groupIds"] = new JsonArray(groupIDs.Select(x => JsonValue.Create(x)).ToArray())
            };

            await foreach (var doc in PostArrayAsync(tenant, JsonSerializer.SerializeToUtf8Bytes(data), nextLink, new RequestHeaderOptions(), cancellationToken))
            {
                using (doc)
                {
                    if (cancellationToken.IsCancellationRequested)
                        yield break;

                    yield return doc.RootElement
                        .GetProperty("value")
                        .EnumerateArray()
                        .Select(x => x.GetGuid())
                        .ToArray();
                }
            }
        }

        async IAsyncEnumerable<Guid[]> GetMemberGroupsImplAsync(IAzureTenant tenant, string type, string id, bool securityEnabledOnly, InvokeRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"{type}/{id}/getMemberGroups");

            var data = new JsonObject
            {
               { "securityEnabledOnly", securityEnabledOnly }
            };

            await foreach (var doc in PostArrayAsync(tenant, JsonSerializer.SerializeToUtf8Bytes(data), nextLink, new RequestHeaderOptions(), cancellationToken))
            {
                using (doc)
                {
                    if (cancellationToken.IsCancellationRequested)
                        yield break;

                    yield return doc.RootElement
                        .GetProperty("value")
                        .EnumerateArray()
                        .Select(x => x.GetGuid())
                        .ToArray();
                }
            }
        }

        async IAsyncEnumerable<Guid[]> CheckMemberObjectsImplAsync(IAzureTenant tenant, string type, string id, ICollection<Guid> ids, InvokeRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"{type}/{id}/checkMemberObjects");

            var data = new JsonObject
            {
                ["ids"] = new JsonArray(ids.Select(x => JsonValue.Create(x)).ToArray())
            };

            await foreach (var doc in PostArrayAsync(tenant, JsonSerializer.SerializeToUtf8Bytes(data), nextLink, new RequestHeaderOptions(), cancellationToken))
            {
                using (doc)
                {
                    if (cancellationToken.IsCancellationRequested)
                        yield break;

                    yield return doc.RootElement
                        .GetProperty("value")
                        .EnumerateArray()
                        .Select(x => x.GetGuid())
                        .ToArray();
                }
            }
        }

        async IAsyncEnumerable<Guid[]> GetMemberObjectsImplAsync(IAzureTenant tenant, string type, string id, bool securityEnabledOnly, InvokeRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"{type}/{id}/getMemberObjects");

            var data = new JsonObject
            {
               { "securityEnabledOnly", securityEnabledOnly }
            };

            await foreach (var doc in PostArrayAsync(tenant, JsonSerializer.SerializeToUtf8Bytes(data), nextLink, new RequestHeaderOptions(), cancellationToken))
            {
                using (doc)
                {
                    if (cancellationToken.IsCancellationRequested)
                        yield break;

                    yield return doc.RootElement
                        .GetProperty("value")
                        .EnumerateArray()
                        .Select(x => x.GetGuid())
                        .ToArray();
                }
            }
        }
    }
}