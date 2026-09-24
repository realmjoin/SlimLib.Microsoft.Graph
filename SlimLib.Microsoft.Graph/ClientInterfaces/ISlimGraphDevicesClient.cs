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

        /// <summary>
        /// Starts a delta round: pages of changed objects, the last one carrying the <c>@odata.deltaLink</c> to
        /// continue from (see <see cref="Results.Delta.ODataDeltaListResponse{T}"/>). Pages are streamed, dispose each.
        /// </summary>
        GraphArrayOperation<JsonDocument> GetDevicesDeltaAsync(IAzureTenant tenant, DeltaRequestOptions? options = default, CancellationToken cancellationToken = default);

        /// <summary>
        /// Continues from the <c>@odata.deltaLink</c> of a previous round, same paging as <see cref="GetDevicesDeltaAsync"/>.
        /// </summary>
        GraphArrayOperation<JsonDocument> GetDevicesDeltaChangeAsync(IAzureTenant tenant, string previousDeltaLink, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);

        GraphArrayOperation<JsonDocument> GetRegisteredOwnersAsync(IAzureTenant tenant, Guid deviceID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphArrayOperation<JsonDocument> GetRegisteredUsersDeviceAsync(IAzureTenant tenant, Guid deviceID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);

        GraphArrayOperation<JsonDocument> GetMemberOfAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphArrayOperation<JsonDocument> GetTransitiveMemberOfAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
    }
}