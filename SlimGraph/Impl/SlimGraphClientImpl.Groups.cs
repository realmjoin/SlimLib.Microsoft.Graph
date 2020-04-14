using SlimGraph.Auth;
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
            string? nextLink = options.BuildLink($"groups/{groupID}/photos");

            do
            {
                var root = await GetAsync(tenant, nextLink, cancellationToken).ConfigureAwait(false);

                foreach (var item in root.GetProperty("value").EnumerateArray())
                {
                    if (cancellationToken.IsCancellationRequested)
                        yield break;

                    yield return item;
                }

                HandleNextLink(root, ref nextLink);

            } while (nextLink != null);
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphGroupsClient.GetGroupsAsync(IAzureTenant tenant, ListRequestOptions options, [EnumeratorCancellation]  CancellationToken cancellationToken)
        {
            string? nextLink = options.BuildLink("groups");

            do
            {
                var root = await GetAsync(tenant, nextLink, cancellationToken).ConfigureAwait(false);

                foreach (var item in root.GetProperty("value").EnumerateArray())
                {
                    if (cancellationToken.IsCancellationRequested)
                        yield break;

                    yield return item;
                }

                HandleNextLink(root, ref nextLink);

            } while (nextLink != null);
        }

        async Task<DeltaResult<JsonElement>> ISlimGraphGroupsClient.GetGroupsDeltaAsync(IAzureTenant tenant, DeltaRequestOptions options, CancellationToken cancellationToken)
        {
            var result = new List<JsonElement>();

            string? nextLink = options.BuildLink("groups/delta");
            string? deltaLink = default;

            do
            {
                var root = await GetAsync(tenant, nextLink, cancellationToken, preferMinimal: options.PreferMinimal).ConfigureAwait(false);

                foreach (var item in root.GetProperty("value").EnumerateArray())
                {
                    if (cancellationToken.IsCancellationRequested)
                        return new DeltaResult<JsonElement>(result, deltaLink);

                    result.Add(item);
                }

                HandleNextLink(root, ref nextLink);
                HandleDeltaLink(root, ref deltaLink);

            } while (nextLink != null);

            return new DeltaResult<JsonElement>(result, deltaLink);
        }

        async Task<DeltaResult<JsonElement>> ISlimGraphGroupsClient.GetGroupsDeltaChangeAsync(IAzureTenant tenant, string previousDeltaLink, DeltaRequestOptions options, CancellationToken cancellationToken)
        {
            var result = new List<JsonElement>();

            string? nextLink = previousDeltaLink;
            string? deltaLink = default;

            do
            {
                var root = await GetAsync(tenant, nextLink, cancellationToken, preferMinimal: options.PreferMinimal).ConfigureAwait(false);

                foreach (var item in root.GetProperty("value").EnumerateArray())
                {
                    if (cancellationToken.IsCancellationRequested)
                        return new DeltaResult<JsonElement>(result, deltaLink);

                    result.Add(item);
                }

                HandleNextLink(root, ref nextLink);
                HandleDeltaLink(root, ref deltaLink);

            } while (nextLink != null);

            return new DeltaResult<JsonElement>(result, deltaLink);
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphGroupsClient.GetMembersAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            string? nextLink = options.BuildLink($"groups/{groupID}/members");

            do
            {
                var root = await GetAsync(tenant, nextLink, cancellationToken).ConfigureAwait(false);

                foreach (var item in root.GetProperty("value").EnumerateArray())
                {
                    if (cancellationToken.IsCancellationRequested)
                        yield break;

                    yield return item;
                }

                HandleNextLink(root, ref nextLink);

            } while (nextLink != null);
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphGroupsClient.GetTransitiveMembersAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            string? nextLink = options.BuildLink($"groups/{groupID}/transitiveMembers");

            do
            {
                var root = await GetAsync(tenant, nextLink, cancellationToken).ConfigureAwait(false);

                foreach (var item in root.GetProperty("value").EnumerateArray())
                {
                    if (cancellationToken.IsCancellationRequested)
                        yield break;

                    yield return item;
                }

                HandleNextLink(root, ref nextLink);

            } while (nextLink != null);
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphGroupsClient.GetMemberOfAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            string? nextLink = options.BuildLink($"groups/{groupID}/memberOf");

            do
            {
                var root = await GetAsync(tenant, nextLink, cancellationToken).ConfigureAwait(false);

                foreach (var item in root.GetProperty("value").EnumerateArray())
                {
                    if (cancellationToken.IsCancellationRequested)
                        yield break;

                    yield return item;
                }

                HandleNextLink(root, ref nextLink);

            } while (nextLink != null);
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphGroupsClient.GetTransitiveMemberOfAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            string? nextLink = options.BuildLink($"groups/{groupID}/transitiveMemberOf");

            do
            {
                var root = await GetAsync(tenant, nextLink, cancellationToken).ConfigureAwait(false);

                foreach (var item in root.GetProperty("value").EnumerateArray())
                {
                    if (cancellationToken.IsCancellationRequested)
                        yield break;

                    yield return item;
                }

                HandleNextLink(root, ref nextLink);

            } while (nextLink != null);
        }

        async IAsyncEnumerable<Guid> ISlimGraphGroupsClient.GetMemberGroupsAsync(IAzureTenant tenant, Guid groupID, bool securityEnabledOnly, InvokeRequestOptions options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            string? nextLink = options.BuildLink($"groups/{groupID}/getMemberGroups");

            do
            {
                var root = await PostAsync(tenant, new { securityEnabledOnly }, nextLink, cancellationToken).ConfigureAwait(false);

                foreach (var item in root.GetProperty("value").EnumerateArray())
                {
                    if (cancellationToken.IsCancellationRequested)
                        yield break;

                    yield return item.GetGuid();
                }

                HandleNextLink(root, ref nextLink);

            } while (nextLink != null);
        }

        async IAsyncEnumerable<Guid> ISlimGraphGroupsClient.GetMemberObjectsAsync(IAzureTenant tenant, Guid groupID, bool securityEnabledOnly, InvokeRequestOptions options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            string? nextLink = options.BuildLink($"groups/{groupID}/getMemberObjects");

            do
            {
                var root = await PostAsync(tenant, new { securityEnabledOnly }, nextLink, cancellationToken).ConfigureAwait(false);

                foreach (var item in root.GetProperty("value").EnumerateArray())
                {
                    if (cancellationToken.IsCancellationRequested)
                        yield break;

                    yield return item.GetGuid();
                }

                HandleNextLink(root, ref nextLink);

            } while (nextLink != null);
        }
    }
}