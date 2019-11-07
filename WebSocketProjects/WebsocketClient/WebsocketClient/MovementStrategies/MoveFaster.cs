using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebsocketClient
{
    class MoveFaster : MoveAlgorithm
    {
        
        public void Move()
        {
            //if (Form1.mod <= 0.9)
            //{
            //    Form1.mod += 0.1;
            //}

            if (MyPlayer.mod <= 0.9)
            {
                MyPlayer.mod += 0.1;
            }
        }
    }
}
