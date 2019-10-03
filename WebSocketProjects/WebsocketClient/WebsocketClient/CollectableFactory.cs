using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsocketClient
{
    class CollectableFactory : Factory
    {
        public override Collectable GetCollectable(Collectable.Type type)
        {
            switch (type)
            {
                case Collectable.Type.Bomb:
                    return new Bomb();
                case Collectable.Type.SpeedBoost:
                    return new SpeedBoost();
                default:
                    return null;
            }
        }
    }
}