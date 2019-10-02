using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;
using System.Drawing;
using Newtonsoft.Json.Linq;

namespace WebSocketServerWorking
{
    public class MapData
    {
        public List<Player> players; // observers collection
        private int idCounter = 0;

        public MapData()
        {
            players = new List<Player>();
        }

        public int RegisterPlayer(Player player) // observer register
        {
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

        public void SendAll(WebSocketSessionManager Sessions, JObject data) // observer notifyAll()
        {
            for (int i = 0; i < players.Count; i++)
            {
                data["id"] = players[i].id;
                Sessions.SendTo(data.ToString(), players[i].ID);
            }
        }

        public void UpdateClientsMap(WebSocketSessionManager Sessions)
        {
            JObject data = new JObject();
            data["players"] = GetPlayersData();
            data["playerCount"] = players.Count;
            data["type"] = "mapUpdate";
            for (int i = 0; i < players.Count; i++)
            {
                data["id"] = players[i].id;
                Sessions.SendTo(data.ToString(), players[i].ID);
            }
        }
    }
}
