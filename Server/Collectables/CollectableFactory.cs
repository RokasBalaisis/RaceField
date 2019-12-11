using System;
using System.Collections.Generic;

namespace WebSocketServerWorking.Collectables
{
    class CollectableFactory : Factory
    {
        private Dictionary<Collectable.Type, Collectable> _currentCollectables;

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
                        _currentCollectables[type] = new Bomb(bombVariant);
                        break;
                    case Collectable.Type.SpeedBoost:
                        _currentCollectables[type] = new SpeedBoost();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(type), type, "Unknown type of collectable");
                }

            return _currentCollectables[type];
        }
    }
}