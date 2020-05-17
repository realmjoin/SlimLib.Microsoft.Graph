using SlimGraph.Auth;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SlimGraph
{
    partial class SlimGraphClientImpl
    {
        async Task<JsonElement> ISlimGraphMobileAppsClient.GetMobileAppAsync(IAzureTenant tenant, Guid appID, ScalarRequestOptions options, CancellationToken cancellationToken)
        {
            var link = options.BuildLink($"deviceAppManagement/mobileApps/{appID}");

            return await GetAsync(tenant, link, cancellationToken).ConfigureAwait(false);
        }

        async Task<JsonElement> ISlimGraphMobileAppsClient.CreateMobileAppAsync(IAzureTenant tenant, JsonElement data, InvokeRequestOptions options, CancellationToken cancellationToken)
        {
            var link = options.BuildLink("deviceAppManagement/mobileApps");

            return await PostAsync(tenant, JsonSerializer.SerializeToUtf8Bytes(data), link, cancellationToken).ConfigureAwait(false);
        }

        async Task ISlimGraphMobileAppsClient.UpdateMobileAppAsync(IAzureTenant tenant, Guid appID, JsonElement data, InvokeRequestOptions options, CancellationToken cancellationToken)
        {
            var link = options.BuildLink($"deviceAppManagement/mobileApps/{appID}");

            await PatchAsync(tenant, JsonSerializer.SerializeToUtf8Bytes(data), link, cancellationToken).ConfigureAwait(false);
        }

        async Task ISlimGraphMobileAppsClient.DeleteMobileAppAsync(IAzureTenant tenant, Guid appID, InvokeRequestOptions options, CancellationToken cancellationToken)
        {
            var link = options.BuildLink($"deviceAppManagement/mobileApps/{appID}");

            await DeleteAsync(tenant, link, cancellationToken).ConfigureAwait(false);
        }


        async IAsyncEnumerable<JsonElement> ISlimGraphMobileAppsClient.GetMobileAppsAsync(IAzureTenant tenant, ListRequestOptions options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = options.BuildLink("deviceAppManagement/mobileApps");

            await foreach (var item in GetArrayAsync(tenant, nextLink, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item;
            }
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphMobileAppsClient.GetMobileAppDeviceStatusesAsync(IAzureTenant tenant, Guid appID, ListRequestOptions options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = options.BuildLink($"deviceAppManagement/mobileApps/{appID}/deviceStatuses");

            await foreach (var item in GetArrayAsync(tenant, nextLink, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item;
            }
        }

        async IAsyncEnumerable<JsonElement> ISlimGraphMobileAppsClient.GetMobileAppUserStatusesAsync(IAzureTenant tenant, Guid appID, ListRequestOptions options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = options.BuildLink($"deviceAppManagement/mobileApps/{appID}/userStatuses");

            await foreach (var item in GetArrayAsync(tenant, nextLink, cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return item;
            }
        }


        async Task<JsonElement> ISlimGraphMobileAppsClient.GetMobileAppContentAsync(IAzureTenant tenant, Guid appID, string type, string mobileAppContentID, ScalarRequestOptions options, CancellationToken cancellationToken)
        {
            var link = options.BuildLink($"deviceAppManagement/mobileApps/{appID}/{type}/contentVersions/{mobileAppContentID}");

            return await GetAsync(tenant, link, cancellationToken).ConfigureAwait(false);
        }

        async Task<string> ISlimGraphMobileAppsClient.CreateMobileAppContentAsync(IAzureTenant tenant, Guid appID, string type, InvokeRequestOptions options, CancellationToken cancellationToken)
        {
            var link = options.BuildLink($"deviceAppManagement/mobileApps/{appID}/{type}/contentVersions");

            var response = await PostAsync(tenant, new byte[] { 0x7B, 0x7D }, link, cancellationToken).ConfigureAwait(false);
            return response.GetProperty("id").GetString();
        }

        async Task ISlimGraphMobileAppsClient.CommitMobileAppContentAsync(IAzureTenant tenant, Guid appID, string type, string mobileAppContentID, InvokeRequestOptions options, CancellationToken cancellationToken)
        {
            var buffer = new ArrayBufferWriter<byte>();
            using (var writer = new Utf8JsonWriter(buffer))
            {
                writer.WriteStartObject();
                writer.WriteString("@odata.type", "#" + type);
                writer.WriteString("committedContentVersion", mobileAppContentID);
                writer.WriteEndObject();
            }

            await ((ISlimGraphMobileAppsClient)this).UpdateMobileAppAsync(tenant, appID, JsonSerializer.Deserialize<JsonElement>(buffer.WrittenSpan));
        }


        async Task<JsonElement> ISlimGraphMobileAppsClient.GetMobileAppContentFilesAsync(IAzureTenant tenant, Guid appID, string type, string mobileAppContentID, Guid mobileAppContentFileID, ScalarRequestOptions options, CancellationToken cancellationToken)
        {
            var link = options.BuildLink($"deviceAppManagement/mobileApps/{appID}/{type}/contentVersions/{mobileAppContentID}/files/{mobileAppContentFileID}");

            return await GetAsync(tenant, link, cancellationToken).ConfigureAwait(false);
        }

        async Task<JsonElement> ISlimGraphMobileAppsClient.CreateMobileAppContentFilesAsync(IAzureTenant tenant, Guid appID, string type, string mobileAppContentID, JsonElement data, InvokeRequestOptions options, CancellationToken cancellationToken)
        {
            var link = options.BuildLink($"deviceAppManagement/mobileApps/{appID}/{type}/contentVersions/{mobileAppContentID}/files");

            return await PostAsync(tenant, JsonSerializer.SerializeToUtf8Bytes(data), link, cancellationToken).ConfigureAwait(false);
        }

        async Task ISlimGraphMobileAppsClient.CommitMobileAppContentFilesAsync(IAzureTenant tenant, Guid appID, string type, string mobileAppContentID, Guid mobileAppContentFileID, JsonElement data, InvokeRequestOptions options, CancellationToken cancellationToken)
        {
            var link = options.BuildLink($"deviceAppManagement/mobileApps/{appID}/{type}/contentVersions/{mobileAppContentID}/files/{mobileAppContentFileID}/commit");

            await PostAsync(tenant, JsonSerializer.SerializeToUtf8Bytes(data), link, cancellationToken).ConfigureAwait(false);
        }
    }
}