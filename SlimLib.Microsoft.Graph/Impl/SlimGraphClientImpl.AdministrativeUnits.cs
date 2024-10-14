using SlimLib.Auth.Azure;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;

namespace SlimLib.Microsoft.Graph
{
    partial class SlimGraphClientImpl
    {
        async Task<JsonDocument?> ISlimGraphAdministrativeUnitsClient.AddMemberAsync(IAzureTenant tenant, Guid adminUnitID, JsonObject data, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"directory/administrativeUnits/{adminUnitID}/members");

            return await PostAsync(tenant, JsonSerializer.SerializeToUtf8Bytes(data), link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }

        async Task<JsonDocument?> ISlimGraphAdministrativeUnitsClient.GetMemberAsync(IAzureTenant tenant, Guid adminUnitID, Guid memberID, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"directory/administrativeUnits/{adminUnitID}/members/{memberID}");

            return await GetAsync(tenant, link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }

        IAsyncEnumerable<JsonDocument> ISlimGraphAdministrativeUnitsClient.GetMembersAsync(IAzureTenant tenant, Guid adminUnitID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"directory/administrativeUnits/{adminUnitID}/members");

            return GetArrayAsync(tenant, nextLink, options, cancellationToken);
        }

        IAsyncEnumerable<JsonDocument> ISlimGraphAdministrativeUnitsClient.GetMembersAsync(IAzureTenant tenant, Guid adminUnitID, string type, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"directory/administrativeUnits/{adminUnitID}/members/{type}");

            return GetArrayAsync(tenant, nextLink, options, cancellationToken);
        }
    }
}