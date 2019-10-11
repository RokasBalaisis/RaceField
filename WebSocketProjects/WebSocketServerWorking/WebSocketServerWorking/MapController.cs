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
    public class MapController
    {
        MapState mapState;
        public ChangesController changesController;
        int tickCounter = 0;
        int timeForMapUpdate = 100;
        WebSocketSessionManager sessions = null;
        bool sessionConnected = false;
        
        public MapController()
        {
            mapState = new MapState(this);
            changesController = new ChangesController(mapState);
        }

        public int RegisterPlayer(Player player)
        {
            int id = mapState.RegisterPlayer(player);
            UpdateClientsFull();
            return id;
        }

        public void UnregisterPlayer(Player player)
        {
            mapState.UnregisterPlayer(player);
            UpdateClientsFull(); // TODO maybe partial would suffice 
        }

        public JObject GetPlayersData()
        {
            return mapState.GetPlayersData();
        }

        public JObject GetPlayerPublicStatsByID(string ID)
        {
            return mapState.GetPlayerPublicStatsByID(ID);
        }

        public JObject GetPlayerTagByID(string ID)
        {
            return mapState.GetPlayerTagByID(ID);
        }

        public Player FindPlayer(string ID)
        {
            return mapState.FindPlayer(ID);
        }

        public void SendAll(JObject data) // observer notifyAll()
        {
            for (int i = 0; i < mapState.players.Count; i++)
            {
                sessions.SendTo(data.ToString(), mapState.players[i].ID);
            }
        }

        public void UpdateClientsFull()
        {
            JObject data = new JObject();
            data["players"] = GetPlayersData();
            data["playerCount"] = mapState.players.Count;
            data["type"] = "mapSetup";
            for (int i = 0; i < mapState.players.Count; i++)
            {
                data["myData"] = mapState.players[i].GetMyStats();
                sessions.SendTo(data.ToString(), mapState.players[i].ID);
            }
            changesController.ClearCache();
        }

        public void UpdateClientsPartial() // TODO make thread safe changesCache working/clearing 
        {
            // update clients and change full map data with those changes
            JObject data = new JObject();
            data["type"] = "mapUpdate";
            JArray changes = changesController.FlushCache();
            data["mapChanges"] = changes;
            data["changesCount"] = changes.Count;
            SendAll(data);
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
                if(changesController.GetChangesCount() != 0)
                {
                    UpdateClientsPartial();
                }
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
