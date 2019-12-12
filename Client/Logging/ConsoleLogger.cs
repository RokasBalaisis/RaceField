using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsocketClient.Logging
{
    public class ConsoleLogger : LoggerBase
    {
        public ConsoleLogger(LogType mask) : base(mask)
        { }
        protected override void WriteMessage(string msg)
        {
            throw new NotImplementedException();
        }
    }
}
