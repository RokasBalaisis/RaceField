using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace WebSocketServerWorking
{
    class TimerAdapter
    {
        Timer adaptee;

        public TimerAdapter(Action<object> action, int interval)
        {
            adaptee = new Timer(new TimerCallback(action), null, 0, interval);
        }
    }
}
