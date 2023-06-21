using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace SlimLib.Microsoft.Graph
{
    public class ListRequestOptions
    {
        public string? Select { get; set; }
        public HashSet<string> SelectList { get; } = new();
        public string? Filter { get; set; }
        public string? Search { get; set; }
        public string? Expand { get; set; }
        public string? OrderBy { get; set; }
        public bool? Count { get; set; }
        public int? Skip { get; set; }
        public int? Top { get; set; }
        public bool ConsistencyLevelEventual { get; set; }

        public JsonObject ToJson()
        {
            var json = new JsonObject();

            if (Select is not null)
            {
                throw new NotSupportedException($"{nameof(Select)} is not supported when using JSON. Use {nameof(SelectList)} instead.");
            }
            else
            {
                if (SelectList.Count > 0)
                {
                    var list = new JsonArray();

                    foreach (var item in SelectList)
                        list.Add(JsonValue.Create(item));

                    json.Add("select", list);
                }
            }

            if (Filter is not null)
                json.Add("filter", Filter);

            if (Search is not null)
                json.Add("search", Search);

            if (Expand is not null)
                json.Add("expand", Expand);

            if (OrderBy is not null)
                json.Add("orderBy", OrderBy);

            if (Count is not null)
                json.Add("count", Count.Value);

            if (Skip is not null)
                json.Add("skip", Skip.Value);

            if (Top is not null)
                json.Add("top", Top.Value);

            if (ConsistencyLevelEventual)
                json.Add("consistencyLevel", "eventual");

            return json;
        }

        public event EventHandler<JsonEventArgs>? PageReceived;

        internal void OnPageReceived(JsonElement element)
        {
            PageReceived?.Invoke(this, new JsonEventArgs(element));
        }
    }
}