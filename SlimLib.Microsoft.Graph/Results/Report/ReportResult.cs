using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text.Json;

namespace SlimLib.Microsoft.Graph.Results.Report
{
    public class ReportResult
    {
        public static ReportResult Create(JsonDocument result)
        {
            using (result)
            {
                return JsonSerializer.Deserialize<ReportResult>(result) ?? throw new SlimGraphException(0, null, "Unkown error", "");
            }
        }

        public int TotalRowCount { get; set; }
        public IReadOnlyList<Schema>? Schema { get; set; }
        public IReadOnlyList<IReadOnlyList<JsonElement>>? Values { get; set; }
        public string? SessionId { get; set; }

        public IEnumerable<dynamic> ToDynamicResult()
        {
            if (Schema is null) yield break;
            if (Values is null) yield break;

            foreach (var item in Values)
            {
                var data = new ExpandoObject();

                for (var i = 0; i < Schema.Count; i++)
                {
                    var value = item[i];
                    var type = Type.GetType("System." + Schema[i].PropertyType);

                    if (type is null)
                        continue;

                    var column = Schema[i].Column;

                    if (column is not null)
                    {
                        if (value.ValueKind == JsonValueKind.String && type != typeof(string) && value.ValueEquals(ReadOnlySpan<byte>.Empty))
                            data.TryAdd(column, Activator.CreateInstance(type));
                        else if (value.ValueKind == JsonValueKind.True)
                            data.TryAdd(column, true);
                        else if (value.ValueKind == JsonValueKind.False)
                            data.TryAdd(column, false);
                        else if (value.ValueKind == JsonValueKind.Null)
                            data.TryAdd(column, null);
                        else
                            data.TryAdd(column, JsonSerializer.Deserialize(value, type));
                    }
                }

                yield return data;
            }
        }
    }
}
