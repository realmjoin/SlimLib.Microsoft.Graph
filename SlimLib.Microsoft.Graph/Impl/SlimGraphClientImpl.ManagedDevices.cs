using SlimLib.Auth.Azure;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SlimLib.Microsoft.Graph
{
    partial class SlimGraphClientImpl
    {
        async Task ISlimGraphManagedDevicesClient.SyncManagedDeviceAsync(IAzureTenant tenant, Guid deviceID, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceManagement/managedDevices/{deviceID}/syncDevice");

            await PostAsync(tenant, null, link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }

        async Task ISlimGraphManagedDevicesClient.WindowsDefenderScanManagedDeviceAsync(IAzureTenant tenant, Guid deviceID, bool quickScan, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceManagement/managedDevices/{deviceID}/windowsDefenderScan");

            var buffer = new ArrayBufferWriter<byte>();
            using (var writer = new Utf8JsonWriter(buffer))
            {
                writer.WriteStartObject();
                writer.WriteBoolean("quickScan", quickScan);
                writer.WriteEndObject();
            }

            await PostAsync(tenant, buffer.WrittenMemory, link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }

        async Task<JsonElement> ISlimGraphManagedDevicesClient.GetManagedDeviceAsync(IAzureTenant tenant, Guid deviceID, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceManagement/managedDevices/{deviceID}");

            return await GetAsync(tenant, link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }

        [Obsolete("This API is limited to 50 items and does not support paging. Use /beta/deviceManagement/manageddevices/xxx?$expand=detectedApps as alternative.")]
        async IAsyncEnumerable<JsonElement> ISlimGraphManagedDevicesClient.GetManagedDeviceDetectedAppsAsync(IAzureTenant tenant, Guid deviceID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"deviceManagement/managedDevices/{deviceID}/detectedApps");

            await foreach (var item in GetArrayAsync(tenant, nextLink, options, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item;
            }
        }

        async IAsyncEnumerable<Guid> ISlimGraphManagedDevicesClient.GetManagedDeviceUsersAsync(IAzureTenant tenant, Guid deviceID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"deviceManagement/managedDevices/{deviceID}/users");

            await foreach (var item in GetArrayAsync(tenant, nextLink, options, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item.GetProperty("id").GetGuid();
            }
        }

        async Task<JsonElement> ISlimGraphManagedDevicesClient.GetManagedDeviceOverviewAsync(IAzureTenant tenant, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceManagement/managedDeviceOverview");

            return await GetAsync(tenant, link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphManagedDevicesClient.GetManagedDevicesAsync(IAzureTenant tenant, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, "deviceManagement/managedDevices");

            await foreach (var item in GetArrayAsync(tenant, nextLink, options, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item;
            }
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphManagedDevicesClient.GetManagedDeviceEncryptionStatesAsync(IAzureTenant tenant, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, "deviceManagement/managedDeviceEncryptionStates");

            await foreach (var item in GetArrayAsync(tenant, nextLink, options, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item;
            }
        }


        async Task<JsonElement> ISlimGraphManagedDevicesClient.GetWindowsAutopilotDeviceIdentityAsync(IAzureTenant tenant, Guid identityID, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceManagement/windowsAutopilotDeviceIdentities/{identityID}");

            return await GetAsync(tenant, link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphManagedDevicesClient.GetWindowsAutopilotDeviceIdentitiesAsync(IAzureTenant tenant, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, "deviceManagement/windowsAutopilotDeviceIdentities");

            await foreach (var item in GetArrayAsync(tenant, nextLink, options, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item;
            }
        }

        async Task<JsonElement> ISlimGraphManagedDevicesClient.GetImportedWindowsAutopilotDeviceIdentityAsync(IAzureTenant tenant, Guid identityID, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceManagement/importedWindowsAutopilotDeviceIdentities/{identityID}");

            return await GetAsync(tenant, link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphManagedDevicesClient.ImportWindowsAutopilotDeviceIdentityAsync(IAzureTenant tenant, IEnumerable<JsonElement> identities, InvokeRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, "deviceManagement/importedWindowsAutopilotDeviceIdentities/import");

            var buffer = new ArrayBufferWriter<byte>();
            using (var writer = new Utf8JsonWriter(buffer))
            {
                writer.WriteStartObject();
                writer.WriteStartArray("importedWindowsAutopilotDeviceIdentities");

                foreach (var identity in identities)
                {
                    identity.WriteTo(writer);
                }

                writer.WriteEndArray();
                writer.WriteEndObject();
            }

            await foreach (var item in PostArrayAsync(tenant, buffer.WrittenMemory, nextLink, new RequestHeaderOptions(), cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item;
            }
        }

        async Task ISlimGraphManagedDevicesClient.DeleteWindowsAutopilotDeviceIdentityAsync(IAzureTenant tenant, Guid identityID, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceManagement/windowsAutopilotDeviceIdentities/{identityID}");

            await DeleteAsync(tenant, link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }


        async Task ISlimGraphManagedDevicesClient.WipeManagedDeviceAsync(IAzureTenant tenant, Guid deviceID, JsonElement data, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceManagement/managedDevices/{deviceID}/wipe");

            await PostAsync(tenant, JsonSerializer.SerializeToUtf8Bytes(data), link,  new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }
    }
}