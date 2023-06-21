using System;
using System.Collections.Generic;

namespace SlimLib.Microsoft.Graph.Results.Delta
{
    public class DeltaResult<T>
    {
        public DeltaResult(IReadOnlyList<T> items, string? deltaLink)
        {
            Items = items ?? throw new ArgumentNullException(nameof(items));
            DeltaLink = deltaLink;
        }

        public IReadOnlyList<T> Items { get; }
        public string? DeltaLink { get; }
    }
}