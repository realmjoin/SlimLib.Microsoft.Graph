using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace SlimGraph.Auth
{
    public class AzureAuthenticationClient : IAuthenticationProvider
    {
        private readonly IAzureCredentials azureCredentials;
        private readonly HttpClient httpClient;

        public AzureAuthenticationClient(IAzureCredentials azureCredentials, HttpClient httpClient)
        {
            this.azureCredentials = azureCredentials;
            this.httpClient = httpClient;
        }

        public async Task AuthenticateRequestAsync(IAzureTenant tenant, HttpRequestMessage request)
        {
            var auth = await GetAuthenticationAsync(tenant, scope: SlimGraphConstants.ScopeDefault);

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", auth.AccessToken);
        }

        public async Task<AuthSuccessResponse> GetAuthenticationAsync(IAzureTenant tenant, string scope)
        {
            var data = azureCredentials.GetRequestData(scope);

            using var content = new FormUrlEncodedContent(data);
            using var response = await httpClient.PostAsync(tenant.TokenUrl, content).ConfigureAwait(false);
            using var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                var error = await JsonSerializer.DeserializeAsync<AuthErrorResponse>(stream).ConfigureAwait(false);
                throw new AuthException(response.StatusCode, error.Error ?? "No more details available.", error.ErrorDescription ?? "No more details available.");
            }

            return await JsonSerializer.DeserializeAsync<AuthSuccessResponse>(stream).ConfigureAwait(false);
        }
    }
}