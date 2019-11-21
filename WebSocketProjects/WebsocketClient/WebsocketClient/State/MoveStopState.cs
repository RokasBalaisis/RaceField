using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsocketClient.State
{
    class MoveStopState : MoveState
    {
        public void Move(MoveStateContext ctx)
        {
            if (MyPlayer.mod == 0)
            {
                MyPlayer.mod = 0;
            }
            else if (MyPlayer.mod > 0.1)
            {
                MyPlayer.mod -= 0.1;
            }
            else if (MyPlayer.mod < -0.1)
            {
                MyPlayer.mod += 0.1;
            }
        }
    }
}
