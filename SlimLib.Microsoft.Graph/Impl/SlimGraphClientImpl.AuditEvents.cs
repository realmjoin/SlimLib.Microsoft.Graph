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
        GraphOperation<JsonDocument?> ISlimGraphAuditEventsClient.GetAuditEventAsync(IAzureTenant tenant, Guid auditEventID, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceManagement/auditEvents/{auditEventID}");

            return new(this, tenant, HttpMethod.Get, link, options, static doc => doc);
        }

        GraphArrayOperation<JsonDocument> ISlimGraphAuditEventsClient.GetAuditEventsAsync(IAzureTenant tenant, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, "deviceManagement/auditEvents");

            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc => doc);
        }
    }
}