using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSocketServerWorking
{
    public abstract class Mediator
    {
        public abstract void Send(string message, MapController mapController);

        public abstract void Send(string message, ChangesController changesController);

        public abstract void Send(string message, MapState mapState);

        public abstract int GetPlayersCount();
        public abstract void SetPlayerLocation(int i, Point point);
        public abstract int GetPlayerId(int i);
        public abstract int RegisterPlayer(Player player);
        public abstract void UnRegisterPlayer(Player player);
        public abstract JObject GetPlayersData();
        public abstract JObject GetPlayerPublicStatsByID(string ID);
        public abstract JObject GetPlayerTagByID(string ID);
        public abstract Player FindPlayer(string ID);
        public abstract string GetPlayerID(int i);
        public abstract JObject GetPlayerStats(int i);
        public abstract void ClearChangesCache();
        public abstract JArray FlushChangesCache();
        public abstract int GetChangesCount();
    }
}
