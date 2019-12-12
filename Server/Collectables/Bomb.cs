using System;
using System.Collections.Generic;

namespace WebSocketServerWorking.Collectables
{
    class Bomb : Collectable, Visitable
    {
        public enum Variant // variants of bombs that are allowed
        {
            Light,
            Medium,
            Heavy,
            Nuclear,
            Custom
        }

        public static List<string> spriteNameList = new List<string>
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

        public bool ChangeVariant(Variant variant, int durationMilliseconds = 0, double strength = 0.0)
        {
            if (variant == Variant.Custom)
            {
                if (durationMilliseconds <= 0 || strength <= 0)
                    throw new ArgumentOutOfRangeException(nameof(variant), variant,
                        "Custom variant must have duration and strength specified and above 0");
                duration = durationMilliseconds;
                effectStrength = strength;
                ChangeSprite(0);
            }
            else
            {
                duration = durationList[(int) variant];
                effectStrength = effectStrengthList[(int) variant];
                spriteName = spriteNameList[(int) variant];
            }

            return true;
        }

        public void ChangeSprite(int spriteIndex)
        {
            if (spriteIndex < 0 || spriteIndex + 1 > spriteNameList.Count)
                spriteName = spriteNameList[0];
            else
                spriteName = spriteNameList[spriteIndex];
        }

        public void modify(Visitor visitor)
        {
            visitor.visit(this);
        }
    }
}