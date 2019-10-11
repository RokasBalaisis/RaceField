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
    public class SocketComunicator : WebSocketBehavior
    {
        //stuff for getting Sessions object
        public bool connectedToMap = false;
        MapController mapController = null;

        protected override void OnMessage(MessageEventArgs e) 
        {
            Console.WriteLine(e.Data);
            JObject data = JObject.Parse(e.Data);
            switch (data["type"].ToString())
            {
                case "message":
                    ChatMessageReceived(data);
                    break;
                case "updateLocation":
                    UpdateLocationMessageReceived(data);
                    break;
                default:

                    break;
            }

        }

        protected void ChatMessageReceived(JObject data)
        {
            JObject message = new JObject();
            message["type"] = "message";
            message["message"] = data["message"].ToString();
            message["sender"] = ServerController.GetMapData(0).GetPlayerTagByID(this.ID);
            mapController.SendAll(message);
        }

        protected void UpdateLocationMessageReceived(JObject data)
        {
            data["id"] = mapController.GetPlayerTagByID(this.ID)["id"];
            mapController.changesController.UpdatePlayerLocation(data);
        }

        protected override void OnOpen()
        {
            if (!connectedToMap) // conenect sessions object to map
            {
                mapController = ServerController.GetMapData(0);
                connectedToMap = mapController.ConnectSessions(Sessions);
            }
            string username = Context.CookieCollection["username"].Value; // TODO seperate username and nickname
            int id = mapController.RegisterPlayer(new Player(this.ID, username, username));
            Console.WriteLine(this.ID + ", id = " + id + " connected successfully");
            mapController.UpdateClientsFull();
        }

        protected override void OnClose(CloseEventArgs e)
        {
            mapController.UnregisterPlayer(mapController.FindPlayer(this.ID));
            mapController.UpdateClientsPartial();
            base.OnClose(e);
        }

    }
}
