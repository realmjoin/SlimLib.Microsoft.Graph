using System;
using System.Net;
using System.Net.Http.Headers;

namespace SlimLib.Microsoft.Graph
{
    public class SlimGraphException : Exception
    {
        internal SlimGraphException(HttpStatusCode httpStatusCode, HttpResponseHeaders? headers, string graphErrorCode, string graphErrorMessage) : base(FormatErrorMessage(graphErrorCode, graphErrorMessage))
        {
            HttpStatusCode = httpStatusCode;
            Headers = headers;
            GraphErrorCode = graphErrorCode;
        }

        public HttpStatusCode HttpStatusCode { get; }
        public HttpResponseHeaders? Headers { get; }
        public string GraphErrorCode { get; }

        private static string FormatErrorMessage(string graphErrorCode, string graphErrorMessage)
        {
            if (string.IsNullOrEmpty(graphErrorMessage))
                return graphErrorCode;

            return $"{graphErrorCode}: {graphErrorMessage}";
        }
    }
}