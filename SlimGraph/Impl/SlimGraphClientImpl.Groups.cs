﻿using SlimGraph.Auth;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SlimGraph
{
    partial class SlimGraphClientImpl
    {
        async Task<JsonElement> ISlimGraphGroupsClient.GetGroupAsync(IAzureTenant tenant, Guid groupID, ScalarRequestOptions options, CancellationToken cancellationToken)
        {
            var link = options.BuildLink($"groups/{groupID}");

            return await GetAsync(tenant, link, cancellationToken).ConfigureAwait(false);
        }

        async Task<JsonElement> ISlimGraphGroupsClient.GetGroupPhotoAsync(IAzureTenant tenant, Guid groupID, string size, ScalarRequestOptions options, CancellationToken cancellationToken)
        {
            string link;

            if (string.IsNullOrEmpty(size))
                link = options.BuildLink($"groups/{groupID}/photo");
            else
                link = options.BuildLink($"groups/{groupID}/photos/{size}");

            return await GetAsync(tenant, link, cancellationToken).ConfigureAwait(false);
        }

        async Task<SlimGraphPicture?> ISlimGraphGroupsClient.GetGroupPhotoDataAsync(IAzureTenant tenant, Guid groupID, string size, ScalarRequestOptions options, CancellationToken cancellationToken)
        {
            string link;

            if (string.IsNullOrEmpty(size))
                link = options.BuildLink($"groups/{groupID}/photo/$value");
            else
                link = options.BuildLink($"groups/{groupID}/photos/{size}/$value");

            return await GetPictureAsync(tenant, link, cancellationToken).ConfigureAwait(false);
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphGroupsClient.GetGroupPhotosAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = options.BuildLink($"groups/{groupID}/photos");

            await foreach (var item in GetArrayAsync(tenant, nextLink, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item;
            }
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphGroupsClient.GetGroupsAsync(IAzureTenant tenant, ListRequestOptions options, [EnumeratorCancellation]  CancellationToken cancellationToken)
        {
            var nextLink = options.BuildLink("groups");

            await foreach (var item in GetArrayAsync(tenant, nextLink, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item;
            }
        }

        Task<DeltaResult<JsonElement>> ISlimGraphGroupsClient.GetGroupsDeltaAsync(IAzureTenant tenant, DeltaRequestOptions options, CancellationToken cancellationToken)
        {
            var nextLink = options.BuildLink("groups/delta");

            return GetDeltaAsync(tenant, nextLink, options, cancellationToken);
        }

        Task<DeltaResult<JsonElement>> ISlimGraphGroupsClient.GetGroupsDeltaChangeAsync(IAzureTenant tenant, string previousDeltaLink, DeltaRequestOptions options, CancellationToken cancellationToken)
        {
            return GetDeltaAsync(tenant, previousDeltaLink, options, cancellationToken);
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphGroupsClient.GetMembersAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = options.BuildLink($"groups/{groupID}/members");

            await foreach (var item in GetArrayAsync(tenant, nextLink, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item;
            }
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphGroupsClient.GetTransitiveMembersAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = options.BuildLink($"groups/{groupID}/transitiveMembers");

            await foreach (var item in GetArrayAsync(tenant, nextLink, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item;
            }
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphGroupsClient.GetMemberOfAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = options.BuildLink($"groups/{groupID}/memberOf");

            await foreach (var item in GetArrayAsync(tenant, nextLink, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item;
            }
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphGroupsClient.GetTransitiveMemberOfAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = options.BuildLink($"groups/{groupID}/transitiveMemberOf");

            await foreach (var item in GetArrayAsync(tenant, nextLink, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item;
            }
        }

        async IAsyncEnumerable<Guid> ISlimGraphGroupsClient.GetMemberGroupsAsync(IAzureTenant tenant, Guid groupID, bool securityEnabledOnly, InvokeRequestOptions options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = options.BuildLink($"groups/{groupID}/getMemberGroups");
            var data = new { securityEnabledOnly };

            await foreach (var item in PostArrayAsync(tenant, data, nextLink, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item.GetGuid();
            }
        }

        async IAsyncEnumerable<Guid> ISlimGraphGroupsClient.GetMemberObjectsAsync(IAzureTenant tenant, Guid groupID, bool securityEnabledOnly, InvokeRequestOptions options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = options.BuildLink($"groups/{groupID}/getMemberObjects");
            var data = new { securityEnabledOnly };

            await foreach (var item in PostArrayAsync(tenant, data, nextLink, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item.GetGuid();
            }
        }
    }
}