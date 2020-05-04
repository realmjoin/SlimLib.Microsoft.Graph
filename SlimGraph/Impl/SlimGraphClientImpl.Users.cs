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
        async Task<JsonElement> ISlimGraphUsersClient.GetUserAsync(IAzureTenant tenant, Guid userID, ScalarRequestOptions options, CancellationToken cancellationToken)
        {
            var link = options.BuildLink($"users/{userID}");

            return await GetAsync(tenant, link, cancellationToken).ConfigureAwait(false);
        }

        async Task<JsonElement> ISlimGraphUsersClient.GetUserPhotoAsync(IAzureTenant tenant, Guid userID, string size, ScalarRequestOptions options, CancellationToken cancellationToken)
        {
            string link;

            if (string.IsNullOrEmpty(size))
                link = options.BuildLink($"users/{userID}/photo");
            else
                link = options.BuildLink($"users/{userID}/photos/{size}");

            return await GetAsync(tenant, link, cancellationToken).ConfigureAwait(false);
        }

        async Task<SlimGraphPicture?> ISlimGraphUsersClient.GetUserPhotoDataAsync(IAzureTenant tenant, Guid userID, string size, ScalarRequestOptions options, CancellationToken cancellationToken)
        {
            string link;

            if (string.IsNullOrEmpty(size))
                link = options.BuildLink($"users/{userID}/photo/$value");
            else
                link = options.BuildLink($"users/{userID}/photos/{size}/$value");

            return await GetPictureAsync(tenant, link, cancellationToken).ConfigureAwait(false);
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphUsersClient.GetUserPhotosAsync(IAzureTenant tenant, Guid userID, ListRequestOptions options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = options.BuildLink($"users/{userID}/photos");

            await foreach (var item in GetArrayAsync(tenant, nextLink, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item;
            }
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphUsersClient.GetUsersAsync(IAzureTenant tenant, ListRequestOptions options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = options.BuildLink("users");

            await foreach (var item in GetArrayAsync(tenant, nextLink, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item;
            }
        }

        Task<DeltaResult<JsonElement>> ISlimGraphUsersClient.GetUsersDeltaAsync(IAzureTenant tenant, DeltaRequestOptions options, CancellationToken cancellationToken)
        {
            var nextLink = options.BuildLink("users/delta");

            return GetDeltaAsync(tenant, nextLink, options, cancellationToken);
        }

        Task<DeltaResult<JsonElement>> ISlimGraphUsersClient.GetUsersDeltaChangeAsync(IAzureTenant tenant, string previousDeltaLink, DeltaRequestOptions options, CancellationToken cancellationToken)
        {
            return GetDeltaAsync(tenant, previousDeltaLink, options, cancellationToken);
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphUsersClient.GetMemberOfAsync(IAzureTenant tenant, Guid userID, ListRequestOptions options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = options.BuildLink($"users/{userID}/memberOf");

            await foreach (var item in GetArrayAsync(tenant, nextLink, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item;
            }
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphUsersClient.GetOwnedDevicesAsync(IAzureTenant tenant, Guid userID, ListRequestOptions options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = options.BuildLink($"users/{userID}/ownedDevices");

            await foreach (var item in GetArrayAsync(tenant, nextLink, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item;
            }
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphUsersClient.GetRegisteredDevicesAsync(IAzureTenant tenant, Guid userID, ListRequestOptions options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = options.BuildLink($"users/{userID}/registeredDevices");

            await foreach (var item in GetArrayAsync(tenant, nextLink, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item;
            }
        }

#pragma warning disable CS8424 // The EnumeratorCancellationAttribute will have no effect. The attribute is only effective on a parameter of type CancellationToken in an async-iterator method returning IAsyncEnumerable

        IAsyncEnumerable<Guid> ISlimGraphUsersClient.GetMemberGroupsAsync(IAzureTenant tenant, Guid userID, bool securityEnabledOnly, InvokeRequestOptions options, [EnumeratorCancellation] CancellationToken cancellationToken)
            => GetMemberGroupsImplAsync(tenant, userID, securityEnabledOnly, options, cancellationToken);

        IAsyncEnumerable<Guid> ISlimGraphUsersClient.GetMemberObjectsAsync(IAzureTenant tenant, Guid userID, bool securityEnabledOnly, InvokeRequestOptions options, [EnumeratorCancellation] CancellationToken cancellationToken)
            => GetMemberObjectsImplAsync(tenant, userID, securityEnabledOnly, options, cancellationToken);

        IAsyncEnumerable<Guid> ISlimGraphUsersClient.GetMemberGroupsAsync(IAzureTenant tenant, string userPrincipalName, bool securityEnabledOnly, InvokeRequestOptions options, [EnumeratorCancellation] CancellationToken cancellationToken)
            => GetMemberGroupsImplAsync(tenant, userPrincipalName, securityEnabledOnly, options, cancellationToken);

        IAsyncEnumerable<Guid> ISlimGraphUsersClient.GetMemberObjectsAsync(IAzureTenant tenant, string userPrincipalName, bool securityEnabledOnly, InvokeRequestOptions options, [EnumeratorCancellation] CancellationToken cancellationToken)
            => GetMemberObjectsImplAsync(tenant, userPrincipalName, securityEnabledOnly, options, cancellationToken);

#pragma warning restore CS8424 // The EnumeratorCancellationAttribute will have no effect. The attribute is only effective on a parameter of type CancellationToken in an async-iterator method returning IAsyncEnumerable

        private async IAsyncEnumerable<Guid> GetMemberGroupsImplAsync(IAzureTenant tenant, object id, bool securityEnabledOnly, InvokeRequestOptions options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = options.BuildLink($"users/{id}/getMemberGroups");
            var data = new { securityEnabledOnly };

            await foreach (var item in PostArrayAsync(tenant, data, nextLink, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item.GetGuid();
            }
        }

        private async IAsyncEnumerable<Guid> GetMemberObjectsImplAsync(IAzureTenant tenant, object id, bool securityEnabledOnly, InvokeRequestOptions options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = options.BuildLink($"users/{id}/getMemberObjects");
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