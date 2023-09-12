using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BenchmarkBibleVerseApp.Service.Utility
{
    /*
     * ILogger interface declares methods for various log levels.
     */
    public interface ILogger
    {
        /*
         * method is used for logging debug-level messages. 
         * It accepts a message string as a parameter and an optional arg parameter, 
         * which can be used to provide additional context or information.
         */
        void Debug(String message, String arg = null);

        /*
         * This method is used for logging informational messages. Like the Debug method, it also accepts a 
         * message string and an optional arg parameter.
         */
        void Info(String message, String arg = null);
        /*
         * This method is used for logging warning messages. 
         * It accepts a message string and an optional arg parameter.
         */
        void Warning(String message, String arg = null);

        /*
         * method is used for logging error messages. 
         * It accepts a message string and an optional arg parameter.
         */
        void Error(String message, String arg = null);
    }
}