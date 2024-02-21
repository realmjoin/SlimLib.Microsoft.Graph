namespace SlimLib.Microsoft.Graph
{
    public class RequestHeaderOptions
    {
        public bool PreferMinimal { get; set; }
        public bool ConsistencyLevelEventual { get; set; }
        public string? UserAgent { get; set; }
    }
}