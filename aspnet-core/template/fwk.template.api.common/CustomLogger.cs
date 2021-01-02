
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pelsoft.api.common
{
    //https://www.youtube.com/watch?v=PnlxRmHg0lU&t=51s
    public class CustomLogger : ICustomLogger
    {
        private static CustomLogger instance;
        //static var to hold single instance of nLog logger
        private static Logger _nlog_logger;//= LogManager.GetLogger("importFacturas");
        static CustomLogger()
        {

        }

        /// <summary>
        /// Single design pattern 
        /// </summary>
        CustomLogger()
        {

        }
        public static CustomLogger GetInstance()
        {
            if (instance == null)
            {
                instance = new CustomLogger();
            }
            return instance;
        }
        private Logger  GetLogger(string theLogger)
        {
            if (_nlog_logger == null)
            {
                _nlog_logger   = LogManager.GetLogger("importFacturas");
            }
            return _nlog_logger;
        }
        public void Debug(string message, string arg = null)
        {
            if (arg == null)
            {
                GetLogger("importFacturas").Debug(message);
            }else
            {
                GetLogger("importFacturas").Debug(message,arg);
            }
        }

        public void Error(string message, string arg = null)
        {
            if (arg == null)
            {
                GetLogger("importFacturas").Debug(message);
            }
            else
            {
                GetLogger("importFacturas").Debug(message, arg);
            }
        }

        public void Info(string message, string arg = null)
        {
            if (arg == null)
            {
                GetLogger("importFacturas").Error(message);
            }
            else
            {
                GetLogger("importFacturas").Error(message, arg);
            }
        }

        public void Warning(string message, string arg = null)
        {
            if (arg == null)
            {
                GetLogger("importFacturas").Warn(message);
            }
            else
            {
                GetLogger("importFacturas").Warn(message, arg);
            }
        }
    }
}
