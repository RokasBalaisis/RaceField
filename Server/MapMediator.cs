using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSocketServerWorking
{
    class MapMediator : Mediator
    {
        private MapState mapState;
        private ChangesController changesController;
        private MapController mapController;

        public  MapState MapState
        {
            set { mapState = value; }
        }

        public ChangesController ChangesController
        {
            set { changesController = value; }
        }

        public MapController MapController
        {
            set { mapController = value; }
        }

        public override int RegisterPlayer(Player player)
        {
            return mapState.RegisterPlayer(player);
        }

        public override void UnRegisterPlayer(Player player)
        {
            mapState.UnregisterPlayer(player);
        }

        public override JObject GetPlayersData()
        {
            return mapState.GetPlayersData();
        }

        public override JObject GetPlayerPublicStatsByID(string ID)
        {
            return mapState.GetPlayerPublicStatsByID(ID);
        }

        public override JObject GetPlayerTagByID(string ID)
        {
            return mapState.GetPlayerTagByID(ID);
        }

        public override Player FindPlayer(string ID)
        {
            return mapState.FindPlayer(ID);
        }

        public override string GetPlayerID(int i)
        {
            return mapState.players[i].ID;
        }

        public override JObject GetPlayerStats(int i)
        {
            return mapState.players[i].GetMyStats();
        }

        public override void ClearChangesCache()
        {
            changesController.ClearCache();
        }

        public override JArray FlushChangesCache()
        {
            return changesController.FlushCache();
        }

        public override int GetChangesCount()
        {
            return changesController.GetChangesCount();
        }



        public override int GetPlayerId(int i)
        {
            return mapState.players[i].id;
        }

        public override void SetPlayerLocation(int i, Point point)
        {
            mapState.players[i].location = point;
        }

        public override int GetPlayersCount()
        {
            return mapState.players.Count;
        }

        public override void Send(string message, MapState mapState)
        {
            this.mapState.Notify(message);
        }

        public override void Send(string message, ChangesController changesController)
        {
            this.changesController.Notify(message);
        }

    }
}
