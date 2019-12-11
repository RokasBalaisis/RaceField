using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsocketClient
{
    public class GameObjectsIterator: GameIterator
    {
        private GameObjectsAggregate _aggregate;
        private int _current = 0;

        // Constructor
        public GameObjectsIterator(GameObjectsAggregate aggregate)
        {
            this._aggregate = aggregate;
        }

        // Gets first iteration item
        public IterableViewObject First()
        {
            if (_aggregate.Count == 0)
            {
                return null;
            }
            return _aggregate[0];
        }

        // Gets next iteration item
        public IterableViewObject Next()
        {
            IterableViewObject ret = null;
            if (_current < _aggregate.Count - 1)
            {
                ret = _aggregate[++_current];
            }
            return ret;
        }

        public bool HasNext()
        {
            return _current < _aggregate.Count - 1;
        }
    }
}
