using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SlimLib.Microsoft.Graph
{
    public class RequestRetryOptions(Func<(int SendAttempt, HttpResponseMessage Response), Task<(bool ShouldRetry, int NumberOfSecondsToWaitBeforeRetry)>> retryDelegate)
    {
        public static int DefaultMaxRetries => 10;
        public Func<(int SendAttempt, HttpResponseMessage Response), Task<(bool ShouldRetry, int NumberOfSecondsToWaitBeforeRetry)>> RetryDelegate { get; private set; } = retryDelegate;
    }
}
