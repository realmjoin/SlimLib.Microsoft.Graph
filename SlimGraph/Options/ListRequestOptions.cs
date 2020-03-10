using System;
using System.Collections.Generic;

namespace SlimGraph
{
    public struct ListRequestOptions : ILinkBuilder
    {
        public ListRequestOptions(string select, string filter, string search, string expand, string orderBy, bool count, int skip, int top)
        {
            Select = select ?? throw new ArgumentNullException(nameof(select));
            Filter = filter ?? throw new ArgumentNullException(nameof(filter));
            Search = search ?? throw new ArgumentNullException(nameof(search));
            Expand = expand ?? throw new ArgumentNullException(nameof(expand));
            OrderBy = orderBy ?? throw new ArgumentNullException(nameof(orderBy));
            Count = count;
            Skip = skip;
            Top = top;
        }

        public string? Select { get; set; }
        public string? Filter { get; set; }
        public string? Search { get; set; }
        public string? Expand { get; set; }
        public string? OrderBy { get; set; }
        public bool? Count { get; set; }
        public int? Skip { get; set; }
        public int? Top { get; set; }

        public string BuildLink(string call)
        {
            var args = new List<string>();

            if (Select != null)
                args.Add("$select=" + Uri.EscapeDataString(Select));

            if (Filter != null)
                args.Add("$filter=" + Uri.EscapeDataString(Filter));

            if (Search != null)
                args.Add("$search=" + Uri.EscapeDataString(Search));

            if (Expand != null)
                args.Add("$expand=" + Uri.EscapeDataString(Expand));

            if (OrderBy != null)
                args.Add("$orderby=" + Uri.EscapeDataString(OrderBy));

            if (Count != null)
                args.Add("$count=" + (Count.Value ? "true" : "false"));

            if (Skip != null)
                args.Add("$skip=" + Skip);

            if (Top != null)
                args.Add("$top=" + Top);

            return RequestOptions.BuildLink(call, args);
        }
    }
}