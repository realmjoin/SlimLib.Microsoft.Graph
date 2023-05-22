using SlimLib.Auth.Azure;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SlimLib.Microsoft.Graph
{
    partial class SlimGraphClientImpl
    {
        async Task<JsonElement> ISlimGraphAdministrativeUnitsClient.CreateGroupAsync(IAzureTenant tenant, Guid adminUnitID, JsonElement data, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"directory/administrativeUnits/{adminUnitID}/members");

            return await PostAsync(tenant, JsonSerializer.SerializeToUtf8Bytes(data), link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }
    }
}