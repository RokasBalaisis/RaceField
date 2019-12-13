using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketServerWorking.Collectables;
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
            CollectableFactory f = new CollectableFactory();
            for (int i = 0; i < 10; i++)
            {
                var c = f.GetRandomCollectable();
                Console.WriteLine("{0,6} {1,6} {2,10} {3}", c.duration.ToString(), c.effectStrength.ToString(), c.spriteName, c.GetType());
            }


            MapMediator mediator = new MapMediator();

            MapController mapcontroller = new MapController(mediator);
            MapState mapstate = new MapState(mapcontroller, mediator);
            ChangesController changescontroller = new ChangesController(mediator);

            mediator.MapController = mapcontroller;
            mediator.MapState = mapstate;
            mediator.ChangesController = changescontroller;

            //for now only one map will be on
            currentMapData[0] = new MapController(mediator);

            ConsoleHelpers.SetInitialWindowSize();
            ConsoleHelpers.PrintLogo();
            var ip = "0.0.0.0";//"127.0.0.1";
            var port = 8080;
            var wssv = new WebSocketServer(System.Net.IPAddress.Parse(ip), port);
            ServerCommands.StartCommandListener(wssv, args);
        }

    }
}
