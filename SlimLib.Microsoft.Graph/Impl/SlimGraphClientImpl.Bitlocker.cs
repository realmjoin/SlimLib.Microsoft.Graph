using SlimLib.Auth.Azure;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;

namespace SlimLib.Microsoft.Graph
{
    partial class SlimGraphClientImpl
    {
        GraphArrayOperation<JsonDocument> ISlimGraphBitLockerClient.GetRecoveryKeysAsync(IAzureTenant tenant, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, "informationProtection/bitlocker/recoveryKeys");
            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc => doc);
        }

        GraphOperation<JsonDocument?> ISlimGraphBitLockerClient.GetRecoveryKeyAsync(IAzureTenant tenant, string bitlockeryRecoveryKeyId, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"informationProtection/bitlocker/recoveryKeys/{bitlockeryRecoveryKeyId}");
            return new(this, tenant, HttpMethod.Get, link, options, static doc => doc);
        }
    }
}
