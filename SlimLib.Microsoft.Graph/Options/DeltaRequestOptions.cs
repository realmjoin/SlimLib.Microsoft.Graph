using System.Collections.Generic;

namespace SlimLib.Microsoft.Graph
{
    public class DeltaRequestOptions
    {
        public HashSet<string> Select { get; } = new();
        public string? Filter { get; set; }
        public bool PreferMinimal { get; set; }
    }
}