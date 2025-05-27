using SlimLib.Auth.Azure;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;

namespace SlimLib.Microsoft.Graph
{
    partial class SlimGraphClientImpl
    {
        async Task ISlimGraphManagedDevicesClient.SyncManagedDeviceAsync(IAzureTenant tenant, Guid deviceID, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceManagement/managedDevices/{deviceID}/syncDevice");

            using var doc = await PostAsync(tenant, link, utf8Data: default, options, cancellationToken).ConfigureAwait(false);
        }

        async Task ISlimGraphManagedDevicesClient.WindowsDefenderScanManagedDeviceAsync(IAzureTenant tenant, Guid deviceID, bool quickScan, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceManagement/managedDevices/{deviceID}/windowsDefenderScan");

            var data = new JsonObject
            {
                ["quickScan"] = quickScan
            };

            using var doc = await PostAsync(tenant, link, JsonSerializer.SerializeToUtf8Bytes(data), options, cancellationToken).ConfigureAwait(false);
        }

        GraphOperation<JsonDocument?> ISlimGraphManagedDevicesClient.GetManagedDeviceAsync(IAzureTenant tenant, Guid deviceID, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceManagement/managedDevices/{deviceID}");

            return new(this, tenant, HttpMethod.Get, link, options, static doc => doc);
        }

