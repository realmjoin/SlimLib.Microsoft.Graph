using SlimLib.Auth.Azure;
using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;

namespace SlimLib.Microsoft.Graph
{
    partial class SlimGraphClientImpl
    {
        GraphOperation<JsonDocument?> ISlimGraphAdministrativeUnitsClient.AddMemberAsync(IAzureTenant tenant, Guid adminUnitID, JsonObject data, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"directory/administrativeUnits/{adminUnitID}/members");

            return new(this, tenant, HttpMethod.Post, link, options, JsonSerializer.SerializeToUtf8Bytes(data), static doc => doc);
        }

        GraphOperation<JsonDocument?> ISlimGraphAdministrativeUnitsClient.GetMemberAsync(IAzureTenant tenant, Guid adminUnitID, Guid memberID, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"directory/administrativeUnits/{adminUnitID}/members/{memberID}");

            return new(this, tenant, HttpMethod.Get, link, options, static doc => doc);
        }

        GraphArrayOperation<JsonDocument> ISlimGraphAdministrativeUnitsClient.GetMembersAsync(IAzureTenant tenant, Guid adminUnitID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"directory/administrativeUnits/{adminUnitID}/members");

            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc => doc);
        }

        GraphArrayOperation<JsonDocument> ISlimGraphAdministrativeUnitsClient.GetMembersAsync(IAzureTenant tenant, Guid adminUnitID, string type, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"directory/administrativeUnits/{adminUnitID}/members/{type}");

            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc => doc);
        }
    }
}