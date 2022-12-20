using System;

namespace SlimLib.Microsoft.Graph
{
    public readonly record struct TypedMember(string Type, Guid ID)
    {
        public static implicit operator (string Type, Guid ID)(TypedMember value)
        {
            return (value.Type, value.ID);
        }

        public static implicit operator TypedMember((string Type, Guid ID) value)
        {
            return new TypedMember(value.Type, value.ID);
        }

        public override string ToString()
        {
            return $"{Type}/{ID}";
        }
    }
}