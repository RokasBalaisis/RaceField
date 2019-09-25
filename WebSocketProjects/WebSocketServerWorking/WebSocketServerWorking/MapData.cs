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
        // TODO: rename methods with capital letters
        List<Player> players;
        private int idCounter = 0;

        public MapData()
        {
            players = new List<Player>();
        }

        public int registerPlayer(string ID, string username, Point pos, Color color)
        {
            players.Add(new Player(ID, idCounter++, username, color, pos));
            return idCounter - 1;
        }

        public void unregisterPlayer(string id)
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].ID == id)
                {
                    players.RemoveAt(i);
                    break;
                }
            }
        }

        public JObject getPlayersData()
        {
            JObject data = new JObject();
            foreach (var player in players)
            {
                data[player.id.ToString()] = player.GetMyPublicStats();
            }
            return data;
        }

        public JObject getPlayerDataByID(string ID)
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].ID == ID)
                {
                    return players[i].GetMyPublicStats();
                }
            }
            return null;
        }

        public void SendAll(WebSocketSessionManager Sessions, JObject data)
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
            data["players"] = getPlayersData();
            data["playerCount"] = players.Count;
            data["type"] = "mapupdate";
            for (int i = 0; i < players.Count; i++)
            {
                data["id"] = players[i].id;
                Sessions.SendTo(data.ToString(), players[i].ID);
            }
        }
    }
}
