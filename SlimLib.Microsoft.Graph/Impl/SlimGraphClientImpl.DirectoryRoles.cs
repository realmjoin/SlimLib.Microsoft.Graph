using SlimLib.Auth.Azure;
using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;

namespace SlimLib.Microsoft.Graph
{
    partial class SlimGraphClientImpl
    {
        GraphOperation<JsonDocument?> ISlimGraphDirectoryRolesClient.GetDirectoryRoleAsync(IAzureTenant tenant, Guid directoryRoleID, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = ODataLinkBuilder.BuildLink(options, $"directoryRoles/{directoryRoleID}");

            return new(this, tenant, HttpMethod.Get, link, options, default, static doc => doc);
        }

        GraphArrayOperation<JsonDocument> ISlimGraphDirectoryRolesClient.GetDirectoryRolesAsync(IAzureTenant tenant, ListRequestOptions? options, CancellationToken cancellationToken)
        {
            var nextLink = ODataLinkBuilder.BuildLink(options, "directoryRoles");

            return new(this, tenant, HttpMethod.Get, nextLink, options, default, static doc => doc);
        }

        GraphArrayOperation<JsonDocument> ISlimGraphDirectoryRolesClient.GetMembersAsync(IAzureTenant tenant, Guid directoryRoleID, ListRequestOptions? options, CancellationToken cancellationToken)
        {
            var nextLink = ODataLinkBuilder.BuildLink(options, $"directoryRoles/{directoryRoleID}/members");

            return new(this, tenant, HttpMethod.Get, nextLink, options, default, static doc => doc);
        }
    }
}