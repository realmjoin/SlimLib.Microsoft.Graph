using SlimLib.Auth.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;

namespace SlimLib.Microsoft.Graph
{
    partial class SlimGraphClientImpl
    {
        GraphOperation<JsonDocument?> ISlimGraphGroupsClient.CreateGroupAsync(IAzureTenant tenant, JsonObject data, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, "groups");

            return new(this, tenant, HttpMethod.Post, link, options, JsonSerializer.SerializeToUtf8Bytes(data), static doc => doc);
        }

        GraphOperation<JsonDocument?> ISlimGraphGroupsClient.GetGroupAsync(IAzureTenant tenant, Guid groupID, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"groups/{groupID}");

            return new(this, tenant, HttpMethod.Get, link, options, static doc => doc);
        }

        GraphOperation<JsonDocument?> ISlimGraphGroupsClient.UpdateGroupAsync(IAzureTenant tenant, Guid groupID, JsonObject data, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"groups/{groupID}");

            return new(this, tenant, HttpMethod.Patch, link, options, JsonSerializer.SerializeToUtf8Bytes(data), static doc => doc);
        }

        GraphOperation ISlimGraphGroupsClient.DeleteGroupAsync(IAzureTenant tenant, Guid groupID, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"groups/{groupID}");

            return new(this, tenant, HttpMethod.Delete, link, options);
        }

        GraphOperation<JsonDocument?> ISlimGraphGroupsClient.GetGroupPhotoAsync(IAzureTenant tenant, Guid groupID, string size, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            string link;

            if (string.IsNullOrEmpty(size))
                link = BuildLink(options, $"groups/{groupID}/photo");
            else
                link = BuildLink(options, $"groups/{groupID}/photos/{size}");

            return new(this, tenant, HttpMethod.Get, link, options, static doc => doc);
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

        GraphArrayOperation<JsonDocument> ISlimGraphGroupsClient.GetGroupPhotosAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"groups/{groupID}/photos");

            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc => doc);
        }

        GraphArrayOperation<JsonDocument> ISlimGraphGroupsClient.GetGroupsAsync(IAzureTenant tenant, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, "groups");

            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc => doc);
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

        GraphArrayOperation<JsonDocument> ISlimGraphGroupsClient.GetOwnersAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"groups/{groupID}/owners");

            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc => doc);
        }

        GraphArrayOperation<JsonDocument> ISlimGraphGroupsClient.GetOwnersAsync(IAzureTenant tenant, Guid groupID, string type, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"groups/{groupID}/owners/{type}");

            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc => doc);
        }

        GraphArrayOperation<JsonDocument> ISlimGraphGroupsClient.GetMembersAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"groups/{groupID}/members");

            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc => doc);
        }

        GraphArrayOperation<JsonDocument> ISlimGraphGroupsClient.GetMembersAsync(IAzureTenant tenant, Guid groupID, string type, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"groups/{groupID}/members/{type}");

            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc => doc);
        }

        GraphArrayOperation<JsonDocument> ISlimGraphGroupsClient.GetTransitiveMembersAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"groups/{groupID}/transitiveMembers");

            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc => doc);
        }

        GraphArrayOperation<JsonDocument> ISlimGraphGroupsClient.GetTransitiveMembersAsync(IAzureTenant tenant, Guid groupID, string type, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"groups/{groupID}/transitiveMembers/{type}");

            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc => doc);
        }

        GraphOperation<long> ISlimGraphGroupsClient.GetMemberCountAsync(IAzureTenant tenant, Guid groupID, CancellationToken cancellationToken = default)
        {
            var nextLink = $"groups/{groupID}/members/$count";
            var options = new InvokeRequestOptions { ConsistencyLevel = ConsistencyLevel.Eventual };

            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc =>
            {
                using (doc)
                {
                    return doc?.RootElement.GetInt64() ?? -1L;
                }
            });
        }

        GraphOperation<long> ISlimGraphGroupsClient.GetMemberCountAsync(IAzureTenant tenant, Guid groupID, string type, CancellationToken cancellationToken = default)
        {
            var nextLink = $"groups/{groupID}/members/{type}/$count";
            var options = new InvokeRequestOptions { ConsistencyLevel = ConsistencyLevel.Eventual };

            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc =>
            {
                using (doc)
                {
                    return doc?.RootElement.GetInt64() ?? -1L;
                }
            });
        }

        GraphOperation<long> ISlimGraphGroupsClient.GetTransitiveMemberCountAsync(IAzureTenant tenant, Guid groupID, CancellationToken cancellationToken = default)
        {
            var nextLink = $"groups/{groupID}/transitiveMembers/$count";
            var options = new InvokeRequestOptions { ConsistencyLevel = ConsistencyLevel.Eventual };

            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc =>
            {
                using (doc)
                {
                    return doc?.RootElement.GetInt64() ?? -1L;
                }
            });
        }

        GraphOperation<long> ISlimGraphGroupsClient.GetTransitiveMemberCountAsync(IAzureTenant tenant, Guid groupID, string type, CancellationToken cancellationToken = default)
        {
            var nextLink = $"groups/{groupID}/transitiveMembers/{type}/$count";
            var options = new InvokeRequestOptions { ConsistencyLevel = ConsistencyLevel.Eventual };

            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc =>
            {
                using (doc)
                {
                    return doc?.RootElement.GetInt64() ?? -1L;
                }
            });
        }


        GraphArrayOperation<JsonDocument> ISlimGraphGroupsClient.GetMemberOfAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"groups/{groupID}/memberOf");

            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc => doc);
        }

        GraphArrayOperation<JsonDocument> ISlimGraphGroupsClient.GetTransitiveMemberOfAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"groups/{groupID}/transitiveMemberOf");

            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc => doc);
        }

        GraphOperation<JsonDocument?> ISlimGraphGroupsClient.AddMemberAsync(IAzureTenant tenant, Guid groupID, TypedMember member, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"groups/{groupID}/members/$ref");

            var data = new JsonObject
            {
                ["@odata.id"] = "" + httpClient.BaseAddress + member
            };

            return new(this, tenant, HttpMethod.Post, link, options, JsonSerializer.SerializeToUtf8Bytes(data), static doc => doc);
        }

        GraphOperation<JsonDocument?> ISlimGraphGroupsClient.AddMembersAsync(IAzureTenant tenant, Guid groupID, IEnumerable<TypedMember> members, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"groups/{groupID}");

            var data = new JsonObject
            {
                ["members@odata.bind"] = new JsonArray(members.Select(x => JsonValue.Create("" + httpClient.BaseAddress + x)).ToArray())
            };

            return new(this, tenant, HttpMethod.Patch, link, options, JsonSerializer.SerializeToUtf8Bytes(data), static doc => doc);
        }

        GraphOperation ISlimGraphGroupsClient.RemoveMemberAsync(IAzureTenant tenant, Guid groupID, Guid memberID, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"groups/{groupID}/members/{memberID}/$ref");

            return new(this, tenant, HttpMethod.Delete, link, options);
        }
    }
}