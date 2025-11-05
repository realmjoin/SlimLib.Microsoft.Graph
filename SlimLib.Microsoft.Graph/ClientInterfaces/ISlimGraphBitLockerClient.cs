using SlimLib.Auth.Azure;
using System.Text.Json;
using System.Threading;

namespace SlimLib.Microsoft.Graph
{
    public interface ISlimGraphBitLockerClient
    {
        GraphArrayOperation<JsonDocument> GetRecoveryKeysAsync(IAzureTenant tenant, ListRequestOptions? options = default, CancellationToken cancellationToken = default);
        GraphOperation<JsonDocument?> GetRecoveryKeyAsync(IAzureTenant tenant, string bitlockeryRecoveryKeyId, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
    }
}
