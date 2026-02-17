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
        GraphOperation<JsonDocument?> GetManagedDeviceAsync(IAzureTenant tenant, Guid deviceID, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
        [Obsolete("This API is limited to 50 items and does not support paging. Use /beta/deviceManagement/manageddevices/xxx?$expand=detectedApps as alternative.")]
        GraphArrayOperation<JsonDocument> GetManagedDeviceDetectedAppsAsync(IAzureTenant tenant, Guid deviceID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphArrayOperation<Guid[]> GetManagedDeviceUsersAsync(IAzureTenant tenant, Guid deviceID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphOperation<JsonDocument?> GetManagedDeviceOverviewAsync(IAzureTenant tenant, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphArrayOperation<JsonDocument> GetManagedDevicesAsync(IAzureTenant tenant, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphArrayOperation<JsonDocument> GetManagedDeviceEncryptionStatesAsync(IAzureTenant tenant, ListRequestOptions? options = default, CancellationToken cancellationToken = default);

        GraphOperation<JsonDocument?> GetWindowsAutopilotDeviceIdentityAsync(IAzureTenant tenant, Guid identityID, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphArrayOperation<JsonDocument> GetWindowsAutopilotDeviceIdentitiesAsync(IAzureTenant tenant, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphOperation<JsonDocument?> GetImportedWindowsAutopilotDeviceIdentityAsync(IAzureTenant tenant, Guid identityID, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphArrayOperation<JsonDocument> ImportWindowsAutopilotDeviceIdentityAsync(IAzureTenant tenant, ICollection<JsonObject> identities, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphOperation DeleteWindowsAutopilotDeviceIdentityAsync(IAzureTenant tenant, Guid identityID, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);

        GraphOperation WipeManagedDeviceAsync(IAzureTenant tenant, Guid deviceID, JsonObject data, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphArrayOperation<JsonDocument> GetDeviceHealthScriptsAsync(IAzureTenant tenant, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphOperation<JsonDocument?> GetDeviceHealthScriptAsync(IAzureTenant tenant, string deviceHealthScriptId, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphOperation<JsonDocument?> CreateDeviceHealthScriptAsync(IAzureTenant tenant, JsonObject data, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphOperation<JsonDocument?> UpdateDeviceHealthScriptAsync(IAzureTenant tenant, string deviceHealthScriptId, JsonObject data, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphOperation DeleteDeviceHealthScriptAsync(IAzureTenant tenant, string deviceHealthScriptId, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphArrayOperation<JsonDocument> GetDeviceHealthScriptAssignmentsAsync(IAzureTenant tenant, string deviceHealthScriptId, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphArrayOperation<JsonDocument> GetDeviceAndAppManagementAssignmentFiltersAsync(IAzureTenant tenant, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphOperation<JsonDocument?> GetDeviceAndAppManagementAssignmentFilterAsync(IAzureTenant tenant, string deviceAndAppManagementAssignmentFilterId, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphOperation<JsonDocument?> CreateDeviceAndAppManagementAssignmentFilterAsync(IAzureTenant tenant, JsonObject data, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphOperation<JsonDocument?> UpdateDeviceAndAppManagementAssignmentFilterAsync(IAzureTenant tenant, string deviceAndAppManagementAssignmentFilterId, JsonObject data, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphOperation DeleteDeviceAndAppManagementAssignmentFilterAsync(IAzureTenant tenant, string deviceAndAppManagementAssignmentFilterId, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphOperation AssignDeviceHealthScriptAsync(IAzureTenant tenant, string deviceHealthScriptId, JsonObject data, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphOperation<JsonDocument?> GetDeviceHealthScriptRemediationHistoryAsync(IAzureTenant tenant, string deviceHealthScriptId, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphOperation<JsonDocument?> GetDeviceHealthScriptRunSummaryAsync(IAzureTenant tenant, string deviceHealthScriptId, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphOperation InitiateOnDemandProactiveRemediationAsync(IAzureTenant tenant, Guid deviceID, JsonObject data, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphArrayOperation<JsonDocument> GetRemoteActionAuditsAsync(IAzureTenant tenant, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphArrayOperation<JsonDocument> GetDeviceHealthScriptStatesAsync(IAzureTenant tenant, Guid deviceID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphArrayOperation<JsonDocument> GetDeviceRunStatesAsync(IAzureTenant tenant, string deviceHealthScriptId, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphOperation RotateLocalAdminPasswordAsync(IAzureTenant tenant, Guid deviceID, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphOperation<JsonDocument?> RetrieveMacOSManagedDeviceLocalAdminAccountDetailAsync(IAzureTenant tenant, Guid deviceID, ScalarRequestOptions? options, CancellationToken cancellationToken = default);
        GraphOperation<JsonDocument?> GetFileVaultKeyAsync(IAzureTenant tenant, Guid deviceID, ScalarRequestOptions? options, CancellationToken cancellationToken = default);
        GraphOperation RotateFileVaultKeyAsync(IAzureTenant tenant, Guid deviceID, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
    }
}