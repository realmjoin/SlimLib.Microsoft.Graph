using System.Collections.Generic;

namespace SlimLib.Microsoft.Graph
{
    public class DeltaRequestOptions : InvokeRequestOptions
    {
        public HashSet<string> Select { get; } = new();
        public string? Filter { get; set; }

        /// <summary>
        /// Starts tracking from the current state (<c>$deltatoken=latest</c>): the round returns no objects,
        /// only the <c>@odata.deltaLink</c> to continue from with the DeltaChange calls.
        /// </summary>
        public bool StartFromLatest { get; set; }
    }
}