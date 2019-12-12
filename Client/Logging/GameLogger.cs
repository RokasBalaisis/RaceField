using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsocketClient.Logging
{
    public class GameLogger : LoggerBase
    {
        private TransparentTextLog textLog;
        public GameLogger(LogType mask, TransparentTextLog textLog) : base(mask)
        {
            this.textLog = textLog;
        }
        protected override void WriteMessage(string msg)
        {
            textLog.Select(textLog.TextLength, textLog.TextLength);
            textLog.SelectedRtf = string.Format(@"{{\rtf1\ansi \plain {0} \plain0 \par }}", msg);
            textLog.ScrollToCaret();
        }
    }
}
