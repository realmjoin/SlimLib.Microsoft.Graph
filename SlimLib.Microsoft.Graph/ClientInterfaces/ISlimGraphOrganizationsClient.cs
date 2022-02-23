using SlimLib.Auth.Azure;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SlimLib.Microsoft.Graph
{
    public interface ISlimGraphOrganizationsClient
    {
        Task<JsonElement> GetOrganizationAsync(IAzureTenant tenant, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
    }
}