using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsocketClient.Logging
{
    public abstract class LoggerBase
    {
        protected LogType logMask;

        // The next Handler in the chain
        protected LoggerBase next;

        public LoggerBase(LogType mask)
        {
            this.logMask = mask;
        }

        /// <summary>
        /// Sets the Next logger to make a list/chain of Handlers.
        /// </summary>
        public LoggerBase SetNext(LoggerBase nextlogger)
        {
            LoggerBase lastLogger = this;

            while (lastLogger.next != null)
            {
                lastLogger = lastLogger.next;
            }

            lastLogger.next = nextlogger;
            return this;
        }

        public void Message(string msg, LogType severity)
        {
            if ((severity & logMask) != 0) //True only if any of the logMask bits are set in severity
            {
                WriteMessage(msg);
            }
            if (next != null)
            {
                next.Message(msg, severity);
            }
        }

        abstract protected void WriteMessage(string msg);
    }
}
