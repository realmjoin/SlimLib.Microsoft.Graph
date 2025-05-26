using System.Collections.Generic;

namespace SlimLib.Microsoft.Graph
{
    public class DeltaRequestOptions : InvokeRequestOptions
    {
        public HashSet<string> Select { get; } = new();
        public string? Filter { get; set; }
    }
}