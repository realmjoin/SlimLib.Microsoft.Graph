using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace SlimLib.Microsoft.Graph
{
    public static class DeltaPageExtensions
    {
        /// <summary>
        /// Reads the <c>@odata.deltaLink</c> of a delta page. Only the last page of a round carries one;
        /// a round left early never yields it and must be started over.
        /// </summary>
        public static bool TryGetDeltaLink(this JsonDocument page, [NotNullWhen(true)] out string? deltaLink)
        {
            if (page.RootElement.TryGetProperty("@odata.deltaLink", out var el) && el.ValueKind == JsonValueKind.String)
            {
                deltaLink = el.GetString()!;
                return true;
            }

            deltaLink = null;
            return false;
        }
    }
}
