using SlimLib.Auth.Azure;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SlimLib.Microsoft.Graph
{
    public interface ISlimGraphUsersClient : ISlimGraphDirectoryObjectsClient
    {
        GraphOperation<JsonDocument?> GetUserAsync(IAzureTenant tenant, string userPrincipalName, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);

        GraphOperation<JsonDocument?> GetUserAsync(IAzureTenant tenant, Guid userID, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);

        GraphOperation<JsonDocument?> GetUserPhotoAsync(IAzureTenant tenant, Guid userID, string size = "", ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<SlimGraphPicture?> GetUserPhotoDataAsync(IAzureTenant tenant, Guid userID, string size = "", ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphArrayOperation<JsonDocument> GetUserPhotosAsync(IAzureTenant tenant, Guid userID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphArrayOperation<JsonDocument> GetUserAppRoleAssignmentsAsync(IAzureTenant tenant, Guid userID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);

        GraphArrayOperation<JsonDocument> GetUsersAsync(IAzureTenant tenant, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<Results.Delta.DeltaResult<JsonElement>> GetUsersDeltaAsync(IAzureTenant tenant, DeltaRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<Results.Delta.DeltaResult<JsonElement>> GetUsersDeltaChangeAsync(IAzureTenant tenant, string previousDeltaLink, DeltaRequestOptions? options = default, CancellationToken cancellationToken = default);

        GraphArrayOperation<JsonDocument> GetMemberOfAsync(IAzureTenant tenant, Guid userID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphArrayOperation<JsonDocument> GetTransitiveMemberOfAsync(IAzureTenant tenant, Guid userID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);

        GraphArrayOperation<JsonDocument> GetOwnedDevicesAsync(IAzureTenant tenant, Guid userID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphArrayOperation<JsonDocument> GetRegisteredDevicesAsync(IAzureTenant tenant, Guid userID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);

        GraphArrayOperation<Guid[]> CheckMemberGroupsAsync(IAzureTenant tenant, string userPrincipalName, ICollection<Guid> groupIDs, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphArrayOperation<Guid[]> GetMemberGroupsAsync(IAzureTenant tenant, string userPrincipalName, bool securityEnabledOnly, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);

        GraphArrayOperation<Guid[]> CheckMemberObjectsAsync(IAzureTenant tenant, string userPrincipalName, ICollection<Guid> groupIDs, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphArrayOperation<Guid[]> GetMemberObjectsAsync(IAzureTenant tenant, string userPrincipalName, bool securityEnabledOnly, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
    }
}