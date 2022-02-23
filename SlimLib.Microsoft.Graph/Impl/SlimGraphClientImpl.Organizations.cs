using SlimLib.Auth.Azure;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SlimLib.Microsoft.Graph
{
    partial class SlimGraphClientImpl
    {
        async Task<JsonElement> ISlimGraphOrganizationsClient.GetOrganizationAsync(IAzureTenant tenant, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, "organization");

            return await GetAsync(tenant, link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }
    }
}