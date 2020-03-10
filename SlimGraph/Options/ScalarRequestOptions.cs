using System;
using System.Collections.Generic;

namespace SlimGraph
{
    public struct ScalarRequestOptions : ILinkBuilder
    {
        public ScalarRequestOptions(string select, string expand)
        {
            Select = select ?? throw new ArgumentNullException(nameof(select));
            Expand = expand ?? throw new ArgumentNullException(nameof(expand));
        }

        public string? Select { get; set; }
        public string? Expand { get; set; }

        public string BuildLink(string call)
        {
            var args = new List<string>();

            if (Select != null)
                args.Add("$select=" + Uri.EscapeDataString(Select));

            if (Expand != null)
                args.Add("$expand=" + Uri.EscapeDataString(Expand));

            return RequestOptions.BuildLink(call, args);
        }
    }
}