using System;

namespace CustomSecurity.Common
{
    public interface IDateTime
    {
        DateTime UtcNow { get; }
    }
}