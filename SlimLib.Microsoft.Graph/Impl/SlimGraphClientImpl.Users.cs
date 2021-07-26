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
        async Task<JsonElement> ISlimGraphUsersClient.GetUserAsync(IAzureTenant tenant, Guid userID, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"users/{userID}");

            return await GetAsync(tenant, link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }

        async Task<JsonElement> ISlimGraphUsersClient.GetUserPhotoAsync(IAzureTenant tenant, Guid userID, string size, ScalarRequestOptions? options, CancellationToken cancellationToken)
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

        async IAsyncEnumerable<JsonElement> ISlimGraphUsersClient.GetUserPhotosAsync(IAzureTenant tenant, Guid userID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"users/{userID}/photos");

            await foreach (var item in GetArrayAsync(tenant, nextLink, options, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item;
            }
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphUsersClient.GetUsersAsync(IAzureTenant tenant, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, "users");

            await foreach (var item in GetArrayAsync(tenant, nextLink, options, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item;
            }
        }

        Task<DeltaResult<JsonElement>> ISlimGraphUsersClient.GetUsersDeltaAsync(IAzureTenant tenant, DeltaRequestOptions? options, CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, "users/delta");

            return GetDeltaAsync(tenant, nextLink, options, cancellationToken);
        }

        Task<DeltaResult<JsonElement>> ISlimGraphUsersClient.GetUsersDeltaChangeAsync(IAzureTenant tenant, string previousDeltaLink, DeltaRequestOptions? options, CancellationToken cancellationToken)
        {
            return GetDeltaAsync(tenant, previousDeltaLink, options, cancellationToken);
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphUsersClient.GetMemberOfAsync(IAzureTenant tenant, Guid userID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"users/{userID}/memberOf");

            await foreach (var item in GetArrayAsync(tenant, nextLink, options, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item;
            }
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphUsersClient.GetOwnedDevicesAsync(IAzureTenant tenant, Guid userID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"users/{userID}/ownedDevices");

            await foreach (var item in GetArrayAsync(tenant, nextLink, options, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item;
            }
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphUsersClient.GetRegisteredDevicesAsync(IAzureTenant tenant, Guid userID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"users/{userID}/registeredDevices");

            await foreach (var item in GetArrayAsync(tenant, nextLink, options, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item;
            }
        }

#pragma warning disable CS8424 // The EnumeratorCancellationAttribute will have no effect. The attribute is only effective on a parameter of type CancellationToken in an async-iterator method returning IAsyncEnumerable

        IAsyncEnumerable<Guid> ISlimGraphUsersClient.GetMemberGroupsAsync(IAzureTenant tenant, Guid userID, bool securityEnabledOnly, InvokeRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
            => GetMemberGroupsImplAsync(tenant, userID, securityEnabledOnly, options, cancellationToken);

        IAsyncEnumerable<Guid> ISlimGraphUsersClient.GetMemberObjectsAsync(IAzureTenant tenant, Guid userID, bool securityEnabledOnly, InvokeRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
            => GetMemberObjectsImplAsync(tenant, userID, securityEnabledOnly, options, cancellationToken);

        IAsyncEnumerable<Guid> ISlimGraphUsersClient.GetMemberGroupsAsync(IAzureTenant tenant, string userPrincipalName, bool securityEnabledOnly, InvokeRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
            => GetMemberGroupsImplAsync(tenant, userPrincipalName, securityEnabledOnly, options, cancellationToken);

        IAsyncEnumerable<Guid> ISlimGraphUsersClient.GetMemberObjectsAsync(IAzureTenant tenant, string userPrincipalName, bool securityEnabledOnly, InvokeRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
            => GetMemberObjectsImplAsync(tenant, userPrincipalName, securityEnabledOnly, options, cancellationToken);

#pragma warning restore CS8424 // The EnumeratorCancellationAttribute will have no effect. The attribute is only effective on a parameter of type CancellationToken in an async-iterator method returning IAsyncEnumerable

        private async IAsyncEnumerable<Guid> GetMemberGroupsImplAsync(IAzureTenant tenant, object id, bool securityEnabledOnly, InvokeRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"users/{id}/getMemberGroups");

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

        private async IAsyncEnumerable<Guid> GetMemberObjectsImplAsync(IAzureTenant tenant, object id, bool securityEnabledOnly, InvokeRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"users/{id}/getMemberObjects");

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
    }
}