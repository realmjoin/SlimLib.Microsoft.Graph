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
        GraphOperation<JsonDocument?> ISlimGraphAuditLogsClient.GetSignInAsync(IAzureTenant tenant, Guid signInID, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"auditLogs/signIns/{signInID}");

            return new(this, tenant, HttpMethod.Get, link, options, default, static doc => doc);
        }

        GraphArrayOperation<JsonDocument> ISlimGraphAuditLogsClient.GetSignInsAsync(IAzureTenant tenant, ListRequestOptions? options, CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, "auditLogs/signIns");

            return new(this, tenant, HttpMethod.Get, nextLink, options, default, static doc => doc);
        }
    }
}