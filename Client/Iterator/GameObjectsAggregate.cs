using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsocketClient
{
    public class GameObjectsAggregate: Aggregate
    {
        List<IterableViewObject> items;
        public GameObjectsAggregate(List<Obstacle> obstacles, List<Collectable> collectables, List<Player> players)
        {
            items = new List<IterableViewObject>();
            foreach(IterableViewObject item in obstacles)
            {
                items.Add(item);
            }
            foreach (IterableViewObject item in collectables)
            {
                items.Add(item);
            }
            foreach (IterableViewObject item in players)
            {
                items.Add(item);
            }
        }

        public GameIterator CreateIterator()
        {
            return new GameObjectsIterator(this);
        }

        // Indexer
        public IterableViewObject this[int index]
        {
            get { return items[index]; }
            set { items.Insert(index, value); }
        }

        public int Count
        {
            get { return items.Count; }
        }
    }
}
