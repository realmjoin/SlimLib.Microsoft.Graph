using SlimLib.Auth.Azure;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SlimLib.Microsoft.Graph
{
    partial class SlimGraphClientImpl
    {
        async Task<JsonElement> ISlimGraphGroupsClient.CreateGroupAsync(IAzureTenant tenant, JsonElement data, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, "groups");

            return await PostAsync(tenant, JsonSerializer.SerializeToUtf8Bytes(data), link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }

        async Task<JsonElement> ISlimGraphGroupsClient.GetGroupAsync(IAzureTenant tenant, Guid groupID, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"groups/{groupID}");

            return await GetAsync(tenant, link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }

        async Task ISlimGraphGroupsClient.DeleteGroupAsync(IAzureTenant tenant, Guid groupID, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"groups/{groupID}");

            await DeleteAsync(tenant, link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }

        async Task<JsonElement> ISlimGraphGroupsClient.GetGroupPhotoAsync(IAzureTenant tenant, Guid groupID, string size, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            string link;

            if (string.IsNullOrEmpty(size))
                link = BuildLink(options, $"groups/{groupID}/photo");
            else
                link = BuildLink(options, $"groups/{groupID}/photos/{size}");

            return await GetAsync(tenant, link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }

        async Task<SlimGraphPicture?> ISlimGraphGroupsClient.GetGroupPhotoDataAsync(IAzureTenant tenant, Guid groupID, string size, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            string link;

            if (string.IsNullOrEmpty(size))
                link = BuildLink(options, $"groups/{groupID}/photo/$value");
            else
                link = BuildLink(options, $"groups/{groupID}/photos/{size}/$value");

            return await GetPictureAsync(tenant, link, cancellationToken).ConfigureAwait(false);
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphGroupsClient.GetGroupPhotosAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"groups/{groupID}/photos");

            await foreach (var item in GetArrayAsync(tenant, nextLink, options, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item;
            }
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphGroupsClient.GetGroupsAsync(IAzureTenant tenant, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, "groups");

            await foreach (var item in GetArrayAsync(tenant, nextLink, options, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item;
            }
        }

        Task<DeltaResult<JsonElement>> ISlimGraphGroupsClient.GetGroupsDeltaAsync(IAzureTenant tenant, DeltaRequestOptions? options, CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, "groups/delta");

            return GetDeltaAsync(tenant, nextLink, options, cancellationToken);
        }

        Task<DeltaResult<JsonElement>> ISlimGraphGroupsClient.GetGroupsDeltaChangeAsync(IAzureTenant tenant, string previousDeltaLink, DeltaRequestOptions? options, CancellationToken cancellationToken)
        {
            return GetDeltaAsync(tenant, previousDeltaLink, options, cancellationToken);
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphGroupsClient.GetOwnersAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"groups/{groupID}/owners");

            await foreach (var item in GetArrayAsync(tenant, nextLink, options, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item;
            }
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphGroupsClient.GetOwnersAsync(IAzureTenant tenant, Guid groupID, string type, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"groups/{groupID}/owners/{type}");

            await foreach (var item in GetArrayAsync(tenant, nextLink, options, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item;
            }
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphGroupsClient.GetMembersAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"groups/{groupID}/members");

            await foreach (var item in GetArrayAsync(tenant, nextLink, options, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item;
            }
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphGroupsClient.GetMembersAsync(IAzureTenant tenant, Guid groupID, string type, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"groups/{groupID}/members/{type}");

            await foreach (var item in GetArrayAsync(tenant, nextLink, options, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item;
            }
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphGroupsClient.GetTransitiveMembersAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"groups/{groupID}/transitiveMembers");

            await foreach (var item in GetArrayAsync(tenant, nextLink, options, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item;
            }
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphGroupsClient.GetTransitiveMembersAsync(IAzureTenant tenant, Guid groupID, string type, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"groups/{groupID}/transitiveMembers/{type}");

            await foreach (var item in GetArrayAsync(tenant, nextLink, options, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item;
            }
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphGroupsClient.GetMemberOfAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"groups/{groupID}/memberOf");

            await foreach (var item in GetArrayAsync(tenant, nextLink, options, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item;
            }
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphGroupsClient.GetTransitiveMemberOfAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"groups/{groupID}/transitiveMemberOf");

            await foreach (var item in GetArrayAsync(tenant, nextLink, options, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item;
            }
        }

        async IAsyncEnumerable<Guid> ISlimGraphGroupsClient.GetMemberGroupsAsync(IAzureTenant tenant, Guid groupID, bool securityEnabledOnly, InvokeRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"groups/{groupID}/getMemberGroups");

            var buffer = new ArrayBufferWriter<byte>();
            using (var writer = new Utf8JsonWriter(buffer))
            {
                writer.WriteStartObject();
                writer.WriteBoolean("securityEnabledOnly", securityEnabledOnly);
                writer.WriteEndObject();
            }

            await foreach (var item in PostArrayAsync(tenant, buffer.WrittenMemory, nextLink, new RequestHeaderOptions(), cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item.GetGuid();
            }
        }

        async IAsyncEnumerable<Guid> ISlimGraphGroupsClient.GetMemberObjectsAsync(IAzureTenant tenant, Guid groupID, bool securityEnabledOnly, InvokeRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"groups/{groupID}/getMemberObjects");

            var buffer = new ArrayBufferWriter<byte>();
            using (var writer = new Utf8JsonWriter(buffer))
            {
                writer.WriteStartObject();
                writer.WriteBoolean("securityEnabledOnly", securityEnabledOnly);
                writer.WriteEndObject();
            }

            await foreach (var item in PostArrayAsync(tenant, buffer.WrittenMemory, nextLink, new RequestHeaderOptions(), cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item.GetGuid();
            }
        }

        async Task ISlimGraphGroupsClient.AddMemberAsync(IAzureTenant tenant, Guid groupID, Guid memberID, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"groups/{groupID}/members/$ref");

            var buffer = new ArrayBufferWriter<byte>();
            using (var writer = new Utf8JsonWriter(buffer))
            {
                writer.WriteStartObject();
                writer.WriteString("@odata.id", httpClient.BaseAddress + "directoryObjects/" + memberID);
                writer.WriteEndObject();
            }

            await PostAsync(tenant, buffer.WrittenMemory, link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }

        async Task ISlimGraphGroupsClient.AddMembersAsync(IAzureTenant tenant, Guid groupID, IEnumerable<Guid> memberIDs, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"groups/{groupID}");

            var buffer = new ArrayBufferWriter<byte>();
            using (var writer = new Utf8JsonWriter(buffer))
            {
                writer.WriteStartObject();
                writer.WriteStartArray("members@odata.bind");

                foreach (var memberID in memberIDs)
                {
                    writer.WriteStringValue(httpClient.BaseAddress + "directoryObjects/" + memberID);
                }

                writer.WriteEndArray();
                writer.WriteEndObject();
            }

            await PatchAsync(tenant, buffer.WrittenMemory, link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }

        async Task ISlimGraphGroupsClient.RemoveMemberAsync(IAzureTenant tenant, Guid groupID, Guid memberID, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"groups/{groupID}/members/{memberID}/$ref");

            await DeleteAsync(tenant, link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }
    }
}