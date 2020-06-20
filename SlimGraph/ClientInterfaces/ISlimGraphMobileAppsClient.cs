using SlimGraph.Auth;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SlimGraph
{
    public interface ISlimGraphMobileAppsClient
    {
        Task<JsonElement> GetMobileAppAsync(IAzureTenant tenant, Guid appID, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<JsonElement> CreateMobileAppAsync(IAzureTenant tenant, JsonElement data, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task UpdateMobileAppAsync(IAzureTenant tenant, Guid appID, JsonElement data, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task DeleteMobileAppAsync(IAzureTenant tenant, Guid appID, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);

        IAsyncEnumerable<JsonElement> GetMobileAppsAsync(IAzureTenant tenant, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonElement> GetMobileAppDeviceStatusesAsync(IAzureTenant tenant, Guid appID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonElement> GetMobileAppUserStatusesAsync(IAzureTenant tenant, Guid appID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);

        Task<JsonElement> GetMobileAppContentAsync(IAzureTenant tenant, Guid appID, string type, string mobileAppContentID, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<string> CreateMobileAppContentAsync(IAzureTenant tenant, Guid appID, string type, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task CommitMobileAppContentAsync(IAzureTenant tenant, Guid appID, string type, string mobileAppContentID, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);

        Task<JsonElement> GetMobileAppContentFilesAsync(IAzureTenant tenant, Guid appID, string type, string mobileAppContentID, Guid mobileAppContentFileID, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<JsonElement> CreateMobileAppContentFilesAsync(IAzureTenant tenant, Guid appID, string type, string mobileAppContentID, JsonElement data, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task CommitMobileAppContentFilesAsync(IAzureTenant tenant, Guid appID, string type, string mobileAppContentID, Guid mobileAppContentFileID, JsonElement data, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);

        Task AssignMobileAppAsync(IAzureTenant tenant, Guid appID, JsonElement data, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
    }
}