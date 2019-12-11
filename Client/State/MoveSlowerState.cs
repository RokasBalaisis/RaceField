using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsocketClient.State
{
    class MoveSlowerState : MoveState
    {
        public void Move(MoveStateContext ctx)
        {
            if (MyPlayer.mod >= -0.9)
            {
                MyPlayer.mod -= 0.1;
            }
        }
    }
}
