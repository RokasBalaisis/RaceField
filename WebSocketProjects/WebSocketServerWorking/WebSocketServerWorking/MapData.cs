using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;
using System.Drawing;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace WebSocketServerWorking
{
    public class MapData
    {
        int tickCounter = 0;
        int timeForMapUpdate = 100;
        WebSocketSessionManager sessions = null;
        bool sessionConnected = false;
        List<DataChange> changesCache;

        int[,] initialLoc = new int[,] //temporary
        {
            { 20, 10 },
            { 400, 300 },
            { 600, 10  },
            { 400, 200 },
            { 500, 10 },
        };
        Color[] colors = new Color[]     //temporary
        {
            Color.Red,
            Color.Purple,
            Color.GreenYellow,
            Color.Honeydew,
            Color.Brown,
        };
        static int counter = 0;             //temporary
        
        
        public List<Player> players; // observers collection
        private int idCounter = 0;

        public MapData()
        {
            changesCache = new List<DataChange>();
            players = new List<Player>();
        }

        public int RegisterPlayer(Player player) // observer register
        {
            player.color = colors[counter];
            player.location = new Point(initialLoc[counter, 0], initialLoc[counter, 1]);
            counter++;
            if (counter == initialLoc.GetLength(0)) //temporary
            {
                counter = 0;
            }
            player.id = idCounter++;
            players.Add(player);
            return idCounter - 1;
        }

        public void UnregisterPlayer(Player player) // observer unregister
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].ID == player.ID)
                {
                    players.RemoveAt(i);
                    break;
                }
            }
        }

        public JObject GetPlayersData()
        {
            JObject data = new JObject();
            foreach (var player in players)
            {
                data[player.id.ToString()] = player.GetMyPublicStats();
            }
            return data;
        }

        public JObject GetPlayerPublicStatsByID(string ID)
        {
            Player player = FindPlayer(ID);
            if (player != null)
            {
                return player.GetMyPublicStats();
            }
            return null;
        }

        public JObject GetPlayerTagByID(string ID)
        {
            Player player = FindPlayer(ID);
            if (player != null)
            {
                return player.GetMyTag();
            }
            return null;
        }

        public Player FindPlayer(string ID)
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].ID == ID)
                {
                    return players[i];
                }
            }
            return null;
        }

        public void SendAll(JObject data) // observer notifyAll()
        {
            for (int i = 0; i < players.Count; i++)
            {
                sessions.SendTo(data.ToString(), players[i].ID);
            }
        }

        public void UpdateClientsFull()
        {
            JObject data = new JObject();
            data["players"] = GetPlayersData();
            data["playerCount"] = players.Count;
            data["type"] = "mapSetup";
            for (int i = 0; i < players.Count; i++)
            {
                data["myData"] = players[i].GetMyStats();
                sessions.SendTo(data.ToString(), players[i].ID);
            }
        }

        public void UpdateClientsPartial()
        {
            // update clients and change full map data with those changes
            JObject data = new JObject();
            data["type"] = "mapUpdate";
            JArray changes = new JArray();
            data["changesCount"] = changes.Count;
            for(int i = 0; i < changesCache.Count; i++)
            {
                changes.Add(changesCache[i].ToString());
            }
            data["mapChanges"] = changes;
            for (int i = 0; i < players.Count; i++) // for now possible to use SendAll()
            {
                sessions.SendTo(data.ToString(), players[i].ID);
            }
        }

        // TODO implement method to accept and parse changes from client and store them in changeCache list

        public void MapTick(Object o)
        {
            if(tickCounter > timeForMapUpdate)
            { // send full map data
                UpdateClientsFull();
                tickCounter = 0;
            }
            else
            { // send only changes
                UpdateClientsPartial();
            }

            tickCounter++;
        }

        public bool ConnectSessions(WebSocketSessionManager _sessions)
        {
            sessions = _sessions;
            sessionConnected = true;
            Timer t = new Timer(MapTick, null, 0, 2000);
            return sessionConnected;
        }
    }
}
