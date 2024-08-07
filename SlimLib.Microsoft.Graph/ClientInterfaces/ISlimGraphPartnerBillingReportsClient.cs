using SlimLib.Auth.Azure;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;

namespace SlimLib.Microsoft.Graph
{
    public interface ISlimGraphPartnerBillingReportsClient
    {
        Task<string?> ExportBilledReconciliationAsync(IAzureTenant tenant, JsonObject data, InvokeRequestOptions? options = default, CancellationToken cancellationToken = default);
        Task<JsonDocument?> GetOperationAsync(IAzureTenant tenant, string operationID, ScalarRequestOptions? options = default, CancellationToken cancellationToken = default);
    }
}
