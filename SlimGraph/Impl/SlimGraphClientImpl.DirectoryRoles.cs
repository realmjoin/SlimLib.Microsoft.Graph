using SlimGraph.Auth;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SlimGraph
{
    partial class SlimGraphClientImpl
    {
        async Task<JsonElement> ISlimGraphDirectoryRolesClient.GetDirectoryRoleAsync(IAzureTenant tenant, Guid directoryRoleID, ScalarRequestOptions options, CancellationToken cancellationToken)
        {
            var link = options.BuildLink($"directoryRoles/{directoryRoleID}");

            return await GetAsync(tenant, link, cancellationToken).ConfigureAwait(false);
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphDirectoryRolesClient.GetDirectoryRolesAsync(IAzureTenant tenant, ListRequestOptions options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            string? nextLink = options.BuildLink("directoryRoles");

            do
            {
                var root = await GetAsync(tenant, nextLink, cancellationToken).ConfigureAwait(false);

                foreach (var item in root.GetProperty("value").EnumerateArray())
                {
                    if (cancellationToken.IsCancellationRequested)
                        yield break;

                    yield return item;
                }

                HandleNextLink(root, ref nextLink);

            } while (nextLink != null);
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphDirectoryRolesClient.GetMembersAsync(IAzureTenant tenant, Guid directoryRoleID, ListRequestOptions options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            string? nextLink = options.BuildLink($"directoryRoles/{directoryRoleID}/members");

            do
            {
                var root = await GetAsync(tenant, nextLink, cancellationToken).ConfigureAwait(false);

                foreach (var item in root.GetProperty("value").EnumerateArray())
                {
                    if (cancellationToken.IsCancellationRequested)
                        yield break;

                    yield return item;
                }

                HandleNextLink(root, ref nextLink);

            } while (nextLink != null);
        }
    }
}