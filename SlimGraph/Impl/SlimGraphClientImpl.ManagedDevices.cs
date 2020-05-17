using SlimGraph.Auth;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SlimGraph
{
    partial class SlimGraphClientImpl
    {
        async Task ISlimGraphManagedDevicesClient.SyncManagedDeviceAsync(IAzureTenant tenant, Guid deviceID, ScalarRequestOptions options, CancellationToken cancellationToken)
        {
            var link = options.BuildLink($"deviceManagement/managedDevices/{deviceID}/syncDevice");

            await PostAsync(tenant, null, link, cancellationToken).ConfigureAwait(false);
        }

        async Task ISlimGraphManagedDevicesClient.WindowsDefenderScanManagedDeviceAsync(IAzureTenant tenant, Guid deviceID, bool quickScan, ScalarRequestOptions options, CancellationToken cancellationToken)
        {
            var link = options.BuildLink($"deviceManagement/managedDevices/{deviceID}/windowsDefenderScan");

            var buffer = new ArrayBufferWriter<byte>();
            using (var writer = new Utf8JsonWriter(buffer))
            {
                writer.WriteStartObject();
                writer.WriteBoolean("quickScan", quickScan);
                writer.WriteEndObject();
            }

            await PostAsync(tenant, buffer.WrittenMemory, link, cancellationToken).ConfigureAwait(false);
        }

        async Task<JsonElement> ISlimGraphManagedDevicesClient.GetManagedDeviceAsync(IAzureTenant tenant, Guid deviceID, ScalarRequestOptions options, CancellationToken cancellationToken)
        {
            var link = options.BuildLink($"deviceManagement/managedDevices/{deviceID}");

            return await GetAsync(tenant, link, cancellationToken).ConfigureAwait(false);
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphManagedDevicesClient.GetManagedDeviceDetectedAppsAsync(IAzureTenant tenant, Guid deviceID, ListRequestOptions options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = options.BuildLink($"deviceManagement/managedDevices/{deviceID}/detectedApps");

            await foreach (var item in GetArrayAsync(tenant, nextLink, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item;
            }
        }

        async IAsyncEnumerable<Guid> ISlimGraphManagedDevicesClient.GetManagedDeviceUsersAsync(IAzureTenant tenant, Guid deviceID, ListRequestOptions options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = options.BuildLink($"deviceManagement/managedDevices/{deviceID}/users");

            await foreach (var item in GetArrayAsync(tenant, nextLink, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item.GetProperty("id").GetGuid();
            }
        }

        async Task<JsonElement> ISlimGraphManagedDevicesClient.GetManagedDeviceOverviewAsync(IAzureTenant tenant, ScalarRequestOptions options, CancellationToken cancellationToken)
        {
            var link = options.BuildLink($"deviceManagement/managedDeviceOverview");

            return await GetAsync(tenant, link, cancellationToken).ConfigureAwait(false);
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphManagedDevicesClient.GetManagedDevicesAsync(IAzureTenant tenant, ListRequestOptions options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = options.BuildLink("deviceManagement/managedDevices");

            await foreach (var item in GetArrayAsync(tenant, nextLink, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item;
            }
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphManagedDevicesClient.GetManagedDeviceEncryptionStatesAsync(IAzureTenant tenant, ListRequestOptions options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = options.BuildLink("deviceManagement/managedDeviceEncryptionStates");

            await foreach (var item in GetArrayAsync(tenant, nextLink, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item;
            }
        }
    }
}