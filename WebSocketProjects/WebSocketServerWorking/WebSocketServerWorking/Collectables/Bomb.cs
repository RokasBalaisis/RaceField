using System;
using System.Collections.Generic;
using System.Linq;

namespace WebSocketServerWorking.Collectables
{
    class Bomb : Collectable, IPrototype
    {
        public enum Variant // variants of bombs that are allowed
        {
            Light,
            Medium,
            Heavy,
            Nuclear,
            Custom
        }

        List<int> durationList = new List<int>
        {
            100,
            300,
            800,
            5000
        };

        List<double> effectStrengthList = new List<double>
        {
            0.2,
            0.4,
            0.8,
            2
        };

        List<string> spriteNameList = new List<string>
        {
            "light",
            "medium",
            "heavy",
            "nuclear"
        };

        public Bomb(Variant var, int durationMilliseconds = 0, double strength = 0.0)
        {
            ChangeVariant(var, durationMilliseconds, strength);
        }

        public override void ApplyEffect()
        {
            throw new NotImplementedException();
        }

        public override void RemoveEffect()
        {
            throw new NotImplementedException();
        }

        public bool ChangeVariant(Variant variant, int durationMilliseconds = 0, double strength = 0.0)
        {
            if (variant == Variant.Custom)
            {
                if (durationMilliseconds <= 0 || strength <= 0)
                    throw new ArgumentOutOfRangeException(nameof(variant), variant,
                        "Custom variant must have duration and strength specified and above 0");
                duration = durationMilliseconds;
                effectStrength = strength;
            }
            else
            {
                duration = durationList[(int) variant];
                effectStrength = effectStrengthList[(int) variant];
            }

            spriteName = decideSpriteName(durationMilliseconds, strength);

            return true;
        }

        string decideSpriteName(int durationMilliseconds, double strength)
        {
            int durationIndex = durationMilliseconds < durationList[0] ? 0 : durationList.Count - 1;
            int strengthIndex = strength < effectStrengthList[0] ? 0 : effectStrengthList.Count - 1;

            for (int i = 0; i < durationList.Count - 2; i++)
            {
                if (durationList[i] <= durationMilliseconds && durationMilliseconds < durationList[i + 1])
                    durationIndex = i;
                if (effectStrengthList[i] <= strength && strength < effectStrengthList[i + 1])
                    strengthIndex = i;
            }

            int index = (int) (durationIndex * 0.5 + strengthIndex * 0.5);
            return spriteNameList[index];
        }

        public IPrototype Clone()
        {
            return (IPrototype) MemberwiseClone();
        }
    }
}