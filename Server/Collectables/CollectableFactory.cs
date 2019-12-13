using System;
using System.Collections.Generic;

namespace WebSocketServerWorking.Collectables
{
    class CollectableFactory : Factory
    {
        private Dictionary<Collectable.Type, Collectable> _currentCollectables;

        Random random = new Random();

        public DurationLongVisitor durationLongVisitor = new DurationLongVisitor();
        public DurationShortVisitor durationShortVisitor = new DurationShortVisitor();
        public StrengthHighVisitor strengthHighVisitor = new StrengthHighVisitor();
        public StrengthLowVisitor strengthLowVisitor = new StrengthLowVisitor();
        public SpriteVisitor spriteVisitor = new SpriteVisitor();

        public CollectableFactory()
        {
            _currentCollectables = new Dictionary<Collectable.Type, Collectable>();
        }

        public override Collectable GetCollectable(Collectable.Type type)
        {
            return GetCollectable(type, Bomb.Variant.Medium);
        }

        public Collectable GetCollectable(Collectable.Type type, Bomb.Variant bombVariant)
        {
            if (!_currentCollectables.ContainsKey(type))
                switch (type)
                {
                    case Collectable.Type.Bomb:
                        _currentCollectables[type] = new Bomb(bombVariant, 1, 0.5);
                        break;
                    case Collectable.Type.SpeedBoost:
                        _currentCollectables[type] = new SpeedBoost(1, 0.5);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(type), type, "Unknown type of collectable");
                }

            return _currentCollectables[type];
        }

        public Collectable GetRandomCollectable()
        {
            dynamic c = GetCollectable(random.Next(2) > 0 ? Collectable.Type.Bomb : Collectable.Type.SpeedBoost);
            c = Convert.ChangeType(c, c.GetType());

            double duration = 0;
            double strength = 0;

            switch (random.Next(3))
            {
                case 0:
                    duration = c.modify(durationShortVisitor);
                    break;
                case 1:
                    duration = c.duration;
                    break;
                case 2:
                    duration = c.modify(durationLongVisitor);
                    break;
            }

            switch (random.Next(3))
            {
                case 0:
                    strength = c.modify(strengthLowVisitor);
                    break;
                case 1:
                    strength = c.effectStrength;
                    break;
                case 2:
                    strength = c.modify(strengthHighVisitor);
                    break;
            }

            dynamic newCollectable = null;

            switch (c)
            {
                case Bomb b:
                    newCollectable = new Bomb(Bomb.Variant.Custom, (int) duration, strength);
                    newCollectable.ChangeSprite((int) b.modify(spriteVisitor));
                    break;
                case SpeedBoost s:
                    newCollectable = new SpeedBoost((int) duration, strength);
                    newCollectable.ChangeSprite((int) s.modify(spriteVisitor));
                    break;
            }

            return newCollectable;
        }
    }
}