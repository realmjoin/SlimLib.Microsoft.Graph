using System.Collections.Generic;

namespace SlimGraph.Auth
{
    public abstract class AzureCredentials : IAzureCredentials
    {
        public abstract IDictionary<string, string> GetRequestData(string scope);
    }
}