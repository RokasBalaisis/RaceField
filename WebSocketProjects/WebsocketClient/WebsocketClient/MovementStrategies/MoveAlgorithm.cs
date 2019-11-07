using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebsocketClient.Bridge;

namespace WebsocketClient
{
    public abstract class MoveAlgorithm
    {       

        public Iimplementor mode;

        public abstract void Move();
        

    }
}
