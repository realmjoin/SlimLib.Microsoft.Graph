using Microsoft.Extensions.Logging;
using SlimLib.Auth.Azure;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SlimLib.Microsoft.Graph
{
    internal sealed partial class SlimGraphClientImpl : SlimODataClientBase, ISlimGraphAdministrativeUnitsClient, ISlimGraphAndroidManagedStoreClient, ISlimGraphApplicationsClient, ISlimGraphAuditEventsClient, ISlimGraphAuditLogsClient, ISlimGraphDeviceManagementReportsClient, ISlimGraphOrganizationsClient, ISlimGraphOrgContactsClient, ISlimGraphDevicesClient, ISlimGraphDirectoryRolesClient, ISlimGraphDetectedAppsClient, ISlimGraphMobileAppsClient, ISlimGraphManagedDevicesClient, ISlimGraphGroupsClient, ISlimGraphSubscribedSkusClient, ISlimGraphServicePrincipalsClient, ISlimGraphPrivilegedAccessClient, ISlimGraphUsersClient, ISlimGraphDeviceLocalCredentialsClient, ISlimGraphPartnerBillingReportsClient, ISlimGraphTenantRelationshipsClient, ISlimGraphBitLockerClient, ISlimGraphWindowsDeviceUpdatesClient
    {
        private readonly ILogger<SlimGraphClient> logger;

        public SlimGraphClientImpl(IAuthenticationProvider authenticationProvider, HttpClient httpClient, ILogger<SlimGraphClient> logger)
            : base(authenticationProvider, httpClient, logger)
        {
            this.logger = logger;
        }

        protected override string Scope => SlimGraphConstants.ScopeDefault;

#pragma warning disable CS0618 // SlimGraphException is intentionally thrown for backward compatibility

        protected override SlimApiException CreateApiError(HttpStatusCode statusCode, IEnumerable<KeyValuePair<string, IEnumerable<string>>> headers, string errorCode, string errorMessage)
            => new SlimGraphException(statusCode, headers, errorCode, errorMessage);

#pragma warning restore CS0618

        private static string BuildDeltaLink(string resource, DeltaRequestOptions? options)
        {
            var link = ODataLinkBuilder.BuildLink(resource, options?.Select, options?.Filter);

            if (options?.StartFromLatest == true)
            {
                link += (link.Contains('?') ? "&" : "?") + "$deltatoken=latest";
            }

            return link;
        }

        private async Task<SlimGraphPicture?> GetPictureAsync(IAzureTenant tenant, string requestUri, CancellationToken cancellationToken)
        {
            using var response = await SendInternalAsync(tenant, HttpMethod.Get, requestUri, null, null, cancellationToken);

            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                logger.LogInformation("Got no content for HTTP request to {requestUri}.", requestUri);
                return null;
            }

            var buffer = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);

            return new SlimGraphPicture(buffer, response.Content.Headers.ContentType);
        }
    }
}