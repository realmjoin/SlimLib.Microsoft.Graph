namespace SlimGraph
{
    public class DeltaRequestOptions
    {
        public string? Select { get; set; }
        public string? Filter { get; set; }
        public bool PreferMinimal { get; set; }
    }
}