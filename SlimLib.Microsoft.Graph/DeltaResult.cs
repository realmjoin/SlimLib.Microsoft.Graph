using System;
using System.Collections.Generic;

namespace SlimLib.Microsoft.Graph
{
    public class DeltaResult<T>
    {
        public DeltaResult(IList<T> items, string? deltaLink)
        {
            Items = items ?? throw new ArgumentNullException(nameof(items));
            DeltaLink = deltaLink;
        }

        public IList<T> Items { get; }
        public string? DeltaLink { get; }
    }
}