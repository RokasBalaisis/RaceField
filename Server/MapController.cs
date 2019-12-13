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
    public class MapController : Colleague // Fasadas
    {
        static int timeForMapUpdate = 100;
        
        public ChangesController changesController;
        int tickCounter = 0;
        WebSocketSessionManager sessions = null;
        bool sessionConnected = false;
        Timer gameTimer;

        public MapController(Mediator mediator) : base(mediator)
        {           
            changesController = new ChangesController(mediator);
        }

        public int RegisterPlayer(Player player)
        {
            int id = mediator.RegisterPlayer(player);
            UpdateClientsFull();
            return id;
        }

        public void UnregisterPlayer(Player player)
        {
            mediator.UnRegisterPlayer(player);
            UpdateClientsFull(); // TODO maybe partial would suffice 
        }

        public JObject GetPlayersData()
        {
            return mediator.GetPlayersData();
        }

        public JObject GetPlayerPublicStatsByID(string ID)
        {
            return mediator.GetPlayerPublicStatsByID(ID);
        }

        public JObject GetPlayerTagByID(string ID)
        {
            return mediator.GetPlayerTagByID(ID);
        }

        public Player FindPlayer(string ID)
        {
            return mediator.FindPlayer(ID);
        }

        public void SendAll(JObject data) // observer notifyAll()
        {
            for (int i = 0; i < GetPlayersCount(); i++)
            {
                sessions.SendTo(data.ToString(), mediator.GetPlayerID(i));
            }
        }

        public void UpdateClientsFull()
        {
            JObject data = new JObject();
            data["players"] = GetPlayersData();
            data["playerCount"] = GetPlayersCount();
            data["type"] = "mapSetup";
            for (int i = 0; i < GetPlayersCount(); i++)
            {
                data["myData"] = mediator.GetPlayerStats(i);
                sessions.SendTo(data.ToString(), mediator.GetPlayerID(i));
            }
            mediator.ClearChangesCache();            
        }

        public void UpdateClientsPartial() // TODO make thread safe changesCache working/clearing 
        {
            // update clients and change full map data with those changes
            JObject data = new JObject();
            data["type"] = "mapUpdate";
            JArray changes = mediator.FlushChangesCache();

            data["mapChanges"] = changes;
            data["changesCount"] = changes.Count;
            SendAll(data);
        }

        // TODO implement method to accept and parse changes from client and store them in changeCache list

        public void MapTick(Object o)
        {
            Console.WriteLine("Calling tick " + tickCounter);
            if(tickCounter > timeForMapUpdate)
            { // send full map data
                Console.WriteLine("full update");
                UpdateClientsFull();
                tickCounter = 0;
            }
            else
            { // send only changes
                Console.WriteLine("partial update");
                if(mediator.GetChangesCount() != 0)
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
            gameTimer = new Timer(MapTick, null, 0, 10);
            return sessionConnected;
        }


        public int GetPlayersCount()
        {
            return mediator.GetPlayersCount();
        }  

    }
}
