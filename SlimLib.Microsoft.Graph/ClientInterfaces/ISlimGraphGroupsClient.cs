﻿using SlimLib.Auth.Azure;
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
        Task<JsonElement> CreateGroupAsync(IAzureTenant tenant, JsonObject data, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<JsonElement> GetGroupAsync(IAzureTenant tenant, Guid groupID, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<JsonElement> UpdateGroupAsync(IAzureTenant tenant, Guid groupID, JsonObject data, InvokeRequestOptions? options, CancellationToken cancellationToken = default);
        Task DeleteGroupAsync(IAzureTenant tenant, Guid groupID, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);

        Task<JsonElement> GetGroupPhotoAsync(IAzureTenant tenant, Guid groupID, string size = "", ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<SlimGraphPicture?> GetGroupPhotoDataAsync(IAzureTenant tenant, Guid groupID, string size = "", ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonElement> GetGroupPhotosAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);

        IAsyncEnumerable<JsonElement> GetGroupsAsync(IAzureTenant tenant, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<Results.Delta.DeltaResult<JsonElement>> GetGroupsDeltaAsync(IAzureTenant tenant, DeltaRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<Results.Delta.DeltaResult<JsonElement>> GetGroupsDeltaChangeAsync(IAzureTenant tenant, string previousDeltaLink, DeltaRequestOptions? options = default, CancellationToken cancellationToken = default);

        IAsyncEnumerable<JsonElement> GetOwnersAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonElement> GetOwnersAsync(IAzureTenant tenant, Guid groupID, string type, ListRequestOptions? options = default, CancellationToken cancellationToken = default);

        IAsyncEnumerable<JsonElement> GetMembersAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonElement> GetMembersAsync(IAzureTenant tenant, Guid groupID, string type, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonElement> GetTransitiveMembersAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonElement> GetTransitiveMembersAsync(IAzureTenant tenant, Guid groupID, string type, ListRequestOptions? options = default, CancellationToken cancellationToken = default);

        IAsyncEnumerable<JsonElement> GetMemberOfAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonElement> GetTransitiveMemberOfAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);

        Task<JsonElement> AddMemberAsync(IAzureTenant tenant, Guid groupID, TypedMember member, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<JsonElement> AddMembersAsync(IAzureTenant tenant, Guid groupID, IEnumerable<TypedMember> members, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task RemoveMemberAsync(IAzureTenant tenant, Guid groupID, Guid memberID, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
    }
}