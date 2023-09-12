using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BenchmarkBibleVerseApp.Service.Utility
{
    public class MyLogger : ILogger
    {
        /*
         * This field is a static reference to an instance of the 
         * MyLogger class. It's used to implement a singleton pattern to 
         * ensure that only one instance of MyLogger is created.
         */
        private static MyLogger instance;

        /*
         * This field is a static reference to a Logger object from the log4net library. 
         * It's used to perform the actual logging operations.
         */
        private static Logger logger;

        //Empty constructor
        public MyLogger()
        {

        }

        /*
         * returns an instance of the MyLogger class. It implements the singleton pattern by checking
         * if the instance field is null. If it's null, a new instance of MyLogger is created and assigned 
         * to instance, which ensures that subsequent calls to GetInstance return the same instance
         */
        public static MyLogger GetInstance()
        {
            if (instance == null)
            {
                instance = new MyLogger();
            }
            return instance;
        }

        /*
        *  responsible for initializing and returning a Logger object from log4net. 
        *  It accepts a theLogger parameter, which represents the name of the logger to retrieve. 
        *  If the logger field is null, it initializes it using LogManager.GetLogger(theLogger) 
        *  and returns the logger.
        */
        private Logger GetLogger(String theLogger)
        {
            if (MyLogger.logger == null)
            {
                MyLogger.logger = LogManager.GetLogger(theLogger);
            }
            return MyLogger.logger;
        }

        /*
        * Logs a message at the Debug log level. If an optional arg parameter is provided, 
        * it logs the message with the argument.
        */
        public void Debug(string message, string arg = null)
        {
            if (arg == null)
            {
                GetLogger("myAppLoggerRule").Debug(message);
            }
            else
            {
                GetLogger("myAppLoggerRule").Debug(message, arg);
            }
        }

        /*
        *  Logs a message at the Error log level. If an optional arg parameter is provided,
        *  it logs the message with the argument.
        */
        public void Error(string message, string arg = null)
        {
            if (arg == null)
            {
                GetLogger("myAppLoggerRule").Error(message);
            }
            else
            {
                GetLogger("myAppLoggerRule").Error(message, arg);
            }
        }

        /*
        * Logs a message at the Info log level. If an optional arg parameter is provided,
        * it logs the message with the argument.
        */
        public void Info(string message, string arg = null)
        {
            if (arg == null)
            {
                GetLogger("myAppLoggerRule").Info(message);
            }
            else
            {
                GetLogger("myAppLoggerRule").Info(message, arg);
            }
        }

        /*
        * Logs a message at the Warning log level. If an optional arg parameter is provided,
        * it logs the message with the argument.
        */
        public void Warning(string message, string arg = null)
        {
            if (arg == null)
            {
                GetLogger("myAppLoggerRule").Warn(message);
            }
            else
            {
                GetLogger("myAppLoggerRule").Warn(message, arg);
            }
        }
    }
}