        [Obsolete("This API is limited to 50 items and does not support paging. Use /beta/deviceManagement/manageddevices/xxx?$expand=detectedApps as alternative.")]
        GraphArrayOperation<JsonDocument> ISlimGraphManagedDevicesClient.GetManagedDeviceDetectedAppsAsync(IAzureTenant tenant, Guid deviceID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"deviceManagement/managedDevices/{deviceID}/detectedApps");

            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc => doc);
        }

        GraphArrayOperation<Guid[]> ISlimGraphManagedDevicesClient.GetManagedDeviceUsersAsync(IAzureTenant tenant, Guid deviceID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"deviceManagement/managedDevices/{deviceID}/users");

            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc =>
            {
                using (doc)
                {
                    return [.. doc.RootElement.GetProperty("value").EnumerateArray().Select(x => x.GetProperty("id").GetGuid())];
                }
            });
        }

        GraphOperation<JsonDocument?> ISlimGraphManagedDevicesClient.GetManagedDeviceOverviewAsync(IAzureTenant tenant, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceManagement/managedDeviceOverview");

            return new(this, tenant, HttpMethod.Get, link, options, static doc => doc);
        }

        GraphArrayOperation<JsonDocument> ISlimGraphManagedDevicesClient.GetManagedDevicesAsync(IAzureTenant tenant, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, "deviceManagement/managedDevices");

            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc => doc);
        }

        GraphArrayOperation<JsonDocument> ISlimGraphManagedDevicesClient.GetManagedDeviceEncryptionStatesAsync(IAzureTenant tenant, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, "deviceManagement/managedDeviceEncryptionStates");

            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc => doc);
        }


        GraphOperation<JsonDocument?> ISlimGraphManagedDevicesClient.GetWindowsAutopilotDeviceIdentityAsync(IAzureTenant tenant, Guid identityID, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceManagement/windowsAutopilotDeviceIdentities/{identityID}");

            return new(this, tenant, HttpMethod.Get, link, options, static doc => doc);
        }

        GraphArrayOperation<JsonDocument> ISlimGraphManagedDevicesClient.GetWindowsAutopilotDeviceIdentitiesAsync(IAzureTenant tenant, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, "deviceManagement/windowsAutopilotDeviceIdentities");

            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc => doc);
        }

        GraphOperation<JsonDocument?> ISlimGraphManagedDevicesClient.GetImportedWindowsAutopilotDeviceIdentityAsync(IAzureTenant tenant, Guid identityID, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceManagement/importedWindowsAutopilotDeviceIdentities/{identityID}");

            return new(this, tenant, HttpMethod.Get, link, options, static doc => doc);
        }

        GraphArrayOperation<JsonDocument> ISlimGraphManagedDevicesClient.ImportWindowsAutopilotDeviceIdentityAsync(IAzureTenant tenant, ICollection<JsonObject> identities, InvokeRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, "deviceManagement/importedWindowsAutopilotDeviceIdentities/import");

            var data = new JsonObject
            {
                ["importedWindowsAutopilotDeviceIdentities"] = new JsonArray(identities.ToArray())
            };

            return new(this, tenant, HttpMethod.Post, nextLink, options, JsonSerializer.SerializeToUtf8Bytes(data), static doc => doc);
        }

        GraphOperation ISlimGraphManagedDevicesClient.DeleteWindowsAutopilotDeviceIdentityAsync(IAzureTenant tenant, Guid identityID, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceManagement/windowsAutopilotDeviceIdentities/{identityID}");

            return new(this, tenant, HttpMethod.Delete, link, options);
        }


        GraphOperation ISlimGraphManagedDevicesClient.WipeManagedDeviceAsync(IAzureTenant tenant, Guid deviceID, JsonObject data, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceManagement/managedDevices/{deviceID}/wipe");

            return new(this, tenant, HttpMethod.Post, link, options, JsonSerializer.SerializeToUtf8Bytes(data));
        }

        GraphArrayOperation<JsonDocument> ISlimGraphManagedDevicesClient.GetDeviceHealthScriptsAsync(IAzureTenant tenant, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, "deviceManagement/deviceHealthScripts");

            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc => doc);
        }
        GraphOperation<JsonDocument?> ISlimGraphManagedDevicesClient.GetDeviceHealthScriptAsync(IAzureTenant tenant, string deviceHealthScriptId, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceManagement/deviceHealthScripts/{deviceHealthScriptId}");
            return new(this, tenant, HttpMethod.Get, link, options, static doc => doc);
        }
        GraphOperation<JsonDocument?> ISlimGraphManagedDevicesClient.CreateDeviceHealthScriptAsync(IAzureTenant tenant, JsonObject data, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, "deviceManagement/deviceHealthScripts");
            return new (this, tenant, HttpMethod.Post, link, options, JsonSerializer.SerializeToUtf8Bytes(data), static doc => doc);
        }
        GraphOperation<JsonDocument?> ISlimGraphManagedDevicesClient.UpdateDeviceHealthScriptAsync(IAzureTenant tenant, string deviceHealthScriptId, JsonObject data, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceManagement/deviceHealthScripts/{deviceHealthScriptId}");
            return new (this, tenant, HttpMethod.Patch, link, options, JsonSerializer.SerializeToUtf8Bytes(data), static doc => doc);
        }
        GraphOperation ISlimGraphManagedDevicesClient.DeleteDeviceHealthScriptAsync(IAzureTenant tenant, string deviceHealthScriptId, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceManagement/deviceHealthScripts/{deviceHealthScriptId}");
            return new(this, tenant, HttpMethod.Delete, link, options);
        }
        GraphOperation ISlimGraphManagedDevicesClient.AssignDeviceHealthScriptAsync(IAzureTenant tenant, string deviceHealthScriptId, JsonObject data, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceManagement/deviceHealthScripts/{deviceHealthScriptId}/assign");
            return new(this, tenant, HttpMethod.Post, link, options, JsonSerializer.SerializeToUtf8Bytes(data));
        }
        GraphArrayOperation<JsonDocument> ISlimGraphManagedDevicesClient.GetDeviceHealthScriptAssignmentsAsync(IAzureTenant tenant, string deviceHealthScriptId, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"deviceManagement/deviceHealthScripts/{deviceHealthScriptId}/assignments");

            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc => doc);
        }
        GraphArrayOperation<JsonDocument> ISlimGraphManagedDevicesClient.GetDeviceAndAppManagementAssignmentFiltersAsync(IAzureTenant tenant, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, "deviceManagement/assignmentFilters");

            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc => doc);
        }
        GraphOperation<JsonDocument?> ISlimGraphManagedDevicesClient.GetDeviceAndAppManagementAssignmentFilterAsync(IAzureTenant tenant, string deviceAndAppManagementAssignmentFilterId, InvokeRequestOptions? options, System.Threading.CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceManagement/assignmentFilters/{deviceAndAppManagementAssignmentFilterId}");
            return new(this, tenant, HttpMethod.Get, link, options, static doc => doc);
        }
        GraphOperation<JsonDocument?> ISlimGraphManagedDevicesClient.CreateDeviceAndAppManagementAssignmentFilterAsync(IAzureTenant tenant, JsonObject data, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, "deviceManagement/assignmentFilters");
            return new(this, tenant, HttpMethod.Post, link, options, JsonSerializer.SerializeToUtf8Bytes(data), static doc => doc);
        }
        GraphOperation<JsonDocument?> ISlimGraphManagedDevicesClient.UpdateDeviceAndAppManagementAssignmentFilterAsync(IAzureTenant tenant, string deviceAndAppManagementAssignmentFilterId, JsonObject data, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceManagement/assignmentFilters/{deviceAndAppManagementAssignmentFilterId}");
            return new(this, tenant, HttpMethod.Patch, link, options, JsonSerializer.SerializeToUtf8Bytes(data), static doc => doc);
        }
        GraphOperation ISlimGraphManagedDevicesClient.DeleteDeviceAndAppManagementAssignmentFilterAsync(IAzureTenant tenant, string deviceAndAppManagementAssignmentFilterId, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceManagement/assignmentFilters/{deviceAndAppManagementAssignmentFilterId}");
            return new(this, tenant, HttpMethod.Delete, link, options);
        }
        GraphOperation<JsonDocument?> ISlimGraphManagedDevicesClient.GetDeviceHealthScriptRemediationHistoryAsync(IAzureTenant tenant, string deviceHealthScriptId, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceManagement/deviceHealthScripts/{deviceHealthScriptId}/getRemediationHistory");
            return new(this, tenant, HttpMethod.Get, link, options, static doc => doc);
        }
        GraphOperation<JsonDocument?> ISlimGraphManagedDevicesClient.GetDeviceHealthScriptRunSummaryAsync(IAzureTenant tenant, string deviceHealthScriptId, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceManagement/deviceHealthScripts/{deviceHealthScriptId}/runSummary");
            return new(this, tenant, HttpMethod.Get, link, options, static doc => doc);
        }
        GraphOperation ISlimGraphManagedDevicesClient.InitiateOnDemandProactiveRemediationAsync(IAzureTenant tenant, Guid deviceID, JsonObject data, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceManagement/managedDevices/{deviceID}/initiateOnDemandProactiveRemediation");

            return new(this, tenant, HttpMethod.Post, link, options, JsonSerializer.SerializeToUtf8Bytes(data));
        }
        GraphArrayOperation<JsonDocument> ISlimGraphManagedDevicesClient.GetRemoteActionAuditsAsync(IAzureTenant tenant, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"deviceManagement/remoteActionAudits");
            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc => doc);
        }
        GraphArrayOperation<JsonDocument> ISlimGraphManagedDevicesClient.GetDeviceHealthScriptStatesAsync(IAzureTenant tenant, Guid deviceID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"deviceManagement/managedDevices/{deviceID}/deviceHealthScriptStates");
            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc => doc);
        }
        GraphArrayOperation<JsonDocument> ISlimGraphManagedDevicesClient.GetDeviceRunStatesAsync(IAzureTenant tenant, string deviceHealthScriptId, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"deviceManagement/deviceHealthScripts/{deviceHealthScriptId}/deviceRunStates");
            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc => doc);
        }
        GraphOperation ISlimGraphManagedDevicesClient.RotateLocalAdminPasswordAsync(IAzureTenant tenant, Guid deviceID, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceManagement/managedDevices/{deviceID}/rotateLocalAdminPassword");

            return new(this, tenant, HttpMethod.Post, link, options);
        }
    }
}