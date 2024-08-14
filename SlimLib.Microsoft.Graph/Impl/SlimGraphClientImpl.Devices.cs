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
        async Task<JsonDocument?> ISlimGraphDevicesClient.GetDeviceAsync(IAzureTenant tenant, Guid deviceID, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"devices/{deviceID}");

            return await GetAsync(tenant, link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }

        IAsyncEnumerable<JsonDocument> ISlimGraphDevicesClient.GetDevicesAsync(IAzureTenant tenant, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, "devices");

            return GetArrayAsync(tenant, nextLink, options, cancellationToken);
        }

        IAsyncEnumerable<JsonDocument> ISlimGraphDevicesClient.GetRegisteredOwnersAsync(IAzureTenant tenant, Guid deviceID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"devices/{deviceID}/registeredOwners");

            return GetArrayAsync(tenant, nextLink, options, cancellationToken);
        }

        IAsyncEnumerable<JsonDocument> ISlimGraphDevicesClient.GetRegisteredUsersDeviceAsync(IAzureTenant tenant, Guid deviceID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"devices/{deviceID}/registeredUsers");

            return GetArrayAsync(tenant, nextLink, options, cancellationToken);
        }

        IAsyncEnumerable<JsonDocument> ISlimGraphDevicesClient.GetMemberOfAsync(IAzureTenant tenant, Guid deviceID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"devices/{deviceID}/memberOf");

            return GetArrayAsync(tenant, nextLink, options, cancellationToken);
        }

        IAsyncEnumerable<JsonDocument> ISlimGraphDevicesClient.GetTransitiveMemberOfAsync(IAzureTenant tenant, Guid deviceID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"devices/{deviceID}/transitiveMemberOf");

            return GetArrayAsync(tenant, nextLink, options, cancellationToken);
        }
    }
}