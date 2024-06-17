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
        Task<JsonDocument?> GetUserAsync(IAzureTenant tenant, Guid userID, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);

        Task<JsonDocument?> GetUserPhotoAsync(IAzureTenant tenant, Guid userID, string size = "", ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<SlimGraphPicture?> GetUserPhotoDataAsync(IAzureTenant tenant, Guid userID, string size = "", ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonDocument> GetUserPhotosAsync(IAzureTenant tenant, Guid userID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonDocument> GetUserAppRoleAssignmentsAsync(IAzureTenant tenant, Guid userID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);

        IAsyncEnumerable<JsonDocument> GetUsersAsync(IAzureTenant tenant, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<Results.Delta.DeltaResult<JsonElement>> GetUsersDeltaAsync(IAzureTenant tenant, DeltaRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<Results.Delta.DeltaResult<JsonElement>> GetUsersDeltaChangeAsync(IAzureTenant tenant, string previousDeltaLink, DeltaRequestOptions? options = default, CancellationToken cancellationToken = default);

        IAsyncEnumerable<JsonDocument> GetMemberOfAsync(IAzureTenant tenant, Guid userID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonDocument> GetTransitiveMemberOfAsync(IAzureTenant tenant, Guid userID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);

        IAsyncEnumerable<JsonDocument> GetOwnedDevicesAsync(IAzureTenant tenant, Guid userID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonDocument> GetRegisteredDevicesAsync(IAzureTenant tenant, Guid userID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);

        IAsyncEnumerable<Guid[]> CheckMemberGroupsAsync(IAzureTenant tenant, string userPrincipalName, ICollection<Guid> groupIDs, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<Guid[]> GetMemberGroupsAsync(IAzureTenant tenant, string userPrincipalName, bool securityEnabledOnly, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);

        IAsyncEnumerable<Guid[]> CheckMemberObjectsAsync(IAzureTenant tenant, string userPrincipalName, ICollection<Guid> groupIDs, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<Guid[]> GetMemberObjectsAsync(IAzureTenant tenant, string userPrincipalName, bool securityEnabledOnly, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
    }
}