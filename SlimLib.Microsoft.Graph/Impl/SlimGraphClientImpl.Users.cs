using SlimLib.Auth.Azure;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SlimLib.Microsoft.Graph
{
    partial class SlimGraphClientImpl
    {
        GraphOperation<JsonDocument?> ISlimGraphUsersClient.GetUserAsync(IAzureTenant tenant, string userPrincipalName, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"users/{userPrincipalName}");

            return new(this, tenant, HttpMethod.Get, link, options, static doc => doc);
        }

        GraphOperation<JsonDocument?> ISlimGraphUsersClient.GetUserAsync(IAzureTenant tenant, Guid userID, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"users/{userID}");

            return new(this, tenant, HttpMethod.Get, link, options, static doc => doc);
        }

        GraphOperation<JsonDocument?> ISlimGraphUsersClient.GetUserPhotoAsync(IAzureTenant tenant, Guid userID, string size, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            string link;

            if (string.IsNullOrEmpty(size))
                link = BuildLink(options, $"users/{userID}/photo");
            else
                link = BuildLink(options, $"users/{userID}/photos/{size}");

            return new(this, tenant, HttpMethod.Get, link, options, static doc => doc);
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

        GraphArrayOperation<JsonDocument> ISlimGraphUsersClient.GetUserPhotosAsync(IAzureTenant tenant, Guid userID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"users/{userID}/photos");

            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc => doc);
        }

        GraphArrayOperation<JsonDocument> ISlimGraphUsersClient.GetUserAppRoleAssignmentsAsync(IAzureTenant tenant, Guid userID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"users/{userID}/appRoleAssignments");

            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc => doc);
        }

        GraphArrayOperation<JsonDocument> ISlimGraphUsersClient.GetUsersAsync(IAzureTenant tenant, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, "users");

            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc => doc);
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

        GraphArrayOperation<JsonDocument> ISlimGraphUsersClient.GetMemberOfAsync(IAzureTenant tenant, Guid userID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"users/{userID}/memberOf");

            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc => doc);
        }

        GraphArrayOperation<JsonDocument> ISlimGraphUsersClient.GetTransitiveMemberOfAsync(IAzureTenant tenant, Guid userID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"users/{userID}/transitiveMemberOf");

            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc => doc);
        }

        GraphArrayOperation<JsonDocument> ISlimGraphUsersClient.GetOwnedDevicesAsync(IAzureTenant tenant, Guid userID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"users/{userID}/ownedDevices");

            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc => doc);
        }

        GraphArrayOperation<JsonDocument> ISlimGraphUsersClient.GetRegisteredDevicesAsync(IAzureTenant tenant, Guid userID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"users/{userID}/registeredDevices");

            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc => doc);
        }

        GraphArrayOperation<Guid[]> ISlimGraphUsersClient.CheckMemberGroupsAsync(IAzureTenant tenant, string userPrincipalName, ICollection<Guid> groupIDs, InvokeRequestOptions? options, CancellationToken cancellationToken)
            => CheckMemberGroupsImplAsync(tenant, "users", userPrincipalName, groupIDs, options, cancellationToken);
        GraphArrayOperation<Guid[]> ISlimGraphUsersClient.GetMemberGroupsAsync(IAzureTenant tenant, string userPrincipalName, bool securityEnabledOnly, InvokeRequestOptions? options, CancellationToken cancellationToken)
            => GetMemberGroupsImplAsync(tenant, "users", userPrincipalName, securityEnabledOnly, options, cancellationToken);

        GraphArrayOperation<Guid[]> ISlimGraphUsersClient.CheckMemberObjectsAsync(IAzureTenant tenant, string userPrincipalName, ICollection<Guid> ids, InvokeRequestOptions? options, CancellationToken cancellationToken)
            => CheckMemberObjectsImplAsync(tenant, "users", userPrincipalName, ids, options, cancellationToken);
        GraphArrayOperation<Guid[]> ISlimGraphUsersClient.GetMemberObjectsAsync(IAzureTenant tenant, string userPrincipalName, bool securityEnabledOnly, InvokeRequestOptions? options, CancellationToken cancellationToken)
            => GetMemberObjectsImplAsync(tenant, "users", userPrincipalName, securityEnabledOnly, options, cancellationToken);
    }
}