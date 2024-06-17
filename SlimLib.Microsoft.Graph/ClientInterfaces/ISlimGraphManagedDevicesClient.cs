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
        Task<JsonDocument?> GetManagedDeviceAsync(IAzureTenant tenant, Guid deviceID, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
        [Obsolete("This API is limited to 50 items and does not support paging. Use /beta/deviceManagement/manageddevices/xxx?$expand=detectedApps as alternative.")]
        IAsyncEnumerable<JsonDocument> GetManagedDeviceDetectedAppsAsync(IAzureTenant tenant, Guid deviceID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<Guid[]> GetManagedDeviceUsersAsync(IAzureTenant tenant, Guid deviceID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<JsonDocument?> GetManagedDeviceOverviewAsync(IAzureTenant tenant, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonDocument> GetManagedDevicesAsync(IAzureTenant tenant, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonDocument> GetManagedDeviceEncryptionStatesAsync(IAzureTenant tenant, ListRequestOptions? options = default, CancellationToken cancellationToken = default);

        Task<JsonDocument?> GetWindowsAutopilotDeviceIdentityAsync(IAzureTenant tenant, Guid identityID, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonDocument> GetWindowsAutopilotDeviceIdentitiesAsync(IAzureTenant tenant, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<JsonDocument?> GetImportedWindowsAutopilotDeviceIdentityAsync(IAzureTenant tenant, Guid identityID, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonDocument> ImportWindowsAutopilotDeviceIdentityAsync(IAzureTenant tenant, ICollection<JsonObject> identities, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task DeleteWindowsAutopilotDeviceIdentityAsync(IAzureTenant tenant, Guid identityID, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);

        Task WipeManagedDeviceAsync(IAzureTenant tenant, Guid deviceID, JsonObject data, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonDocument> GetDeviceHealthScriptsAsync(IAzureTenant tenant, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<JsonDocument?> GetDeviceHealthScriptAsync(IAzureTenant tenant, string deviceHealthScriptId, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<JsonDocument?> CreateDeviceHealthScriptAsync(IAzureTenant tenant, JsonObject data, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<JsonDocument?> UpdateDeviceHealthScriptAsync(IAzureTenant tenant, string deviceHealthScriptId, JsonObject data, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task DeleteDeviceHealthScriptAsync(IAzureTenant tenant, string deviceHealthScriptId, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonDocument> GetDeviceHealthScriptAssignmentsAsync(IAzureTenant tenant, string deviceHealthScriptId, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonDocument> GetDeviceAndAppManagementAssignmentFiltersAsync(IAzureTenant tenant, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<JsonDocument?> GetDeviceAndAppManagementAssignmentFilterAsync(IAzureTenant tenant, string deviceAndAppManagementAssignmentFilterId, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<JsonDocument?> CreateDeviceAndAppManagementAssignmentFilterAsync(IAzureTenant tenant, JsonObject data, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<JsonDocument?> UpdateDeviceAndAppManagementAssignmentFilterAsync(IAzureTenant tenant, string deviceAndAppManagementAssignmentFilterId, JsonObject data, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task DeleteDeviceAndAppManagementAssignmentFilterAsync(IAzureTenant tenant, string deviceAndAppManagementAssignmentFilterId, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task AssignDeviceHealthScriptAsync(IAzureTenant tenant, string deviceHealthScriptId, JsonObject data, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<JsonDocument?> GetDeviceHealthScriptRemediationHistoryAsync(IAzureTenant tenant, string deviceHealthScriptId, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<JsonDocument?> GetDeviceHealthScriptRunSummaryAsync(IAzureTenant tenant, string deviceHealthScriptId, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task InitiateOnDemandProactiveRemediationAsync(IAzureTenant tenant, Guid deviceID, JsonObject data, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonDocument> GetRemoteActionAuditsAsync(IAzureTenant tenant, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonDocument> GetDeviceHealthScriptStatesAsync(IAzureTenant tenant, Guid deviceID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonDocument> GetDeviceRunStatesAsync(IAzureTenant tenant, string deviceHealthScriptId, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task RotateLocalAdminPasswordAsync(IAzureTenant tenant, Guid deviceID, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
    }
}