using SlimLib.Auth.Azure;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SlimLib.Microsoft.Graph
{
    partial class SlimGraphClientImpl
    {
        async Task<JsonDocument?> ISlimGraphDetectedAppsClient.GetDetectedAppAsync(IAzureTenant tenant, string appID, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceManagement/detectedApps/{appID}");

            return await GetAsync(tenant, link, new RequestHeaderOptions(), null, cancellationToken).ConfigureAwait(false);
        }

        IAsyncEnumerable<JsonDocument> ISlimGraphDetectedAppsClient.GetDetectedAppsAsync(IAzureTenant tenant, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, "deviceManagement/detectedApps");

            return GetArrayAsync(tenant, nextLink, options, cancellationToken);
        }

        IAsyncEnumerable<JsonDocument> ISlimGraphDetectedAppsClient.GetManagedDevicesAsync(IAzureTenant tenant, string appID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"deviceManagement/detectedApps/{appID}/managedDevices");

            return GetArrayAsync(tenant, nextLink, options, cancellationToken);
        }
    }
}