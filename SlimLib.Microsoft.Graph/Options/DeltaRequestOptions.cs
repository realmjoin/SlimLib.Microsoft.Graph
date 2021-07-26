namespace SlimLib.Microsoft.Graph
{
    public class DeltaRequestOptions
    {
        public string? Select { get; set; }
        public string? Filter { get; set; }
        public bool PreferMinimal { get; set; }
    }
}