using SlimLib.Auth.Azure;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;
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
        IAsyncEnumerable<JsonElement> ImportWindowsAutopilotDeviceIdentityAsync(IAzureTenant tenant, ICollection<JsonObject> identities, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task DeleteWindowsAutopilotDeviceIdentityAsync(IAzureTenant tenant, Guid identityID, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);

        Task WipeManagedDeviceAsync(IAzureTenant tenant, Guid deviceID, JsonObject data, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonElement> GetDeviceHealthScriptsAsync(IAzureTenant tenant, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<JsonElement> GetDeviceHealthScriptAsync(IAzureTenant tenant, string deviceHealthScriptId, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<JsonElement> CreateDeviceHealthScriptAsync(IAzureTenant tenant, JsonObject data, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<JsonElement> UpdateDeviceHealthScriptAsync(IAzureTenant tenant, string deviceHealthScriptId, JsonObject data, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task DeleteDeviceHealthScriptAsync(IAzureTenant tenant, string deviceHealthScriptId, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonElement> GetDeviceHealthScriptAssignmentsAsync(IAzureTenant tenant, string deviceHealthScriptId, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonElement> GetDeviceAndAppManagementAssignmentFiltersAsync(IAzureTenant tenant, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<JsonElement> GetDeviceAndAppManagementAssignmentFilterAsync(IAzureTenant tenant, string deviceAndAppManagementAssignmentFilterId, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<JsonElement> CreateDeviceAndAppManagementAssignmentFilterAsync(IAzureTenant tenant, JsonObject data, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<JsonElement> UpdateDeviceAndAppManagementAssignmentFilterAsync(IAzureTenant tenant, string deviceAndAppManagementAssignmentFilterId, JsonObject data, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task DeleteDeviceAndAppManagementAssignmentFilterAsync(IAzureTenant tenant, string deviceAndAppManagementAssignmentFilterId, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task AssignDeviceHealthScriptAsync(IAzureTenant tenant, string deviceHealthScriptId, JsonObject data, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<JsonElement> GetDeviceHealthScriptRemediationHistoryAsync(IAzureTenant tenant, string deviceHealthScriptId, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<JsonElement> GetDeviceHealthScriptRunSummaryAsync(IAzureTenant tenant, string deviceHealthScriptId, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
    }
}