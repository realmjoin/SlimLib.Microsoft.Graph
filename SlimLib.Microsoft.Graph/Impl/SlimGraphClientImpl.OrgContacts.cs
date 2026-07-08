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
        GraphOperation<JsonDocument?> ISlimGraphOrgContactsClient.GetOrgContactAsync(IAzureTenant tenant, Guid orgContactID, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"contacts/{orgContactID}");

            return new(this, tenant, HttpMethod.Get, link, options, default, static doc => doc);
        }

        GraphArrayOperation<JsonDocument> ISlimGraphOrgContactsClient.GetOrgContactsAsync(IAzureTenant tenant, ListRequestOptions? options, CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, "contacts");

            return new(this, tenant, HttpMethod.Get, nextLink, options, default, static doc => doc);
        }
    }
}