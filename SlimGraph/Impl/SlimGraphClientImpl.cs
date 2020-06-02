using Microsoft.Extensions.Logging;
using SlimGraph.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SlimGraph
{
    internal sealed partial class SlimGraphClientImpl : ISlimGraphOrgContactsClient, ISlimGraphDevicesClient, ISlimGraphDirectoryRolesClient, ISlimGraphDetectedAppsClient, ISlimGraphMobileAppsClient, ISlimGraphManagedDevicesClient, ISlimGraphGroupsClient, ISlimGraphSubscribedSkusClient, ISlimGraphServicePrincipalsClient, ISlimGraphUsersClient
    {
        private readonly IAuthenticationProvider authenticationProvider;
        private readonly HttpClient httpClient;
        private readonly ILogger<SlimGraphClient> logger;

        public SlimGraphClientImpl(IAuthenticationProvider authenticationProvider, HttpClient httpClient, ILogger<SlimGraphClient> logger)
        {
            this.authenticationProvider = authenticationProvider;
            this.httpClient = httpClient;
            this.logger = logger;
        }

        private Task<JsonElement> DeleteAsync(IAzureTenant tenant, string requestUri, RequestHeaderOptions options, CancellationToken cancellationToken)
            => SendAsync(tenant, HttpMethod.Delete, null, requestUri, options, cancellationToken);

        private Task<JsonElement> GetAsync(IAzureTenant tenant, string requestUri, RequestHeaderOptions options, CancellationToken cancellationToken)
            => SendAsync(tenant, HttpMethod.Get, null, requestUri, options, cancellationToken);

        private Task<JsonElement> PatchAsync(IAzureTenant tenant, ReadOnlyMemory<byte> utf8Data, string requestUri, RequestHeaderOptions options, CancellationToken cancellationToken)
            => SendAsync(tenant, HttpMethod.Patch, utf8Data, requestUri, options, cancellationToken);

        private Task<JsonElement> PostAsync(IAzureTenant tenant, ReadOnlyMemory<byte> utf8Data, string requestUri, RequestHeaderOptions options, CancellationToken cancellationToken)
            => SendAsync(tenant, HttpMethod.Post, utf8Data, requestUri, options, cancellationToken);

        private async IAsyncEnumerable<JsonElement> GetArrayAsync(IAzureTenant tenant, string nextLink, RequestHeaderOptions options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            string? link = nextLink;

            do
            {
                var root = await GetAsync(tenant, link, options, cancellationToken).ConfigureAwait(false);

                foreach (var item in root.GetProperty("value").EnumerateArray())
                {
                    if (cancellationToken.IsCancellationRequested)
                        yield break;

                    yield return item;
                }

                HandleNextLink(root, ref link);

            } while (link != null);
        }

        private async IAsyncEnumerable<JsonElement> PostArrayAsync(IAzureTenant tenant, ReadOnlyMemory<byte> utf8Data, string nextLink, RequestHeaderOptions options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            string? nLink = nextLink;

            do
            {
                var root = await PostAsync(tenant, utf8Data, nLink, options, cancellationToken).ConfigureAwait(false);

                foreach (var item in root.GetProperty("value").EnumerateArray())
                {
                    if (cancellationToken.IsCancellationRequested)
                        yield break;

                    yield return item;
                }

                HandleNextLink(root, ref nLink);

            } while (nLink != null);
        }

        private async Task<DeltaResult<JsonElement>> GetDeltaAsync(IAzureTenant tenant, string nextLink, DeltaRequestOptions options, CancellationToken cancellationToken)
        {
            var result = new List<JsonElement>();

            string? nLink = nextLink;
            string? dLink = default;

            do
            {
                var root = await GetAsync(tenant, nLink, new RequestHeaderOptions { PreferMinimal = options.PreferMinimal }, cancellationToken).ConfigureAwait(false);

                foreach (var item in root.GetProperty("value").EnumerateArray())
                {
                    if (cancellationToken.IsCancellationRequested)
                        break;

                    result.Add(item);
                }

                if (cancellationToken.IsCancellationRequested)
                    break;

                HandleNextLink(root, ref nLink);
                HandleDeltaLink(root, ref dLink);

            } while (nLink != null);

            return new DeltaResult<JsonElement>(result, dLink);
        }

        private async Task<JsonElement> SendAsync(IAzureTenant tenant, HttpMethod method, ReadOnlyMemory<byte>? utf8Data, string requestUri, RequestHeaderOptions options, CancellationToken cancellationToken)
        {
            using var response = await SendInternalAsync(tenant, method, utf8Data, requestUri, options, cancellationToken);

            if (response.StatusCode == HttpStatusCode.NoContent || response.Content.Headers.ContentLength == 0)
            {
                logger.LogInformation("Got no content for HTTP request to {requestUri}.", requestUri);
                return default;
            }

            using var content = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

            var root = await JsonSerializer.DeserializeAsync<JsonElement>(content, cancellationToken: cancellationToken);

            if (!response.IsSuccessStatusCode)
                throw HandleError(response.StatusCode, root);

            if (root.TryGetProperty("value", out var items) && items.ValueKind == JsonValueKind.Array)
            {
                logger.LogInformation("Got {count} items for HTTP request to {requestUri}.", items.GetArrayLength(), requestUri);
            }
            else
            {
                logger.LogInformation("Got single item for HTTP request to {requestUri}.", requestUri);
            }

            return root;
        }

        private async Task<SlimGraphPicture?> GetPictureAsync(IAzureTenant tenant, string requestUri, CancellationToken cancellationToken)
        {
            using var response = await SendInternalAsync(tenant, HttpMethod.Get, null, requestUri, new RequestHeaderOptions(), cancellationToken);

            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                logger.LogInformation("Got no content for HTTP request to {requestUri}.", requestUri);
                return null;
            }

            var buffer = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);

            return new SlimGraphPicture(buffer, response.Content.Headers.ContentType);
        }

        private async Task<HttpResponseMessage> SendInternalAsync(IAzureTenant tenant, HttpMethod method, ReadOnlyMemory<byte>? utf8Data, string requestUri, RequestHeaderOptions options, CancellationToken cancellationToken)
        {
            using var request = new HttpRequestMessage(method, requestUri);

            if (utf8Data != null)
            {
                request.Content = new ReadOnlyMemoryContent(utf8Data.Value)
                {
                    Headers = { ContentType = new MediaTypeHeaderValue("application/json") { CharSet = Encoding.UTF8.WebName } }
                };
            }

            await authenticationProvider.AuthenticateRequestAsync(tenant, SlimGraphConstants.ScopeDefault, request).ConfigureAwait(false);

            if (options.ConsistencyLevelEventual == true)
            {
                logger.LogDebug("Setting HTTP header ConsistencyLevel: eventual");
                request.Headers.Add("ConsistencyLevel", "eventual");
            }

            if (options.PreferMinimal == true)
            {
                logger.LogDebug("Setting HTTP header Prefer: return=minimal");
                request.Headers.Add("Prefer", "return=minimal");
            }

            var response = await httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);

            if (options.PreferMinimal == true)
            {
                if (!response.Headers.TryGetValues("Preference-Applied", out var values) || !values.Any(x => x == "return=minimal"))
                {
                    throw new InvalidOperationException("Prefer return=minimal was applied, but the Graph did not honor our request and returned a full response.");
                }

                logger.LogDebug("Received HTTP header Preference-Applied: return=minimal");
            }

            return response;
        }

        private static SlimGraphException HandleError(HttpStatusCode statusCode, JsonElement root)
        {
            try
            {
                if (root.TryGetProperty("error", out var error))
                {
                    return new SlimGraphException(statusCode, error.GetProperty("code").GetString(), error.GetProperty("message").GetString());
                }
            }
            catch
            {
            }

            return new SlimGraphException(0, "Unkown error", "Unkown error");
        }

        private static void HandleNextLink(JsonElement root, ref string? nextLink)
        {
            if (root.TryGetProperty("@odata.nextLink", out var el))
            {
                nextLink = el.GetString();
            }
            else
            {
                nextLink = null;
            }
        }

        private static void HandleDeltaLink(JsonElement root, ref string? deltaLink)
        {
            if (root.TryGetProperty("@odata.deltaLink", out var el))
            {
                deltaLink = el.GetString();
            }
            else
            {
                deltaLink = null;
            }
        }
    }
}