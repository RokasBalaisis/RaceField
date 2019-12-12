namespace WebSocketServerWorking.Collectables
{
    class SpriteVisitor : Visitor
    {
        public double visit(Bomb bomb)
        {
            int durationIndex = bomb.duration < Collectable.durationList[0]
                ? 0
                : Collectable.durationList.Count - 1;
            int strengthIndex = bomb.effectStrength < Collectable.effectStrengthList[0]
                ? 0
                : Collectable.effectStrengthList.Count - 1;

            for (int i = 0; i < Collectable.durationList.Count - 2; i++)
            {
                if (Collectable.durationList[i] <= bomb.duration && bomb.duration < Collectable.durationList[i + 1])
                    durationIndex = i;
                if (Collectable.effectStrengthList[i] <= bomb.effectStrength &&
                    bomb.effectStrength < Collectable.effectStrengthList[i + 1])
                    strengthIndex = i;
            }

            return (int) (durationIndex * 0.5 + strengthIndex * 0.5);
        }

        public double visit(SpeedBoost speedBoost)
        {
            int durationIndex = speedBoost.duration < Collectable.durationList[0]
                ? 0
                : Collectable.durationList.Count - 1;
            int strengthIndex = speedBoost.effectStrength < Collectable.effectStrengthList[0]
                ? 0
                : Collectable.effectStrengthList.Count - 1;

            for (int i = 0; i < Collectable.durationList.Count - 2; i++)
            {
                if (Collectable.durationList[i] <= speedBoost.duration &&
                    speedBoost.duration < Collectable.durationList[i + 1])
                    durationIndex = i;
                if (Collectable.effectStrengthList[i] <= speedBoost.effectStrength &&
                    speedBoost.effectStrength < Collectable.effectStrengthList[i + 1])
                    strengthIndex = i;
            }

            return (int) (durationIndex * 0.5 + strengthIndex * 0.5);
        }
    }
}