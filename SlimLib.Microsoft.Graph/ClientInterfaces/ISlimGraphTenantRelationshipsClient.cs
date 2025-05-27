using SlimLib.Auth.Azure;
using System.Text.Json;
using System.Threading;

namespace SlimLib.Microsoft.Graph
{
    public interface ISlimGraphTenantRelationshipsClient
    {
        GraphArrayOperation<JsonDocument> GetDelegatedAdminRelationshipsAsync(IAzureTenant tenant, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
    }
}
