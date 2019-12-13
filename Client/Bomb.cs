using System;

namespace WebsocketClient
{
    class Bomb : Collectable
    {
        public Bomb(int duration, double strength)
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