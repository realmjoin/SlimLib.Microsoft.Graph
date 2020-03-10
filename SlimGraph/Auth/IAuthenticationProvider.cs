using System.Net.Http;
using System.Threading.Tasks;

namespace SlimGraph.Auth
{
    public interface IAuthenticationProvider
    {
        Task AuthenticateRequestAsync(IAzureTenant tenant, HttpRequestMessage request);
    }
}