using SlimLib.Auth.Azure;
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
        async Task<JsonDocument?> ISlimGraphAuditLogsClient.GetSignInAsync(IAzureTenant tenant, Guid signInID, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"auditLogs/signIns/{signInID}");

            return await GetAsync(tenant, link, new RequestHeaderOptions(), null, cancellationToken).ConfigureAwait(false);
        }

        IAsyncEnumerable<JsonDocument> ISlimGraphAuditLogsClient.GetSignInsAsync(IAzureTenant tenant, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, "auditLogs/signIns");

            return GetArrayAsync(tenant, nextLink, options, cancellationToken);
        }
    }
}