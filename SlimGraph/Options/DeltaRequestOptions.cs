using System;
using System.Collections.Generic;

namespace SlimGraph
{
    public struct DeltaRequestOptions : ILinkBuilder
    {
        public DeltaRequestOptions(string select, string filter, bool preferMinimal)
        {
            Select = select ?? throw new ArgumentNullException(nameof(select));
            Filter = filter ?? throw new ArgumentNullException(nameof(filter));
            PreferMinimal = preferMinimal;
        }

        public string? Select { get; set; }
        public string? Filter { get; set; }
        public bool PreferMinimal { get; set; }

        public string BuildLink(string call)
        {
            var args = new List<string>();

            if (Select != null)
                args.Add("$select=" + Uri.EscapeDataString(Select));

            if (Filter != null)
                args.Add("$filter=" + Uri.EscapeDataString(Filter));

            return RequestOptions.BuildLink(call, args);
        }
    }
}