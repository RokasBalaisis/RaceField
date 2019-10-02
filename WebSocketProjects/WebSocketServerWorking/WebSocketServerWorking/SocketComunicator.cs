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


        protected override void OnMessage(MessageEventArgs e) 
        {
            Console.WriteLine(e.Data);
            JObject data = JObject.Parse(e.Data);
            switch (data["type"].ToString())
            {
                case "message":
                    ChatMessageReceived(data);
                    break;
                default:

                    break;
            }

        }

        protected void ChatMessageReceived(JObject data)
        {
            JObject message = new JObject();
            message["message"] = data["message"].ToString();
            message["sender"] = ServerController.GetMapData(0).GetPlayerTagByID(this.ID);
            ServerController.GetMapData(0).SendAll(Sessions, message);
            //Send(data.ToString()); // no need for this...
        }

        protected override void OnOpen()
        {
            string username = Context.CookieCollection["username"].Value; // TODO seperate username and nickname
            int id = ServerController.GetMapData(0).RegisterPlayer(new Player(this.ID, username, username, colors[counter], new Point(initialLoc[counter, 0], initialLoc[counter, 1])));
            Console.WriteLine(this.ID + ", id = " + id + " connected successfully");
            ServerController.GetMapData(0).UpdateClientsMap(Sessions);
            counter++;

            if (counter == initialLoc.GetLength(0)) //temporary
            {
                counter = 0;
            }
        }

        protected override void OnClose(CloseEventArgs e)
        {
            ServerController.GetMapData(0).UnregisterPlayer(ServerController.GetMapData(0).FindPlayer(this.ID));
            ServerController.GetMapData(0).UpdateClientsMap(Sessions);
            base.OnClose(e);
        }
    }
}
