using SlimLib.Auth.Azure;
using System;
using System.Text.Json;
using System.Threading;

namespace SlimLib.Microsoft.Graph
{
    public interface ISlimGraphDeviceLocalCredentialsClient
    {
        GraphOperation<JsonDocument?> GetDeviceLocalCredentialAsync(IAzureTenant tenant, Guid deviceID, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphArrayOperation<JsonDocument> GetDeviceLocalCredentialsAsync(IAzureTenant tenant, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
    }
}
