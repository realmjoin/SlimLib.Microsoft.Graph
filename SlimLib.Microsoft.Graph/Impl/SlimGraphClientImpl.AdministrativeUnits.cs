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
        async Task<JsonElement> ISlimGraphAdministrativeUnitsClient.AddMemberAsync(IAzureTenant tenant, Guid adminUnitID, JsonObject data, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"directory/administrativeUnits/{adminUnitID}/members");

            return await PostAsync(tenant, JsonSerializer.SerializeToUtf8Bytes(data), link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphAdministrativeUnitsClient.GetMembersAsync(IAzureTenant tenant, Guid adminUnitID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"directory/administrativeUnits/{adminUnitID}/members");

            await foreach (var item in GetArrayAsync(tenant, nextLink, options, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item;
            }
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphAdministrativeUnitsClient.GetMembersAsync(IAzureTenant tenant, Guid adminUnitID, string type, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"directory/administrativeUnits/{adminUnitID}/members/{type}");

            await foreach (var item in GetArrayAsync(tenant, nextLink, options, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item;
            }
        }
    }
}