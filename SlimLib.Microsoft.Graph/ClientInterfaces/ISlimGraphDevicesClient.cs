using SlimLib.Auth.Azure;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SlimLib.Microsoft.Graph
{
    public interface ISlimGraphDevicesClient : ISlimGraphDirectoryObjectsClient
    {
        Task<JsonElement> GetDeviceAsync(IAzureTenant tenant, Guid deviceID, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);

        IAsyncEnumerable<JsonElement> GetDevicesAsync(IAzureTenant tenant, ListRequestOptions? options = default, CancellationToken cancellationToken = default);

        IAsyncEnumerable<JsonElement> GetRegisteredOwnersAsync(IAzureTenant tenant, Guid deviceID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonElement> GetRegisteredUsersDeviceAsync(IAzureTenant tenant, Guid deviceID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);

        IAsyncEnumerable<JsonElement> GetMemberOfAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonElement> GetTransitiveMemberOfAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
    }
}