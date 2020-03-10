using System;
using System.Collections.Generic;

namespace SlimGraph
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