using System;

namespace SlimGraph.Auth
{
    public struct AzureTenant : IAzureTenant
    {
        private readonly string idOrName;

        public AzureTenant(Guid id)
        {
            idOrName = id.ToString();
        }

        public AzureTenant(string name)
        {
            idOrName = name;
        }

        public Uri TokenUrl => new Uri($"https://login.microsoftonline.com/{idOrName}/oauth2/v2.0/token");
    }
}