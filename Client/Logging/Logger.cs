using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsocketClient.Logging
{
    public enum LogType
    {
        None = 0,                 //        0
        Info = 1,                 //        1
        Debug = 2,                //       10
        Warning = 4,              //      100
        Error = 8,                //     1000
        FunctionalMessage = 16,   //    10000
        FunctionalError = 32,     //   100000
        All = 63                  //   111111
    }
    public class Logger
    {
        private TransparentTextLog textLog;
        private LoggerBase logger;
        public Logger(TransparentTextLog textLog)
        {
            this.textLog = textLog;
            // build chain of responsibility
            logger = new ConsoleLogger(LogType.All).SetNext(
                new GameLogger(LogType.FunctionalError | LogType.FunctionalMessage, textLog)).SetNext(
                new EmailLogger(LogType.Error | LogType.Debug | LogType.Warning)).SetNext(
                new DataBaseLogger(LogType.Info | LogType.Warning | LogType.Debug | LogType.None));
        }

        public void log(String message, LogType logType)
        {
            logger.Message(message, logType);
        }
    }
}
