using SlimLib.Auth.Azure;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;

namespace SlimLib.Microsoft.Graph
{
    public interface ISlimGraphGroupsClient : ISlimGraphDirectoryObjectsClient
    {
        Task<JsonDocument?> CreateGroupAsync(IAzureTenant tenant, JsonObject data, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<JsonDocument?> GetGroupAsync(IAzureTenant tenant, Guid groupID, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<JsonDocument?> UpdateGroupAsync(IAzureTenant tenant, Guid groupID, JsonObject data, InvokeRequestOptions? options, CancellationToken cancellationToken = default);
        Task DeleteGroupAsync(IAzureTenant tenant, Guid groupID, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);

        Task<JsonDocument?> GetGroupPhotoAsync(IAzureTenant tenant, Guid groupID, string size = "", ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<SlimGraphPicture?> GetGroupPhotoDataAsync(IAzureTenant tenant, Guid groupID, string size = "", ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonDocument> GetGroupPhotosAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);

        IAsyncEnumerable<JsonDocument> GetGroupsAsync(IAzureTenant tenant, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<Results.Delta.DeltaResult<JsonElement>> GetGroupsDeltaAsync(IAzureTenant tenant, DeltaRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<Results.Delta.DeltaResult<JsonElement>> GetGroupsDeltaChangeAsync(IAzureTenant tenant, string previousDeltaLink, DeltaRequestOptions? options = default, CancellationToken cancellationToken = default);

        IAsyncEnumerable<JsonDocument> GetOwnersAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonDocument> GetOwnersAsync(IAzureTenant tenant, Guid groupID, string type, ListRequestOptions? options = default, CancellationToken cancellationToken = default);

        IAsyncEnumerable<JsonDocument> GetMembersAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonDocument> GetMembersAsync(IAzureTenant tenant, Guid groupID, string type, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonDocument> GetTransitiveMembersAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonDocument> GetTransitiveMembersAsync(IAzureTenant tenant, Guid groupID, string type, ListRequestOptions? options = default, CancellationToken cancellationToken = default);

        IAsyncEnumerable<JsonDocument> GetMemberOfAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonDocument> GetTransitiveMemberOfAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);

        Task<JsonDocument?> AddMemberAsync(IAzureTenant tenant, Guid groupID, TypedMember member, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<JsonDocument?> AddMembersAsync(IAzureTenant tenant, Guid groupID, IEnumerable<TypedMember> members, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task RemoveMemberAsync(IAzureTenant tenant, Guid groupID, Guid memberID, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
    }
}