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
        GraphOperation<JsonDocument?> ISlimGraphServicePrincipalsClient.GetServicePrincipalAsync(IAzureTenant tenant, Guid servicePrincipalID, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"servicePrincipals/{servicePrincipalID}");

            return new(this, tenant, HttpMethod.Get, link, options, static doc => doc);
        }

        GraphArrayOperation<JsonDocument> ISlimGraphServicePrincipalsClient.GetServicePrincipalsAsync(IAzureTenant tenant, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, "servicePrincipals");

            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc => doc);
        }

        GraphArrayOperation<JsonDocument> ISlimGraphServicePrincipalsClient.GetAppRoleAssignmentsAsync(IAzureTenant tenant, Guid servicePrincipalID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"servicePrincipals/{servicePrincipalID}/appRoleAssignments");

            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc => doc);
        }

        GraphArrayOperation<JsonDocument> ISlimGraphServicePrincipalsClient.GetAppRoleAssignedToAsync(IAzureTenant tenant, Guid servicePrincipalID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"servicePrincipals/{servicePrincipalID}/appRoleAssignedTo");

            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc => doc);
        }
    }
}