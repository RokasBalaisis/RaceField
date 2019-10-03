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

        public MoveTurn(bool isLeftPressed, bool isRightPressed)
        {
            this.isLeftPressed = isLeftPressed;
            this.isRightPressed = isRightPressed;
        }

        public void Move()
        {          
            if (isLeftPressed == true && isRightPressed == false)
            {
                Form1.angle -= 10;                
            }
            else if (isRightPressed == true && isLeftPressed == false)
            {
                Form1.angle += 10;
            } 
        }
    }
}
