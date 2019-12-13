using System;

namespace WebsocketClient
{
    class SpeedBoost : Collectable
    {
        public SpeedBoost(int duration, double strength)
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