using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsocketClient.State
{
    class MoveTurnState : MoveState
    {
        private bool isRightPressed;
        private bool isLeftPressed;
        private bool isDownPressed;

        public MoveTurnState(bool isLeftPressed, bool isRightPressed, bool isDownPressed)
        {
            this.isLeftPressed = isLeftPressed;
            this.isRightPressed = isRightPressed;
            this.isDownPressed = isDownPressed;
        }

        public void Move(MoveStateContext ctx)
        {

            if (!isDownPressed)
            {
                if (isLeftPressed == true && isRightPressed == false)
                {
                    MyPlayer.angle -= 10;
                }
                else if (isRightPressed == true && isLeftPressed == false)
                {
                    MyPlayer.angle += 10;
                }
            }
            else
            {
                if (isLeftPressed == true && isRightPressed == false)
                {
                    MyPlayer.angle += 10;
                }
                else if (isRightPressed == true && isLeftPressed == false)
                {
                    MyPlayer.angle -= 10;
                }
            }
        }
    }
}
