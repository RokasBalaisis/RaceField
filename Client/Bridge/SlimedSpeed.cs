using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsocketClient.Bridge
{
    class SlimedSpeed : Iimplementor
    {
        private float SpeedModifier = 0.5f;

        public float getSpeedModifier()
        {
            return SpeedModifier;
        }
    }
}
