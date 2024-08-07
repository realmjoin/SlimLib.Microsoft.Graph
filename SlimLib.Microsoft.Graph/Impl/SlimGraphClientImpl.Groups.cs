using SlimLib.Auth.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;

namespace SlimLib.Microsoft.Graph
{
    partial class SlimGraphClientImpl
    {
        async Task<JsonDocument?> ISlimGraphGroupsClient.CreateGroupAsync(IAzureTenant tenant, JsonObject data, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, "groups");

            return await PostAsync(tenant, JsonSerializer.SerializeToUtf8Bytes(data), link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }

        async Task<JsonDocument?> ISlimGraphGroupsClient.GetGroupAsync(IAzureTenant tenant, Guid groupID, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"groups/{groupID}");

            return await GetAsync(tenant, link, new RequestHeaderOptions(), null, cancellationToken).ConfigureAwait(false);
        }

        async Task<JsonDocument?> ISlimGraphGroupsClient.UpdateGroupAsync(IAzureTenant tenant, Guid groupID, JsonObject data, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"groups/{groupID}");

            return await PatchAsync(tenant, JsonSerializer.SerializeToUtf8Bytes(data), link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }

        async Task ISlimGraphGroupsClient.DeleteGroupAsync(IAzureTenant tenant, Guid groupID, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"groups/{groupID}");

            await DeleteAsync(tenant, link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }

        async Task<JsonDocument?> ISlimGraphGroupsClient.GetGroupPhotoAsync(IAzureTenant tenant, Guid groupID, string size, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            string link;

            if (string.IsNullOrEmpty(size))
                link = BuildLink(options, $"groups/{groupID}/photo");
            else
                link = BuildLink(options, $"groups/{groupID}/photos/{size}");

            return await GetAsync(tenant, link, new RequestHeaderOptions(), null, cancellationToken).ConfigureAwait(false);
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

        IAsyncEnumerable<JsonDocument> ISlimGraphGroupsClient.GetGroupPhotosAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"groups/{groupID}/photos");

            return GetArrayAsync(tenant, nextLink, options, cancellationToken);
        }

        IAsyncEnumerable<JsonDocument> ISlimGraphGroupsClient.GetGroupsAsync(IAzureTenant tenant, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, "groups");

            return GetArrayAsync(tenant, nextLink, options, cancellationToken);
        }

        Task<Results.Delta.DeltaResult<JsonElement>> ISlimGraphGroupsClient.GetGroupsDeltaAsync(IAzureTenant tenant, DeltaRequestOptions? options, CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, "groups/delta");

            return GetDeltaAsync(tenant, nextLink, options, cancellationToken);
        }

        Task<Results.Delta.DeltaResult<JsonElement>> ISlimGraphGroupsClient.GetGroupsDeltaChangeAsync(IAzureTenant tenant, string previousDeltaLink, DeltaRequestOptions? options, CancellationToken cancellationToken)
        {
            return GetDeltaAsync(tenant, previousDeltaLink, options, cancellationToken);
        }

        IAsyncEnumerable<JsonDocument> ISlimGraphGroupsClient.GetOwnersAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"groups/{groupID}/owners");

            return GetArrayAsync(tenant, nextLink, options, cancellationToken);
        }

        IAsyncEnumerable<JsonDocument> ISlimGraphGroupsClient.GetOwnersAsync(IAzureTenant tenant, Guid groupID, string type, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"groups/{groupID}/owners/{type}");

            return GetArrayAsync(tenant, nextLink, options, cancellationToken);
        }

        IAsyncEnumerable<JsonDocument> ISlimGraphGroupsClient.GetMembersAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"groups/{groupID}/members");

            return GetArrayAsync(tenant, nextLink, options, cancellationToken);
        }

        IAsyncEnumerable<JsonDocument> ISlimGraphGroupsClient.GetMembersAsync(IAzureTenant tenant, Guid groupID, string type, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"groups/{groupID}/members/{type}");

            return GetArrayAsync(tenant, nextLink, options, cancellationToken);
        }

        IAsyncEnumerable<JsonDocument> ISlimGraphGroupsClient.GetTransitiveMembersAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"groups/{groupID}/transitiveMembers");

            return GetArrayAsync(tenant, nextLink, options, cancellationToken);
        }

        IAsyncEnumerable<JsonDocument> ISlimGraphGroupsClient.GetTransitiveMembersAsync(IAzureTenant tenant, Guid groupID, string type, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"groups/{groupID}/transitiveMembers/{type}");

            return GetArrayAsync(tenant, nextLink, options, cancellationToken);
        }

        IAsyncEnumerable<JsonDocument> ISlimGraphGroupsClient.GetMemberOfAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"groups/{groupID}/memberOf");

            return GetArrayAsync(tenant, nextLink, options, cancellationToken);
        }

        IAsyncEnumerable<JsonDocument> ISlimGraphGroupsClient.GetTransitiveMemberOfAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"groups/{groupID}/transitiveMemberOf");

            return GetArrayAsync(tenant, nextLink, options, cancellationToken);
        }

        async Task<JsonDocument?> ISlimGraphGroupsClient.AddMemberAsync(IAzureTenant tenant, Guid groupID, TypedMember member, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"groups/{groupID}/members/$ref");

            var data = new JsonObject
            {
                ["@odata.id"] = "" + httpClient.BaseAddress + member
            };

            return await PostAsync(tenant, JsonSerializer.SerializeToUtf8Bytes(data), link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }

        async Task<JsonDocument?> ISlimGraphGroupsClient.AddMembersAsync(IAzureTenant tenant, Guid groupID, IEnumerable<TypedMember> members, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"groups/{groupID}");

            var data = new JsonObject
            {
                ["members@odata.bind"] = new JsonArray(members.Select(x => JsonValue.Create("" + httpClient.BaseAddress + x)).ToArray())
            };

            return await PatchAsync(tenant, JsonSerializer.SerializeToUtf8Bytes(data), link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }

        async Task ISlimGraphGroupsClient.RemoveMemberAsync(IAzureTenant tenant, Guid groupID, Guid memberID, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"groups/{groupID}/members/{memberID}/$ref");

            await DeleteAsync(tenant, link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }
    }
}