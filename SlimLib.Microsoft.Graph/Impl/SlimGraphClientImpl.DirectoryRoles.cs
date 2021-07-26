﻿using SlimLib.Auth.Azure;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SlimLib.Microsoft.Graph
{
    partial class SlimGraphClientImpl
    {
        async Task<JsonElement> ISlimGraphDirectoryRolesClient.GetDirectoryRoleAsync(IAzureTenant tenant, Guid directoryRoleID, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"directoryRoles/{directoryRoleID}");

            return await GetAsync(tenant, link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphDirectoryRolesClient.GetDirectoryRolesAsync(IAzureTenant tenant, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, "directoryRoles");

            await foreach (var item in GetArrayAsync(tenant, nextLink, options, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item;
            }
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphDirectoryRolesClient.GetMembersAsync(IAzureTenant tenant, Guid directoryRoleID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"directoryRoles/{directoryRoleID}/members");

            await foreach (var item in GetArrayAsync(tenant, nextLink, options, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item;
            }
        }
    }
}