using System;
using System.Net.Http.Headers;

namespace SlimGraph
{
    public class SlimGraphPicture
    {
        public SlimGraphPicture(ReadOnlyMemory<byte> data, MediaTypeHeaderValue contentType)
        {
            Data = data;
            ContentType = contentType;
        }

        public ReadOnlyMemory<byte> Data { get; }
        public MediaTypeHeaderValue ContentType { get; }
    }
}