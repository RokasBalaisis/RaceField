using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsocketClient
{
    class Bomb : Collectable
    {
        public Bomb(int duration = 1, double strength = 0.5)
        {
            durationMilliseconds = duration;
            this.strength = strength;
        }

        public override void ApplyEffect()
        {
            throw new NotImplementedException();
        }

        public override void RemoveEffect()
        {
            throw new NotImplementedException();
        }
    }
}