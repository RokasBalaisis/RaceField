using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSocketServerWorking
{
    /// <summary>
    /// Changes are cached, but state of the map is changed as well. Changes are dropped then all players are updated with full map
    /// or every time then change is being sent in partial updates (Deleted after being sent
    /// </summary>
    public class ChangesController
    {
        private MapState mapState;
        List<DataChange> changesCache;
        List<DataChange> flushingCache; // used to prevent writing while flushing

        public ChangesController(MapState mapState)
        {
            this.mapState = mapState;
            changesCache = new List<DataChange>();
        }

        public int GetChangesCount()
        {
            return changesCache.Count;
        }

        public void UpdatePlayerLocation(JObject data) // TODO check if position really changed and if it chenged legally not cheating
        {
            // remove one location change for same object if exists
            for (int i = 0; i < changesCache.Count; i++)
            {
                if (changesCache[i].change["type"].ToString() == "updateLocation" && changesCache[i].change["id"].ToString() == data["id"].ToString())
                {
                    changesCache.RemoveAt(i);
                    break;
                }
            }
            int pubid = int.Parse(data["id"].ToString());
            for (int i = 0; i < mapState.players.Count; i++) // TODO make easier way to get player by pubid
            {
                if (mapState.players[i].id == pubid)
                {
                    mapState.players[i].location = new Point(int.Parse(data["location"]["X"].ToString()), int.Parse(data["location"]["Y"].ToString()));
                    break;
                }
            }
            changesCache.Add(new DataChange(data));
        }

        /// <summary>
        /// Format changes into object to return and clear all those changes
        /// </summary>
        public JArray FlushCache()
        {
            flushingCache = changesCache;
            changesCache = new List<DataChange>();
            JArray changes = new JArray();
            for (int i = 0; i < flushingCache.Count; i++)
            {
                changes.Add(flushingCache[i].change);
            }
            flushingCache = new List<DataChange>();
            Console.WriteLine("Siunciama informacija");
            Console.WriteLine(changes.ToString());
            return changes;
        }

        /// <summary>
        /// Clear all changes pending to be applied to clients
        /// </summary>
        public void ClearCache()
        {
            changesCache = new List<DataChange>();
        }
    }
}
