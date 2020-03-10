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
        async Task<JsonElement> ISlimGraphDevicesClient.GetDeviceAsync(IAzureTenant tenant, Guid deviceID, ScalarRequestOptions options, CancellationToken cancellationToken)
        {
            var link = options.BuildLink($"devices/{deviceID}");

            return await GetAsync(tenant, link, cancellationToken).ConfigureAwait(false);
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphDevicesClient.GetDevicesAsync(IAzureTenant tenant, ListRequestOptions options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            string? nextLink = options.BuildLink("devices");

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