using SlimLib.Auth.Azure;
using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;

namespace SlimLib.Microsoft.Graph
{
    partial class SlimGraphClientImpl
    {
        GraphOperation<JsonDocument?> ISlimGraphDevicesClient.GetDeviceAsync(IAzureTenant tenant, Guid deviceID, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"devices/{deviceID}");

            return new(this, tenant, HttpMethod.Get, link, options, static doc => doc);
        }

        GraphArrayOperation<JsonDocument> ISlimGraphDevicesClient.GetDevicesAsync(IAzureTenant tenant, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, "devices");

            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc => doc);
        }

        GraphArrayOperation<JsonDocument> ISlimGraphDevicesClient.GetRegisteredOwnersAsync(IAzureTenant tenant, Guid deviceID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"devices/{deviceID}/registeredOwners");

            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc => doc);
        }

        GraphArrayOperation<JsonDocument> ISlimGraphDevicesClient.GetRegisteredUsersDeviceAsync(IAzureTenant tenant, Guid deviceID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"devices/{deviceID}/registeredUsers");

            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc => doc);
        }

        GraphArrayOperation<JsonDocument> ISlimGraphDevicesClient.GetMemberOfAsync(IAzureTenant tenant, Guid deviceID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"devices/{deviceID}/memberOf");

            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc => doc);
        }

        GraphArrayOperation<JsonDocument> ISlimGraphDevicesClient.GetTransitiveMemberOfAsync(IAzureTenant tenant, Guid deviceID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"devices/{deviceID}/transitiveMemberOf");

            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc => doc);
        }
    }
}