using System.Collections.Generic;

namespace SlimGraph.Auth
{
    public interface IAzureCredentials
    {
        IDictionary<string, string> GetRequestData(string scope);
    }
}