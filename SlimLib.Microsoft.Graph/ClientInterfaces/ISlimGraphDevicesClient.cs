using SlimLib.Auth.Azure;
using System;
using System.Text.Json;
using System.Threading;

namespace SlimLib.Microsoft.Graph
{
    public interface ISlimGraphDevicesClient : ISlimGraphDirectoryObjectsClient
    {
        GraphOperation<JsonDocument?> GetDeviceAsync(IAzureTenant tenant, Guid deviceID, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);

        GraphArrayOperation<JsonDocument> GetDevicesAsync(IAzureTenant tenant, ListRequestOptions? options = default, CancellationToken cancellationToken = default);

        GraphArrayOperation<JsonDocument> GetRegisteredOwnersAsync(IAzureTenant tenant, Guid deviceID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphArrayOperation<JsonDocument> GetRegisteredUsersDeviceAsync(IAzureTenant tenant, Guid deviceID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);

        GraphArrayOperation<JsonDocument> GetMemberOfAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphArrayOperation<JsonDocument> GetTransitiveMemberOfAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
    }
}