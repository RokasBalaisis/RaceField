using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp.Server;

namespace WebSocketServerWorking
{
    public class ServerController
    {
        static MapController[] currentMapData = new MapController[1];

        public static MapController GetMapData(int id)
        {
            return currentMapData[id];
        }

        public static void Main(string[] args)
        {
            //for now only one map will be on
            currentMapData[0] = new MapController();

            ConsoleHelpers.SetInitialWindowSize();
            ConsoleHelpers.PrintLogo();
            var ip = "0.0.0.0";//"127.0.0.1";
            var port = 8080;
            var wssv = new WebSocketServer(System.Net.IPAddress.Parse(ip), port);
            ServerCommands.StartCommandListener(wssv);
        }

    }
}
