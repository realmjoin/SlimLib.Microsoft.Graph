using SlimGraph.Auth;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SlimGraph
{
    public interface ISlimGraphUsersClient
    {
        Task<JsonElement> GetUserAsync(IAzureTenant tenant, Guid userID, ScalarRequestOptions options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonElement> GetUsersAsync(IAzureTenant tenant, ListRequestOptions options = default, CancellationToken cancellationToken = default);
        Task<DeltaResult<JsonElement>> GetUsersDeltaAsync(IAzureTenant tenant, DeltaRequestOptions options = default, CancellationToken cancellationToken = default);
        Task<DeltaResult<JsonElement>> GetUsersDeltaChangeAsync(IAzureTenant tenant, string previousDeltaLink, DeltaRequestOptions options = default, CancellationToken cancellationToken = default);

        IAsyncEnumerable<Guid> GetMemberGroupsAsync(IAzureTenant tenant, Guid userID, bool securityEnabledOnly, InvokeRequestOptions options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<Guid> GetMemberObjectsAsync(IAzureTenant tenant, Guid userID, bool securityEnabledOnly, InvokeRequestOptions options = default, CancellationToken cancellationToken = default);

        IAsyncEnumerable<Guid> GetMemberGroupsAsync(IAzureTenant tenant, string userPrincipalName, bool securityEnabledOnly, InvokeRequestOptions options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<Guid> GetMemberObjectsAsync(IAzureTenant tenant, string userPrincipalName, bool securityEnabledOnly, InvokeRequestOptions options = default, CancellationToken cancellationToken = default);
    }
}