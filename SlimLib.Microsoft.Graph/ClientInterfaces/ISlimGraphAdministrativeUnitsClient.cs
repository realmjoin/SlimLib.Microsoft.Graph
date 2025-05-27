using SlimLib.Auth.Azure;
using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;

namespace SlimLib.Microsoft.Graph
{
    public interface ISlimGraphAdministrativeUnitsClient
    {
        GraphOperation<JsonDocument?> AddMemberAsync(IAzureTenant tenant, Guid adminUnitID, JsonObject data, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);

        GraphOperation<JsonDocument?> GetMemberAsync(IAzureTenant tenant, Guid adminUnitID, Guid memberID, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);

        GraphArrayOperation<JsonDocument> GetMembersAsync(IAzureTenant tenant, Guid adminUnitID, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphArrayOperation<JsonDocument> GetMembersAsync(IAzureTenant tenant, Guid adminUnitID, string type, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
    }
}