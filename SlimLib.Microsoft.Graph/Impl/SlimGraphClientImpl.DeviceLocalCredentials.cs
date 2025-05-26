using SlimLib.Auth.Azure;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SlimLib.Microsoft.Graph
{
    partial class SlimGraphClientImpl
    {
        Task<JsonDocument?> ISlimGraphDeviceLocalCredentialsClient.GetDeviceLocalCredentialAsync(IAzureTenant tenant, Guid deviceID, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"directory/deviceLocalCredentials/{deviceID}");

            return GetAsync(tenant, link, options, cancellationToken);
        }

        IAsyncEnumerable<JsonDocument> ISlimGraphDeviceLocalCredentialsClient.GetDeviceLocalCredentialsAsync(IAzureTenant tenant, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, "directory/deviceLocalCredentials");

            return GetArrayAsync(tenant, nextLink, options, cancellationToken);
        }
    }
}
