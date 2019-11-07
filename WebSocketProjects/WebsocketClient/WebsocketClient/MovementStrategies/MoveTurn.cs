using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebsocketClient
{
    class MoveTurn : MoveAlgorithm
    {
        private bool isRightPressed;
        private bool isLeftPressed;
        private bool isDownPressed;

        public MoveTurn(bool isLeftPressed, bool isRightPressed, bool isDownPressed)
        {
            this.isLeftPressed = isLeftPressed;
            this.isRightPressed = isRightPressed;
            this.isDownPressed = isDownPressed;
        }

        public override void Move()
        {          
            //if (isLeftPressed == true && isRightPressed == false)
            //{
            //    Form1.angle -= 10;                
            //}
            //else if (isRightPressed == true && isLeftPressed == false)
            //{
            //    Form1.angle += 10;
            //}
            if(!isDownPressed)
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
