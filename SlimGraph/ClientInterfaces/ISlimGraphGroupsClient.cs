using SlimGraph.Auth;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SlimGraph
{
    public interface ISlimGraphGroupsClient
    {
        Task<JsonElement> CreateGroupAsync(IAzureTenant tenant, JsonElement data, InvokeRequestOptions options = default, CancellationToken cancellationToken = default);
        Task<JsonElement> GetGroupAsync(IAzureTenant tenant, Guid groupID, ScalarRequestOptions options = default, CancellationToken cancellationToken = default);
        Task DeleteGroupAsync(IAzureTenant tenant, Guid groupID, InvokeRequestOptions options = default, CancellationToken cancellationToken = default);

        Task<JsonElement> GetGroupPhotoAsync(IAzureTenant tenant, Guid groupID, string size = "", ScalarRequestOptions options = default, CancellationToken cancellationToken = default);
        Task<SlimGraphPicture?> GetGroupPhotoDataAsync(IAzureTenant tenant, Guid groupID, string size = "", ScalarRequestOptions options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonElement> GetGroupPhotosAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions options = default, CancellationToken cancellationToken = default);

        IAsyncEnumerable<JsonElement> GetGroupsAsync(IAzureTenant tenant, ListRequestOptions options = default, CancellationToken cancellationToken = default);
        Task<DeltaResult<JsonElement>> GetGroupsDeltaAsync(IAzureTenant tenant, DeltaRequestOptions options = default, CancellationToken cancellationToken = default);
        Task<DeltaResult<JsonElement>> GetGroupsDeltaChangeAsync(IAzureTenant tenant, string previousDeltaLink, DeltaRequestOptions options = default, CancellationToken cancellationToken = default);

        IAsyncEnumerable<JsonElement> GetMembersAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonElement> GetTransitiveMembersAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions options = default, CancellationToken cancellationToken = default);

        IAsyncEnumerable<JsonElement> GetMemberOfAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonElement> GetTransitiveMemberOfAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions options = default, CancellationToken cancellationToken = default);

        IAsyncEnumerable<Guid> GetMemberGroupsAsync(IAzureTenant tenant, Guid groupID, bool securityEnabledOnly, InvokeRequestOptions options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<Guid> GetMemberObjectsAsync(IAzureTenant tenant, Guid groupID, bool securityEnabledOnly, InvokeRequestOptions options = default, CancellationToken cancellationToken = default);

        Task AddMemberAsync(IAzureTenant tenant, Guid groupID, Guid memberID, InvokeRequestOptions options = default, CancellationToken cancellationToken = default);
        Task AddMembersAsync(IAzureTenant tenant, Guid groupID, IEnumerable<Guid> memberIDs, InvokeRequestOptions options = default, CancellationToken cancellationToken = default);
        Task RemoveMemberAsync(IAzureTenant tenant, Guid groupID, Guid memberID, InvokeRequestOptions options = default, CancellationToken cancellationToken = default);
    }
}