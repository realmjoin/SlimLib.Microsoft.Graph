using Microsoft.Extensions.Logging;
using SlimGraph.Auth;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SlimGraph
{
    internal sealed partial class SlimGraphClientImpl : ISlimGraphOrgContactsClient, ISlimGraphDevicesClient, ISlimGraphManagedDevicesClient, ISlimGraphGroupsClient, ISlimGraphSubscribedSkusClient, ISlimGraphServicePrincipalsClient, ISlimGraphUsersClient
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

        private Task<JsonElement> GetAsync(IAzureTenant tenant, string requestUri, CancellationToken cancellationToken, bool preferMinimal = false)
            => SendAsync(tenant, HttpMethod.Get, null, requestUri, cancellationToken, preferMinimal);

        private Task<JsonElement> PostAsync(IAzureTenant tenant, object data, string requestUri, CancellationToken cancellationToken, bool preferMinimal = false)
            => SendAsync(tenant, HttpMethod.Post, data, requestUri, cancellationToken, preferMinimal);

        private async Task<JsonElement> SendAsync(IAzureTenant tenant, HttpMethod method, object? data, string requestUri, CancellationToken cancellationToken, bool preferMinimal = false)
        {
            using var request = new HttpRequestMessage(method, requestUri);

            if (data != null)
            {
                request.Content = new ByteArrayContent(JsonSerializer.SerializeToUtf8Bytes(data))
                {
                    Headers = { ContentType = new MediaTypeHeaderValue("application/json") { CharSet = Encoding.UTF8.WebName } }
                };
            }

            await authenticationProvider.AuthenticateRequestAsync(tenant, SlimGraphConstants.ScopeDefault, request).ConfigureAwait(false);

            if (preferMinimal)
            {
                logger.LogDebug("Setting HTTP header Prefer: return=minimal");
                request.Headers.Add("Prefer", "return=minimal");
            }

            using var response = await httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);

            if (preferMinimal)
            {
                if (!response.Headers.TryGetValues("Preference-Applied", out var values) || !values.Any(x => x == "return=minimal"))
                {
                    throw new InvalidOperationException("Prefer return=minimal was applied, but the Graph did not honor our request and returned a full response.");
                }

                logger.LogDebug("Received HTTP header Preference-Applied: return=minimal");
            }

            using var content = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
            var root = await JsonSerializer.DeserializeAsync<JsonElement>(content, cancellationToken: cancellationToken);

            if (!response.IsSuccessStatusCode)
                throw HandleError(response.StatusCode, root);

            var path = request.RequestUri.AbsolutePath;

            if (root.TryGetProperty("value", out var items) && items.ValueKind == JsonValueKind.Array)
            {
                logger.LogInformation("Got {count} items for HTTP request to {path}.", items.GetArrayLength(), path);
            }
            else
            {
                logger.LogInformation("Got single item for HTTP request to {path}.", path);
            }

            return root;
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