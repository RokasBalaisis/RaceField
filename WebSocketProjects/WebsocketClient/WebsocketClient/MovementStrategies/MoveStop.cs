using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebsocketClient
{
    class MoveStop : MoveAlgorithm
    {       
        public override void Move()
        {
            //if (Form1.mod == 0)
            //{
            //    Form1.mod = 0;
            //}
            //else if (Form1.mod > 0.1)
            //{
            //    Form1.mod -= 0.1;
            //}
            //else if (Form1.mod < -0.1)
            //{
            //    Form1.mod += 0.1;
            //}

            if (MyPlayer.mod == 0)
            {
                MyPlayer.mod = 0;
            }
            else if (MyPlayer.mod > 0.1 * mode.getSpeedModifier())
            {
                MyPlayer.mod -= 0.1 * mode.getSpeedModifier();
            }
            else if (MyPlayer.mod < -0.1 * mode.getSpeedModifier())
            {
                MyPlayer.mod += 0.1 * mode.getSpeedModifier();
            }
        }
    }
}
