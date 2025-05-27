using SlimLib.Auth.Azure;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;

namespace SlimLib.Microsoft.Graph
{
    partial class SlimGraphClientImpl
    {
        GraphOperation<JsonDocument?> ISlimGraphDetectedAppsClient.GetDetectedAppAsync(IAzureTenant tenant, string appID, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceManagement/detectedApps/{appID}");

            return new(this, tenant, HttpMethod.Get, link, options, static doc => doc);
        }

        GraphArrayOperation<JsonDocument> ISlimGraphDetectedAppsClient.GetDetectedAppsAsync(IAzureTenant tenant, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, "deviceManagement/detectedApps");

            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc => doc);
        }

        GraphArrayOperation<JsonDocument> ISlimGraphDetectedAppsClient.GetManagedDevicesAsync(IAzureTenant tenant, string appID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"deviceManagement/detectedApps/{appID}/managedDevices");

            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc => doc);
        }
    }
}