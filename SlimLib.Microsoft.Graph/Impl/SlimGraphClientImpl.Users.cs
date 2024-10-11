using SlimLib.Auth.Azure;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SlimLib.Microsoft.Graph
{
    partial class SlimGraphClientImpl
    {
        async Task<JsonDocument?> ISlimGraphUsersClient.GetUserAsync(IAzureTenant tenant, string userPrincipalName, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"users/{userPrincipalName}");

            return await GetAsync(tenant, link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }

        async Task<JsonDocument?> ISlimGraphUsersClient.GetUserAsync(IAzureTenant tenant, Guid userID, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"users/{userID}");

            return await GetAsync(tenant, link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }

        async Task<JsonDocument?> ISlimGraphUsersClient.GetUserPhotoAsync(IAzureTenant tenant, Guid userID, string size, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            string link;

            if (string.IsNullOrEmpty(size))
                link = BuildLink(options, $"users/{userID}/photo");
            else
                link = BuildLink(options, $"users/{userID}/photos/{size}");

            return await GetAsync(tenant, link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }

        async Task<SlimGraphPicture?> ISlimGraphUsersClient.GetUserPhotoDataAsync(IAzureTenant tenant, Guid userID, string size, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            string link;

            if (string.IsNullOrEmpty(size))
                link = BuildLink(options, $"users/{userID}/photo/$value");
            else
                link = BuildLink(options, $"users/{userID}/photos/{size}/$value");

            return await GetPictureAsync(tenant, link, cancellationToken).ConfigureAwait(false);
        }

        IAsyncEnumerable<JsonDocument> ISlimGraphUsersClient.GetUserPhotosAsync(IAzureTenant tenant, Guid userID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"users/{userID}/photos");

            return GetArrayAsync(tenant, nextLink, options, cancellationToken);
        }

        IAsyncEnumerable<JsonDocument> ISlimGraphUsersClient.GetUserAppRoleAssignmentsAsync(IAzureTenant tenant, Guid userID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"users/{userID}/appRoleAssignments");

            return GetArrayAsync(tenant, nextLink, options, cancellationToken);
        }

        IAsyncEnumerable<JsonDocument> ISlimGraphUsersClient.GetUsersAsync(IAzureTenant tenant, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, "users");

            return GetArrayAsync(tenant, nextLink, options, cancellationToken);
        }

        Task<Results.Delta.DeltaResult<JsonElement>> ISlimGraphUsersClient.GetUsersDeltaAsync(IAzureTenant tenant, DeltaRequestOptions? options, CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, "users/delta");

            return GetDeltaAsync(tenant, nextLink, options, cancellationToken);
        }

        Task<Results.Delta.DeltaResult<JsonElement>> ISlimGraphUsersClient.GetUsersDeltaChangeAsync(IAzureTenant tenant, string previousDeltaLink, DeltaRequestOptions? options, CancellationToken cancellationToken)
        {
            return GetDeltaAsync(tenant, previousDeltaLink, options, cancellationToken);
        }

        IAsyncEnumerable<JsonDocument> ISlimGraphUsersClient.GetMemberOfAsync(IAzureTenant tenant, Guid userID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"users/{userID}/memberOf");

            return GetArrayAsync(tenant, nextLink, options, cancellationToken);
        }

        IAsyncEnumerable<JsonDocument> ISlimGraphUsersClient.GetTransitiveMemberOfAsync(IAzureTenant tenant, Guid userID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"users/{userID}/transitiveMemberOf");

            return GetArrayAsync(tenant, nextLink, options, cancellationToken);
        }

        IAsyncEnumerable<JsonDocument> ISlimGraphUsersClient.GetOwnedDevicesAsync(IAzureTenant tenant, Guid userID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"users/{userID}/ownedDevices");

            return GetArrayAsync(tenant, nextLink, options, cancellationToken);
        }

        IAsyncEnumerable<JsonDocument> ISlimGraphUsersClient.GetRegisteredDevicesAsync(IAzureTenant tenant, Guid userID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"users/{userID}/registeredDevices");

            return GetArrayAsync(tenant, nextLink, options, cancellationToken);
        }

        IAsyncEnumerable<Guid[]> ISlimGraphUsersClient.CheckMemberGroupsAsync(IAzureTenant tenant, string userPrincipalName, ICollection<Guid> groupIDs, InvokeRequestOptions? options, CancellationToken cancellationToken)
            => CheckMemberGroupsImplAsync(tenant, "users", userPrincipalName, groupIDs, options, cancellationToken);
        IAsyncEnumerable<Guid[]> ISlimGraphUsersClient.GetMemberGroupsAsync(IAzureTenant tenant, string userPrincipalName, bool securityEnabledOnly, InvokeRequestOptions? options, CancellationToken cancellationToken)
            => GetMemberGroupsImplAsync(tenant, "users", userPrincipalName, securityEnabledOnly, options, cancellationToken);

        IAsyncEnumerable<Guid[]> ISlimGraphUsersClient.CheckMemberObjectsAsync(IAzureTenant tenant, string userPrincipalName, ICollection<Guid> ids, InvokeRequestOptions? options, CancellationToken cancellationToken)
            => CheckMemberObjectsImplAsync(tenant, "users", userPrincipalName, ids, options, cancellationToken);
        IAsyncEnumerable<Guid[]> ISlimGraphUsersClient.GetMemberObjectsAsync(IAzureTenant tenant, string userPrincipalName, bool securityEnabledOnly, InvokeRequestOptions? options, CancellationToken cancellationToken)
            => GetMemberObjectsImplAsync(tenant, "users", userPrincipalName, securityEnabledOnly, options, cancellationToken);
    }
}