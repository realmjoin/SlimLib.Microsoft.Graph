using SlimLib.Auth.Azure;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SlimLib.Microsoft.Graph
{
    public interface ISlimGraphAdministrativeUnitsClient
    {
        Task<JsonElement> CreateGroupAsync(IAzureTenant tenant, Guid adminUnitID, JsonElement data, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
    }
}