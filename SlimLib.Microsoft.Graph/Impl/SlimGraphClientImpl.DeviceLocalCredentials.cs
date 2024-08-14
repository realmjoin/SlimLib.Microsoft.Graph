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
        async Task<JsonDocument?> ISlimGraphDeviceLocalCredentialsClient.GetDeviceLocalCredentialAsync(IAzureTenant tenant, Guid deviceID, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"directory/deviceLocalCredentials/{deviceID}");

            //Throws an error wtihout a user agent
            return await GetAsync(tenant, link, new RequestHeaderOptions { UserAgent = "Mozilla/5.0 (Windows NT 10; Win64; x64; rv:60.0) Gecko/20100101 Firefox/60.0" }, cancellationToken).ConfigureAwait(false);
        }

        IAsyncEnumerable<JsonDocument> ISlimGraphDeviceLocalCredentialsClient.GetDeviceLocalCredentialsAsync(IAzureTenant tenant, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, "directory/deviceLocalCredentials");

            return GetArrayAsync(tenant, nextLink, options, cancellationToken);
        }
    }
}
