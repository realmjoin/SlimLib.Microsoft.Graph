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
        Task<JsonElement> GetGroupAsync(IAzureTenant tenant, Guid groupID, ScalarRequestOptions options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonElement> GetGroupsAsync(IAzureTenant tenant, ListRequestOptions options = default, CancellationToken cancellationToken = default);
        Task<DeltaResult<JsonElement>> GetGroupsDeltaAsync(IAzureTenant tenant, DeltaRequestOptions options = default, CancellationToken cancellationToken = default);
        Task<DeltaResult<JsonElement>> GetGroupsDeltaChangeAsync(IAzureTenant tenant, string previousDeltaLink, DeltaRequestOptions options = default, CancellationToken cancellationToken = default);

        IAsyncEnumerable<JsonElement> GetMembersAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonElement> GetTransitiveMembersAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions options = default, CancellationToken cancellationToken = default);

        IAsyncEnumerable<JsonElement> GetMemberOfAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonElement> GetTransitiveMemberOfAsync(IAzureTenant tenant, Guid groupID, ListRequestOptions options = default, CancellationToken cancellationToken = default);

        IAsyncEnumerable<Guid> GetMemberGroupsAsync(IAzureTenant tenant, Guid groupID, bool securityEnabledOnly, InvokeRequestOptions options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<Guid> GetMemberObjectsAsync(IAzureTenant tenant, Guid groupID, bool securityEnabledOnly, InvokeRequestOptions options = default, CancellationToken cancellationToken = default);
    }
}