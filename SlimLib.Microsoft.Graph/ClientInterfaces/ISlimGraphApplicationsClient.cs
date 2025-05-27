using SlimLib.Auth.Azure;
using System;
using System.Text.Json;
using System.Threading;

namespace SlimLib.Microsoft.Graph
{
    public interface ISlimGraphApplicationsClient
    {
        GraphOperation<JsonDocument?> GetApplicationAsync(IAzureTenant tenant, Guid id, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphArrayOperation<JsonDocument> GetApplicationsAsync(IAzureTenant tenant, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
    }
}