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
            { 200, 100 },
            { 400, 300 },
            { 600, 10  },
            { 400, 200 },
            { 500, 10 },
        };
        Color[] colors = new Color[]
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
            var msg = e.Data;
            Console.WriteLine(msg);
            JObject data = JObject.Parse(e.Data);
            data["sender"] = ServerController.GetMapData(0).getPlayerDataByID(this.ID);
            data["type"] = "message";
            ServerController.GetMapData(0).SendAll(Sessions, data); // TODO: check if only message data is send  strip all other
            Send(msg);
        }

        protected override void OnOpen()
        {
            string username = Context.CookieCollection["username"].Value;
            Console.WriteLine(this.ID + " connected successfully");
            int id = ServerController.GetMapData(0).registerPlayer(this.ID, username, new Point(initialLoc[counter, 0], initialLoc[counter, 1]), colors[counter]);
            ServerController.GetMapData(0).UpdateClientsMap(Sessions);
            counter++;

            if (counter == initialLoc.GetLength(0))
            {
                counter = 0;
            }
        }

        protected override void OnClose(CloseEventArgs e)
        {
            ServerController.GetMapData(0).unregisterPlayer(this.ID);
            ServerController.GetMapData(0).UpdateClientsMap(Sessions);
            base.OnClose(e);
        }
    }
}
