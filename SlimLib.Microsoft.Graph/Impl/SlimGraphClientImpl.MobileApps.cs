using SlimLib.Auth.Azure;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;

namespace SlimLib.Microsoft.Graph
{
    partial class SlimGraphClientImpl
    {
        async Task<JsonElement> ISlimGraphMobileAppsClient.GetMobileAppAsync(IAzureTenant tenant, Guid appID, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceAppManagement/mobileApps/{appID}");

            return await GetAsync(tenant, link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }

        async Task<JsonElement> ISlimGraphMobileAppsClient.CreateMobileAppAsync(IAzureTenant tenant, JsonObject data, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, "deviceAppManagement/mobileApps");

            return await PostAsync(tenant, JsonSerializer.SerializeToUtf8Bytes(data), link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }

        async Task<JsonElement> ISlimGraphMobileAppsClient.UpdateMobileAppAsync(IAzureTenant tenant, Guid appID, JsonObject data, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceAppManagement/mobileApps/{appID}");

            return await PatchAsync(tenant, JsonSerializer.SerializeToUtf8Bytes(data), link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }

        async Task ISlimGraphMobileAppsClient.DeleteMobileAppAsync(IAzureTenant tenant, Guid appID, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceAppManagement/mobileApps/{appID}");

            await DeleteAsync(tenant, link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }


        async IAsyncEnumerable<JsonElement> ISlimGraphMobileAppsClient.GetMobileAppsAsync(IAzureTenant tenant, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, "deviceAppManagement/mobileApps");

            await foreach (var item in GetArrayAsync(tenant, nextLink, options, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item;
            }
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphMobileAppsClient.GetMobileAppAssignmentsAsync(IAzureTenant tenant, Guid appID, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"deviceAppManagement/mobileApps/{appID}/assignments");

            await foreach (var item in GetArrayAsync(tenant, nextLink, options, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item;
            }
        }


        async Task<JsonElement> ISlimGraphMobileAppsClient.GetMobileAppContentAsync(IAzureTenant tenant, Guid appID, string type, string mobileAppContentID, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceAppManagement/mobileApps/{appID}/{type}/contentVersions/{mobileAppContentID}");

            return await GetAsync(tenant, link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }

        async Task<string> ISlimGraphMobileAppsClient.CreateMobileAppContentAsync(IAzureTenant tenant, Guid appID, string type, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceAppManagement/mobileApps/{appID}/{type}/contentVersions");

            var response = await PostAsync(tenant, new byte[] { 0x7B, 0x7D }, link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
            return response.GetProperty("id").GetString() ?? "";
        }

        async Task ISlimGraphMobileAppsClient.CommitMobileAppContentAsync(IAzureTenant tenant, Guid appID, string type, string mobileAppContentID, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var data = new JsonObject
            {
                ["@odata.type"] = "#" + type,
                ["committedContentVersion"] = mobileAppContentID,
            };

            await ((ISlimGraphMobileAppsClient)this).UpdateMobileAppAsync(tenant, appID, data, cancellationToken: cancellationToken);
        }


        async Task<JsonElement> ISlimGraphMobileAppsClient.GetMobileAppContentFilesAsync(IAzureTenant tenant, Guid appID, string type, string mobileAppContentID, Guid mobileAppContentFileID, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceAppManagement/mobileApps/{appID}/{type}/contentVersions/{mobileAppContentID}/files/{mobileAppContentFileID}");

            return await GetAsync(tenant, link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }

        async Task<JsonElement> ISlimGraphMobileAppsClient.CreateMobileAppContentFilesAsync(IAzureTenant tenant, Guid appID, string type, string mobileAppContentID, JsonObject data, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceAppManagement/mobileApps/{appID}/{type}/contentVersions/{mobileAppContentID}/files");

            return await PostAsync(tenant, JsonSerializer.SerializeToUtf8Bytes(data), link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }

        async Task ISlimGraphMobileAppsClient.CommitMobileAppContentFilesAsync(IAzureTenant tenant, Guid appID, string type, string mobileAppContentID, Guid mobileAppContentFileID, JsonObject data, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceAppManagement/mobileApps/{appID}/{type}/contentVersions/{mobileAppContentID}/files/{mobileAppContentFileID}/commit");

            await PostAsync(tenant, JsonSerializer.SerializeToUtf8Bytes(data), link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }

        async Task ISlimGraphMobileAppsClient.AssignMobileAppAsync(IAzureTenant tenant, Guid appID, JsonObject data, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"deviceAppManagement/mobileApps/{appID}/assign");

            await PostAsync(tenant, JsonSerializer.SerializeToUtf8Bytes(data), link, new RequestHeaderOptions(), cancellationToken).ConfigureAwait(false);
        }
    }
}