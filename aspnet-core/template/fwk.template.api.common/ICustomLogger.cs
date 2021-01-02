namespace pelsoft.api.common
{
    public interface ICustomLogger
    {
        void Debug(string message, string arg = null);
        void Info(string message, string arg = null);
        void Warning(string message, string arg = null);
        void Error(string message, string arg = null);
    }
}