using System;

namespace WebSocketServerWorking.Collectables
{
    class CollectableFactory : Factory
    {
        private readonly Bomb _bomb;
        private readonly SpeedBoost _speedBoost;

        public CollectableFactory()
        {
            _bomb = (Bomb) GetCollectable(Collectable.Type.Bomb);
            _speedBoost = (SpeedBoost) GetCollectable(Collectable.Type.SpeedBoost);
        }

        public override Collectable GetCollectable(Collectable.Type type)
        {
            return GetCollectable(type, Bomb.Variant.Medium);
        }

        public Collectable GetCollectable(Collectable.Type type, Bomb.Variant bombVariant)
        {
            switch (type)
            {
                case Collectable.Type.Bomb:
                    try
                    {
                        var temp = (Bomb) _bomb.Clone();
                        temp.ChangeVariant(bombVariant);
                        return  temp;
                    }
                    catch (NullReferenceException)
                    {
                        return new Bomb(bombVariant);
                    }
                case Collectable.Type.SpeedBoost:
                    try
                    {
                        var temp = (SpeedBoost) _speedBoost.Clone();
                        return  temp;
                    }
                    catch (NullReferenceException)
                    {
                        return new SpeedBoost();
                    }
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, "Unknown type of collectable");
            }
        }
    }
}