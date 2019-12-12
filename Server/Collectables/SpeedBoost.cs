using System;
using System.Collections.Generic;

namespace WebSocketServerWorking.Collectables
{
    class SpeedBoost : Collectable, Visitable
    {
        public static List<string> spriteNameList = new List<string>
        {
            "small",
            "medium",
            "big",
            "Sonic"
        };

        public SpeedBoost(int durationMilliseconds = 5000, double effectStrength = 0.2)
        {
            ChangeVariant(durationMilliseconds, effectStrength);
            ChangeSprite(0);
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

        public bool ChangeVariant(int durationMilliseconds = 0, double strength = 0.0)
        {
            duration = durationMilliseconds;
            effectStrength = strength;

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