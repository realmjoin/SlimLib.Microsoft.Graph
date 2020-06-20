using System;
using System.Text.Json;

namespace SlimGraph
{
    public class JsonEventArgs : EventArgs
    {
        public JsonEventArgs(JsonElement element)
        {
            Element = element;
        }

        public JsonElement Element { get; }
    }
}