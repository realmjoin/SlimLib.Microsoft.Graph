using System.Text.Json.Serialization;
using SlimLib.Auth.Azure.Shared;

namespace SlimLib.Microsoft.Graph.Results.Delta
{
    /// <summary>
    /// A page of a delta round. Every page but the last carries <c>@odata.nextLink</c>, the last one
    /// <c>@odata.deltaLink</c> for the next round. Removed objects come with an <c>@removed</c> property.
    /// </summary>
    public class ODataDeltaListResponse<T> : ODataListResponse<T>
    {
        [JsonPropertyName("@odata.deltaLink")]
        public string? ODataDeltaLink { get; set; }
    }
}
