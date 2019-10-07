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
        MapData mapData = null;

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
            mapData.SendAll(message);
        }

        protected void UpdateLocationMessageReceived(JObject data)
        {
            data["id"] = mapData.GetPlayerTagByID(this.ID)["id"];
            mapData.UpdatePlayerLocation(data);
        }

        protected override void OnOpen()
        {
            if (!connectedToMap) // conenect sessions object to map
            {
                mapData = ServerController.GetMapData(0);
                connectedToMap = mapData.ConnectSessions(Sessions);
            }
            string username = Context.CookieCollection["username"].Value; // TODO seperate username and nickname
            int id = ServerController.GetMapData(0).RegisterPlayer(new Player(this.ID, username, username));
            Console.WriteLine(this.ID + ", id = " + id + " connected successfully");
            mapData.UpdateClientsFull();
        }

        protected override void OnClose(CloseEventArgs e)
        {
            mapData.UnregisterPlayer(mapData.FindPlayer(this.ID));
            mapData.UpdateClientsPartial();
            base.OnClose(e);
        }

    }
}
