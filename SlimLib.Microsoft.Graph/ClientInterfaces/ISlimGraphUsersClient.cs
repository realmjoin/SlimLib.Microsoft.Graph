using SlimLib.Auth.Azure;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SlimLib.Microsoft.Graph
{
    public interface ISlimGraphUsersClient
    {
        Task<JsonElement> GetUserAsync(IAzureTenant tenant, Guid userID, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);

        Task<JsonElement> GetUserPhotoAsync(IAzureTenant tenant, Guid userID, string size = "", ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<SlimGraphPicture?> GetUserPhotoDataAsync(IAzureTenant tenant, Guid userID, string size = "", ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonElement> GetUserPhotosAsync(IAzureTenant tenant, Guid userID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);

        IAsyncEnumerable<JsonElement> GetUsersAsync(IAzureTenant tenant, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<DeltaResult<JsonElement>> GetUsersDeltaAsync(IAzureTenant tenant, DeltaRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<DeltaResult<JsonElement>> GetUsersDeltaChangeAsync(IAzureTenant tenant, string previousDeltaLink, DeltaRequestOptions? options = default, CancellationToken cancellationToken = default);

        IAsyncEnumerable<JsonElement> GetMemberOfAsync(IAzureTenant tenant, Guid userID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);

        IAsyncEnumerable<JsonElement> GetOwnedDevicesAsync(IAzureTenant tenant, Guid userID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonElement> GetRegisteredDevicesAsync(IAzureTenant tenant, Guid userID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);

        IAsyncEnumerable<Guid> GetMemberGroupsAsync(IAzureTenant tenant, Guid userID, bool securityEnabledOnly, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<Guid> GetMemberObjectsAsync(IAzureTenant tenant, Guid userID, bool securityEnabledOnly, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);

        IAsyncEnumerable<Guid> GetMemberGroupsAsync(IAzureTenant tenant, string userPrincipalName, bool securityEnabledOnly, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<Guid> GetMemberObjectsAsync(IAzureTenant tenant, string userPrincipalName, bool securityEnabledOnly, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
    }
}