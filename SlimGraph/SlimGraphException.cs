using System;
using System.Net;

namespace SlimGraph
{
    public class SlimGraphException : Exception
    {
        internal SlimGraphException(HttpStatusCode httpStatusCode, string graphErrorCode, string graphErrorMessage) : base(graphErrorMessage)
        {
            HttpStatusCode = httpStatusCode;
            GraphErrorCode = graphErrorCode;
        }

        public HttpStatusCode HttpStatusCode { get; }
        public string GraphErrorCode { get; }
    }
}