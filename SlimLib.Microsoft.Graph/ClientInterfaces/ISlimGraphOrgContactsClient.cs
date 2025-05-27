using SlimLib.Auth.Azure;
using System;
using System.Text.Json;
using System.Threading;

namespace SlimLib.Microsoft.Graph
{
    public interface ISlimGraphOrgContactsClient : ISlimGraphDirectoryObjectsClient
    {
        GraphOperation<JsonDocument?> GetOrgContactAsync(IAzureTenant tenant, Guid contactID, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);

        GraphArrayOperation<JsonDocument> GetOrgContactsAsync(IAzureTenant tenant, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
    }
}