using System.Linq;

namespace SlimGraph
{
    public struct InvokeRequestOptions : ILinkBuilder
    {
        public string BuildLink(string call)
        {
            return RequestOptions.BuildLink(call, Enumerable.Empty<string>());
        }
    }
}