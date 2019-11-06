using System;

namespace WebSocketServerWorking.Collectables
{
    class SpeedBoost : Collectable
    {
        public SpeedBoost(int duration = 1, double strength = 0.5)
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