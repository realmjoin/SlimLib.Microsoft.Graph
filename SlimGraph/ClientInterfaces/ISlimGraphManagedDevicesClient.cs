using SlimGraph.Auth;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SlimGraph
{
    public interface ISlimGraphManagedDevicesClient
    {
        Task<JsonElement> GetManagedDeviceAsync(IAzureTenant tenant, Guid deviceID, ScalarRequestOptions options = default, CancellationToken cancellationToken = default);
        Task<JsonElement> GetManagedDeviceOverviewAsync(IAzureTenant tenant, ScalarRequestOptions options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonElement> GetManagedDevicesAsync(IAzureTenant tenant, ListRequestOptions options = default, CancellationToken cancellationToken = default);
        IAsyncEnumerable<JsonElement> GetManagedDeviceEncryptionStatesAsync(IAzureTenant tenant, ListRequestOptions options = default, CancellationToken cancellationToken = default);
    }
}