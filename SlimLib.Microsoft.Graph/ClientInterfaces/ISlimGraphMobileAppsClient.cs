using SlimLib.Auth.Azure;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;

namespace SlimLib.Microsoft.Graph
{
    public interface ISlimGraphMobileAppsClient
    {
        Task<JsonElement> GetMobileAppAsync(IAzureTenant tenant, Guid appID, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<JsonElement> CreateMobileAppAsync(IAzureTenant tenant, JsonObject data, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<JsonElement> UpdateMobileAppAsync(IAzureTenant tenant, Guid appID, JsonObject data, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task DeleteMobileAppAsync(IAzureTenant tenant, Guid appID, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);

        IAsyncEnumerable<JsonElement> GetMobileAppsAsync(IAzureTenant tenant, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonElement> GetMobileAppAssignmentsAsync(IAzureTenant tenant, Guid appID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);

        Task<JsonElement> GetMobileAppContentAsync(IAzureTenant tenant, Guid appID, string type, string mobileAppContentID, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<string> CreateMobileAppContentAsync(IAzureTenant tenant, Guid appID, string type, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task CommitMobileAppContentAsync(IAzureTenant tenant, Guid appID, string type, string mobileAppContentID, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);

        Task<JsonElement> GetMobileAppContentFilesAsync(IAzureTenant tenant, Guid appID, string type, string mobileAppContentID, Guid mobileAppContentFileID, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<JsonElement> CreateMobileAppContentFilesAsync(IAzureTenant tenant, Guid appID, string type, string mobileAppContentID, JsonObject data, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task CommitMobileAppContentFilesAsync(IAzureTenant tenant, Guid appID, string type, string mobileAppContentID, Guid mobileAppContentFileID, JsonObject data, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);

        Task AssignMobileAppAsync(IAzureTenant tenant, Guid appID, JsonObject data, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
    }
}