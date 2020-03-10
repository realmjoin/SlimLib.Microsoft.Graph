using SlimGraph.Auth;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SlimGraph
{
    partial class SlimGraphClientImpl
    {
        async Task<JsonElement> ISlimGraphManagedDevicesClient.GetManagedDeviceAsync(IAzureTenant tenant, Guid deviceID, ScalarRequestOptions options, CancellationToken cancellationToken)
        {
            var link = options.BuildLink($"deviceManagement/managedDevices/{deviceID}");

            return await GetAsync(tenant, link, cancellationToken).ConfigureAwait(false);
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphManagedDevicesClient.GetManagedDevicesAsync(IAzureTenant tenant, ListRequestOptions options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            string? nextLink = options.BuildLink("deviceManagement/managedDevices");

            do
            {
                var root = await GetAsync(tenant, nextLink, cancellationToken).ConfigureAwait(false);

                foreach (var item in root.GetProperty("value").EnumerateArray())
                {
                    if (cancellationToken.IsCancellationRequested)
                        yield break;

                    yield return item;
                }

                HandleNextLink(root, ref nextLink);

            } while (nextLink != null);
        }
    }
}