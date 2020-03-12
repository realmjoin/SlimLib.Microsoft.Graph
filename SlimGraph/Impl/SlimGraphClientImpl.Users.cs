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
        async Task<JsonElement> ISlimGraphUsersClient.GetUserAsync(IAzureTenant tenant, Guid userID, ScalarRequestOptions options, CancellationToken cancellationToken)
        {
            var link = options.BuildLink($"users/{userID}");

            return await GetAsync(tenant, link, cancellationToken).ConfigureAwait(false);
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphUsersClient.GetUsersAsync(IAzureTenant tenant, ListRequestOptions options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            string? nextLink = options.BuildLink("users");

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

        async Task<DeltaResult<JsonElement>> ISlimGraphUsersClient.GetUsersDeltaAsync(IAzureTenant tenant, DeltaRequestOptions options, CancellationToken cancellationToken)
        {
            var result = new List<JsonElement>();

            string? nextLink = options.BuildLink("users/delta");
            string? deltaLink = default;

            do
            {
                var root = await GetAsync(tenant, nextLink, cancellationToken, preferMinimal: options.PreferMinimal).ConfigureAwait(false);

                foreach (var item in root.GetProperty("value").EnumerateArray())
                {
                    if (cancellationToken.IsCancellationRequested)
                        return new DeltaResult<JsonElement>(result, deltaLink);

                    result.Add(item);
                }

                HandleNextLink(root, ref nextLink);
                HandleDeltaLink(root, ref deltaLink);

            } while (nextLink != null);

            return new DeltaResult<JsonElement>(result, deltaLink);
        }

        async Task<DeltaResult<JsonElement>> ISlimGraphUsersClient.GetUsersDeltaChangeAsync(IAzureTenant tenant, string previousDeltaLink, DeltaRequestOptions options, CancellationToken cancellationToken)
        {
            var result = new List<JsonElement>();

            string? nextLink = previousDeltaLink;
            string? deltaLink = default;

            do
            {
                var root = await GetAsync(tenant, nextLink, cancellationToken, preferMinimal: options.PreferMinimal).ConfigureAwait(false);

                foreach (var item in root.GetProperty("value").EnumerateArray())
                {
                    if (cancellationToken.IsCancellationRequested)
                        return new DeltaResult<JsonElement>(result, deltaLink);

                    result.Add(item);
                }

                HandleNextLink(root, ref nextLink);
                HandleDeltaLink(root, ref deltaLink);

            } while (nextLink != null);

            return new DeltaResult<JsonElement>(result, deltaLink);
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphUsersClient.GetMemberOfAsync(IAzureTenant tenant, Guid userID, ListRequestOptions options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            string? nextLink = options.BuildLink($"users/{userID}/memberOf");

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

#pragma warning disable CS8424 // The EnumeratorCancellationAttribute will have no effect. The attribute is only effective on a parameter of type CancellationToken in an async-iterator method returning IAsyncEnumerable

        IAsyncEnumerable<Guid> ISlimGraphUsersClient.GetMemberGroupsAsync(IAzureTenant tenant, Guid userID, bool securityEnabledOnly, InvokeRequestOptions options, [EnumeratorCancellation] CancellationToken cancellationToken)
            => GetMemberGroupsImplAsync(tenant, userID, securityEnabledOnly, options, cancellationToken);

        IAsyncEnumerable<Guid> ISlimGraphUsersClient.GetMemberObjectsAsync(IAzureTenant tenant, Guid userID, bool securityEnabledOnly, InvokeRequestOptions options, [EnumeratorCancellation] CancellationToken cancellationToken)
            => GetMemberObjectsImplAsync(tenant, userID, securityEnabledOnly, options, cancellationToken);

        IAsyncEnumerable<Guid> ISlimGraphUsersClient.GetMemberGroupsAsync(IAzureTenant tenant, string userPrincipalName, bool securityEnabledOnly, InvokeRequestOptions options, [EnumeratorCancellation] CancellationToken cancellationToken)
            => GetMemberGroupsImplAsync(tenant, userPrincipalName, securityEnabledOnly, options, cancellationToken);

        IAsyncEnumerable<Guid> ISlimGraphUsersClient.GetMemberObjectsAsync(IAzureTenant tenant, string userPrincipalName, bool securityEnabledOnly, InvokeRequestOptions options, [EnumeratorCancellation] CancellationToken cancellationToken)
            => GetMemberObjectsImplAsync(tenant, userPrincipalName, securityEnabledOnly, options, cancellationToken);

#pragma warning restore CS8424 // The EnumeratorCancellationAttribute will have no effect. The attribute is only effective on a parameter of type CancellationToken in an async-iterator method returning IAsyncEnumerable

        private async IAsyncEnumerable<Guid> GetMemberGroupsImplAsync(IAzureTenant tenant, object id, bool securityEnabledOnly, InvokeRequestOptions options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            string? nextLink = options.BuildLink($"users/{id}/getMemberGroups");

            do
            {
                var root = await PostAsync(tenant, new { securityEnabledOnly }, nextLink, cancellationToken).ConfigureAwait(false);

                foreach (var item in root.GetProperty("value").EnumerateArray())
                {
                    if (cancellationToken.IsCancellationRequested)
                        yield break;

                    yield return item.GetGuid();
                }

                HandleNextLink(root, ref nextLink);

            } while (nextLink != null);
        }

        private async IAsyncEnumerable<Guid> GetMemberObjectsImplAsync(IAzureTenant tenant, object id, bool securityEnabledOnly, InvokeRequestOptions options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            string? nextLink = options.BuildLink($"users/{id}/getMemberObjects");

            do
            {
                var root = await PostAsync(tenant, new { securityEnabledOnly }, nextLink, cancellationToken).ConfigureAwait(false);

                foreach (var item in root.GetProperty("value").EnumerateArray())
                {
                    if (cancellationToken.IsCancellationRequested)
                        yield break;

                    yield return item.GetGuid();
                }

                HandleNextLink(root, ref nextLink);

            } while (nextLink != null);
        }
    }
}