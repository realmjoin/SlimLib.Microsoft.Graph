using SlimLib.Auth.Azure;
using System;
using System.Text.Json;
using System.Threading;

namespace SlimLib.Microsoft.Graph
{
    public interface ISlimGraphWindowsDeviceUpdatesClient
    {
        GraphOperation<JsonDocument?> GetEnrollmentStateAsync(IAzureTenant tenant, Guid deviceID, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
    }
}
