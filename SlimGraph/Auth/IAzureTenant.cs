using System;

namespace SlimGraph.Auth
{
    public interface IAzureTenant
    {
        Uri TokenUrl { get; }
    }
}