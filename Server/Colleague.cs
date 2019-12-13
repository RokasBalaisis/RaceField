using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSocketServerWorking
{
    public abstract class Colleague
    {
        public Mediator mediator;

        public Colleague(Mediator mediator)
        {
            this.mediator = mediator;
        }

    }
}
