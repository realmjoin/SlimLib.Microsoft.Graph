using SlimLib.Auth.Azure;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
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

            using var doc = await PostAsync(tenant, null, link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }

        async Task ISlimGraphManagedDevicesClient.WindowsDefenderScanManagedDeviceAsync(IAzureTenant tenant, Guid deviceID, bool quickScan, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceManagement/managedDevices/{deviceID}/windowsDefenderScan");

            var data = new JsonObject
            {
                ["quickScan"] = quickScan
            };

            using var doc = await PostAsync(tenant, JsonSerializer.SerializeToUtf8Bytes(data), link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }

        async Task<JsonDocument?> ISlimGraphManagedDevicesClient.GetManagedDeviceAsync(IAzureTenant tenant, Guid deviceID, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceManagement/managedDevices/{deviceID}");

            return await GetAsync(tenant, link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }

        [Obsolete("This API is limited to 50 items and does not support paging. Use /beta/deviceManagement/manageddevices/xxx?$expand=detectedApps as alternative.")]
        IAsyncEnumerable<JsonDocument> ISlimGraphManagedDevicesClient.GetManagedDeviceDetectedAppsAsync(IAzureTenant tenant, Guid deviceID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"deviceManagement/managedDevices/{deviceID}/detectedApps");

            return GetArrayAsync(tenant, nextLink, options, cancellationToken);
        }

        async IAsyncEnumerable<Guid[]> ISlimGraphManagedDevicesClient.GetManagedDeviceUsersAsync(IAzureTenant tenant, Guid deviceID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"deviceManagement/managedDevices/{deviceID}/users");

            await foreach (var doc in GetArrayAsync(tenant, nextLink, options, cancellationToken))
            {
                using (doc)
                {
                    if (cancellationToken.IsCancellationRequested)
                        yield break;

                    yield return doc.RootElement
                        .GetProperty("value")
                        .EnumerateArray()
                        .Select(x => x.GetProperty("id").GetGuid())
                        .ToArray();
                }
            }
        }

        async Task<JsonDocument?> ISlimGraphManagedDevicesClient.GetManagedDeviceOverviewAsync(IAzureTenant tenant, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceManagement/managedDeviceOverview");

            return await GetAsync(tenant, link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }

        IAsyncEnumerable<JsonDocument> ISlimGraphManagedDevicesClient.GetManagedDevicesAsync(IAzureTenant tenant, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, "deviceManagement/managedDevices");

            return GetArrayAsync(tenant, nextLink, options, cancellationToken);
        }

        IAsyncEnumerable<JsonDocument> ISlimGraphManagedDevicesClient.GetManagedDeviceEncryptionStatesAsync(IAzureTenant tenant, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, "deviceManagement/managedDeviceEncryptionStates");

            return GetArrayAsync(tenant, nextLink, options, cancellationToken);
        }


        async Task<JsonDocument?> ISlimGraphManagedDevicesClient.GetWindowsAutopilotDeviceIdentityAsync(IAzureTenant tenant, Guid identityID, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceManagement/windowsAutopilotDeviceIdentities/{identityID}");

            return await GetAsync(tenant, link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }

        IAsyncEnumerable<JsonDocument> ISlimGraphManagedDevicesClient.GetWindowsAutopilotDeviceIdentitiesAsync(IAzureTenant tenant, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, "deviceManagement/windowsAutopilotDeviceIdentities");

            return GetArrayAsync(tenant, nextLink, options, cancellationToken);
        }

        async Task<JsonDocument?> ISlimGraphManagedDevicesClient.GetImportedWindowsAutopilotDeviceIdentityAsync(IAzureTenant tenant, Guid identityID, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceManagement/importedWindowsAutopilotDeviceIdentities/{identityID}");

            return await GetAsync(tenant, link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }

        IAsyncEnumerable<JsonDocument> ISlimGraphManagedDevicesClient.ImportWindowsAutopilotDeviceIdentityAsync(IAzureTenant tenant, ICollection<JsonObject> identities, InvokeRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, "deviceManagement/importedWindowsAutopilotDeviceIdentities/import");

            var data = new JsonObject
            {
                ["importedWindowsAutopilotDeviceIdentities"] = new JsonArray(identities.ToArray())
            };

            return PostArrayAsync(tenant, JsonSerializer.SerializeToUtf8Bytes(data), nextLink, new RequestHeaderOptions(), cancellationToken);
        }

        async Task ISlimGraphManagedDevicesClient.DeleteWindowsAutopilotDeviceIdentityAsync(IAzureTenant tenant, Guid identityID, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceManagement/windowsAutopilotDeviceIdentities/{identityID}");

            await DeleteAsync(tenant, link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }


        async Task ISlimGraphManagedDevicesClient.WipeManagedDeviceAsync(IAzureTenant tenant, Guid deviceID, JsonObject data, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceManagement/managedDevices/{deviceID}/wipe");

            using var doc = await PostAsync(tenant, JsonSerializer.SerializeToUtf8Bytes(data), link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }

        IAsyncEnumerable<JsonDocument> ISlimGraphManagedDevicesClient.GetDeviceHealthScriptsAsync(IAzureTenant tenant, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, "deviceManagement/deviceHealthScripts");

            return GetArrayAsync(tenant, nextLink, options, cancellationToken);
        }
        async Task<JsonDocument?> ISlimGraphManagedDevicesClient.GetDeviceHealthScriptAsync(IAzureTenant tenant, string deviceHealthScriptId, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceManagement/deviceHealthScripts/{deviceHealthScriptId}");
            return await GetAsync(tenant, link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }
        async Task<JsonDocument?> ISlimGraphManagedDevicesClient.CreateDeviceHealthScriptAsync(IAzureTenant tenant, JsonObject data, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, "deviceManagement/deviceHealthScripts");
            return await PostAsync(tenant, JsonSerializer.SerializeToUtf8Bytes(data), link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }
        async Task<JsonDocument?> ISlimGraphManagedDevicesClient.UpdateDeviceHealthScriptAsync(IAzureTenant tenant, string deviceHealthScriptId, JsonObject data, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceManagement/deviceHealthScripts/{deviceHealthScriptId}");
            return await PatchAsync(tenant, JsonSerializer.SerializeToUtf8Bytes(data), link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }
        async Task ISlimGraphManagedDevicesClient.DeleteDeviceHealthScriptAsync(IAzureTenant tenant, string deviceHealthScriptId, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceManagement/deviceHealthScripts/{deviceHealthScriptId}");
            await DeleteAsync(tenant, link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }
        async Task ISlimGraphManagedDevicesClient.AssignDeviceHealthScriptAsync(IAzureTenant tenant, string deviceHealthScriptId, JsonObject data, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceManagement/deviceHealthScripts/{deviceHealthScriptId}/assign");
            using var doc = await PostAsync(tenant, JsonSerializer.SerializeToUtf8Bytes(data), link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }
        IAsyncEnumerable<JsonDocument> ISlimGraphManagedDevicesClient.GetDeviceHealthScriptAssignmentsAsync(IAzureTenant tenant, string deviceHealthScriptId, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"deviceManagement/deviceHealthScripts/{deviceHealthScriptId}/assignments");

            return GetArrayAsync(tenant, nextLink, options, cancellationToken);
        }
        IAsyncEnumerable<JsonDocument> ISlimGraphManagedDevicesClient.GetDeviceAndAppManagementAssignmentFiltersAsync(IAzureTenant tenant, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, "deviceManagement/assignmentFilters");

            return GetArrayAsync(tenant, nextLink, options, cancellationToken);
        }
        async Task<JsonDocument?> ISlimGraphManagedDevicesClient.GetDeviceAndAppManagementAssignmentFilterAsync(IAzureTenant tenant, string deviceAndAppManagementAssignmentFilterId, InvokeRequestOptions? options, System.Threading.CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceManagement/assignmentFilters/{deviceAndAppManagementAssignmentFilterId}");
            return await GetAsync(tenant, link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }
        async Task<JsonDocument?> ISlimGraphManagedDevicesClient.CreateDeviceAndAppManagementAssignmentFilterAsync(IAzureTenant tenant, JsonObject data, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, "deviceManagement/assignmentFilters");
            return await PostAsync(tenant, JsonSerializer.SerializeToUtf8Bytes(data), link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }
        async Task<JsonDocument?> ISlimGraphManagedDevicesClient.UpdateDeviceAndAppManagementAssignmentFilterAsync(IAzureTenant tenant, string deviceAndAppManagementAssignmentFilterId, JsonObject data, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceManagement/assignmentFilters/{deviceAndAppManagementAssignmentFilterId}");
            return await PatchAsync(tenant, JsonSerializer.SerializeToUtf8Bytes(data), link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }
        async Task ISlimGraphManagedDevicesClient.DeleteDeviceAndAppManagementAssignmentFilterAsync(IAzureTenant tenant, string deviceAndAppManagementAssignmentFilterId, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceManagement/assignmentFilters/{deviceAndAppManagementAssignmentFilterId}");
            await DeleteAsync(tenant, link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }
        async Task<JsonDocument?> ISlimGraphManagedDevicesClient.GetDeviceHealthScriptRemediationHistoryAsync(IAzureTenant tenant, string deviceHealthScriptId, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceManagement/deviceHealthScripts/{deviceHealthScriptId}/getRemediationHistory");
            return await GetAsync(tenant, link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }
        async Task<JsonDocument?> ISlimGraphManagedDevicesClient.GetDeviceHealthScriptRunSummaryAsync(IAzureTenant tenant, string deviceHealthScriptId, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceManagement/deviceHealthScripts/{deviceHealthScriptId}/runSummary");
            return await GetAsync(tenant, link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }
        async Task ISlimGraphManagedDevicesClient.InitiateOnDemandProactiveRemediationAsync(IAzureTenant tenant, Guid deviceID, JsonObject data, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceManagement/managedDevices/{deviceID}/initiateOnDemandProactiveRemediation");

            using var doc = await PostAsync(tenant, JsonSerializer.SerializeToUtf8Bytes(data), link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }
        IAsyncEnumerable<JsonDocument> ISlimGraphManagedDevicesClient.GetRemoteActionAuditsAsync(IAzureTenant tenant, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"deviceManagement/remoteActionAudits");
            return GetArrayAsync(tenant, nextLink, options, cancellationToken);
        }
        IAsyncEnumerable<JsonDocument> ISlimGraphManagedDevicesClient.GetDeviceHealthScriptStatesAsync(IAzureTenant tenant, Guid deviceID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"deviceManagement/managedDevices/{deviceID}/deviceHealthScriptStates");
            return GetArrayAsync(tenant, nextLink, options, cancellationToken);
        }
        IAsyncEnumerable<JsonDocument> ISlimGraphManagedDevicesClient.GetDeviceRunStatesAsync(IAzureTenant tenant, string deviceHealthScriptId, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"deviceManagement/deviceHealthScripts/{deviceHealthScriptId}/deviceRunStates");
            return GetArrayAsync(tenant, nextLink, options, cancellationToken);
        }
        async Task ISlimGraphManagedDevicesClient.RotateLocalAdminPasswordAsync(IAzureTenant tenant, Guid deviceID, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceManagement/managedDevices/{deviceID}/rotateLocalAdminPassword");

            using var doc = await PostAsync(tenant, null, link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }
    }
}