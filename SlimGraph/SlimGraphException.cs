using System;
using System.Net;
using System.Net.Http.Headers;

namespace SlimGraph
{
    public class SlimGraphException : Exception
    {
        internal SlimGraphException(HttpStatusCode httpStatusCode, HttpResponseHeaders? headers, string graphErrorCode, string graphErrorMessage) : base(graphErrorMessage)
        {
            HttpStatusCode = httpStatusCode;
            Headers = headers;
            GraphErrorCode = graphErrorCode;
        }

        public HttpStatusCode HttpStatusCode { get; }
        public HttpResponseHeaders? Headers { get; }
        public string GraphErrorCode { get; }
    }
}