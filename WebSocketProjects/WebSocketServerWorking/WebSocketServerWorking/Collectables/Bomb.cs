using System;

namespace WebSocketServerWorking.Collectables
{
    class Bomb : Collectable, IPrototype
    {
        public Bomb(string var = "medium")
        {
            ChangeVariant(var);
        }

        public override void ApplyEffect()
        {
            throw new NotImplementedException();
        }

        public override void RemoveEffect()
        {
            throw new NotImplementedException();
        }

        public bool ChangeVariant(string variant, int durationMilliseconds = 0, double strength = 0.0)
        {
            switch (variant)
            {
                case "light":
                    duration = 100;
                    effectStrength = 0.2;
                    spriteName = variant;
                    break;
                case "medium":
                    duration = 300;
                    effectStrength = 0.4;
                    spriteName = variant;
                    break;
                case "heavy":
                    duration = 800;
                    effectStrength = 0.8;
                    spriteName = variant;
                    break;
                case "nuclear":
                    duration = 5000;
                    effectStrength = 2;
                    spriteName = variant;
                    break;
                default:
                    if (durationMilliseconds <= 0 || strength <= 0)
                        throw new ArgumentOutOfRangeException(nameof(variant), variant, "Custom variant must have duration and strength specified and above 0");
                    duration = duration;
                    effectStrength = strength;
                    spriteName = "";
                    break;
            }

            return true;
        }

        public IPrototype Clone()
        {
            return (IPrototype) MemberwiseClone();
        }
    }
}