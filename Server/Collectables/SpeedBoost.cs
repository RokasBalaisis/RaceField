using System;

namespace WebSocketServerWorking.Collectables
{
    class SpeedBoost : Collectable, IPrototype
    {
        public SpeedBoost(int durationMilliseconds = 5000, double effectStrength = 0.2)
        {
            duration = duration;
            this.effectStrength = effectStrength;
        }

        public override void Animate()
        {
            throw new NotImplementedException();
        }

        public override void ApplyEffect()
        {
            throw new NotImplementedException();
        }

        public override void RemoveEffect()
        {
            throw new NotImplementedException();
        }

        public void ChangeVariant()
        {
            throw new NotImplementedException();
        }

        public IPrototype Clone()
        {
            return (IPrototype) MemberwiseClone();
        }
    }
}