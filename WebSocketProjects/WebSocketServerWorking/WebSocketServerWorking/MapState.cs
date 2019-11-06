﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSocketServerWorking
{
    public class MapState
    {
        public MapController mapController; // TODO make sure - maybe this is not needed 
        public List<Player> players; // observers collection
        private int idCounter = 0;

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

        public MapState(MapController mapController)
        {
            this.mapController = mapController;
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
    }
}
