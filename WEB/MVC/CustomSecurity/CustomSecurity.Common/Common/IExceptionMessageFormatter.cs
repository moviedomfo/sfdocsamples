using System;

namespace CustomSecurity.Common
{
    public interface IExceptionMessageFormatter
    {
        string GetEntireExceptionStack(Exception ex);
    }
}