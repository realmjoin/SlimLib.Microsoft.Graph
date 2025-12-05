using SlimLib.Auth.Azure;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;

namespace SlimLib.Microsoft.Graph
{
    partial class SlimGraphClientImpl
    {
        GraphOperation<JsonDocument?> ISlimGraphWindowsDeviceUpdatesClient.GetEnrollmentStateAsync(IAzureTenant tenant, Guid deviceID, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"admin/windows/updates/updatableAssets/{deviceID}");

            return new(this, tenant, HttpMethod.Get, link, options, static doc => doc);
        }
    }
}
