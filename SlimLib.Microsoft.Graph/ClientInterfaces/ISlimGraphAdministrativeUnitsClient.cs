using SlimLib.Auth.Azure;
using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;

namespace SlimLib.Microsoft.Graph
{
    public interface ISlimGraphAdministrativeUnitsClient
    {
        Task<JsonElement> AddMemberAsync(IAzureTenant tenant, Guid adminUnitID, JsonObject data, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
    }
}