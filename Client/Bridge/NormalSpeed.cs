using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsocketClient.Bridge
{
    class NormalSpeed : Iimplementor
    {
        private float SpeedModifier = 1.5f;

        public float getSpeedModifier()
        {
            return SpeedModifier;
        }
    }
}
