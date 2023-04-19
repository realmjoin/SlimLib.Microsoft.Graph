using SlimLib.Auth.Azure;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SlimLib.Microsoft.Graph
{
    public interface ISlimGraphManagedDevicesClient
    {
        Task SyncManagedDeviceAsync(IAzureTenant tenant, Guid deviceID, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task WindowsDefenderScanManagedDeviceAsync(IAzureTenant tenant, Guid deviceID, bool quickScan, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<JsonElement> GetManagedDeviceAsync(IAzureTenant tenant, Guid deviceID, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
        [Obsolete("This API is limited to 50 items and does not support paging. Use /beta/deviceManagement/manageddevices/xxx?$expand=detectedApps as alternative.")]
        IAsyncEnumerable<JsonElement> GetManagedDeviceDetectedAppsAsync(IAzureTenant tenant, Guid deviceID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<Guid> GetManagedDeviceUsersAsync(IAzureTenant tenant, Guid deviceID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<JsonElement> GetManagedDeviceOverviewAsync(IAzureTenant tenant, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonElement> GetManagedDevicesAsync(IAzureTenant tenant, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonElement> GetManagedDeviceEncryptionStatesAsync(IAzureTenant tenant, ListRequestOptions? options = default, CancellationToken cancellationToken = default);

        Task<JsonElement> GetWindowsAutopilotDeviceIdentityAsync(IAzureTenant tenant, Guid identityID, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonElement> GetWindowsAutopilotDeviceIdentitiesAsync(IAzureTenant tenant, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<JsonElement> GetImportedWindowsAutopilotDeviceIdentityAsync(IAzureTenant tenant, Guid identityID, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonElement> ImportWindowsAutopilotDeviceIdentityAsync(IAzureTenant tenant, IEnumerable<JsonElement> identities, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task DeleteWindowsAutopilotDeviceIdentityAsync(IAzureTenant tenant, Guid identityID, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);

        Task WipeManagedDeviceAsync(IAzureTenant tenant, Guid deviceID, JsonElement data, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonElement> GetDeviceHealthScriptsAsync(IAzureTenant tenant, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<JsonElement> GetDeviceHealthScriptAsync(IAzureTenant tenant, string deviceHealthScriptId, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<JsonElement> CreateDeviceHealthScriptAsync(IAzureTenant tenant, JsonElement data, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<JsonElement> UpdateDeviceHealthScriptAsync(IAzureTenant tenant, string deviceHealthScriptId, JsonElement data, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task DeleteDeviceHealthScriptAsync(IAzureTenant tenant, string deviceHealthScriptId, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task AssignDeviceHealthScriptAsync(IAzureTenant tenant, string deviceHealthScriptId, JsonElement data, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
    }
}