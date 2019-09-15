using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;
using System.Drawing;
using Newtonsoft.Json.Linq;
using WebSocketSharp.Net;

namespace WebSocketServerWorking
{

    public class Player
    {
        public Point location { get; private set; } // user location should be changed via method after all checks if distance speed ok
        public string ID; //secret sesssion id
        public string username; //player username
        public int id; // public player id

        //Settings
        Color color;

        public Player(string id, int pubid, string username, Color color, Point pos)
        {
            ID = id;
            this.id = pubid;
            this.username = username;
            location = pos;
            this.color = color;
        }

        /*
         * FUNCTION: Gets sensitive player data - can be sent only to that user
         * RETURN: 
         */
        public JObject GetMyStats()
        {
            JObject data = new JObject();
            data["id"] = id;
            data["username"] = username;
            data["color"] = color.Name;
            data["location"] = new JObject();
            data["location"]["X"] = location.X;
            data["location"]["Y"] = location.Y;
            return data;
        }

        /*
         *  FUNCTION: Gets public player data - can be sent to other user
         *  RETURN: 
         */
        public JObject GetMyPublicStats()
        {
            JObject data = new JObject();
            data["username"] = username;
            data["location"] = new JObject();
            data["color"] = color.Name;
            data["location"]["X"] = location.X;
            data["location"]["Y"] = location.Y;
            return data;
        }
    }

    public class MapData // Singleton made by R.P. :D
    {
        // TODO: rename methods with capital letters
        List<Player> players;
        private int idCounter = 0;
        private static MapData mapData;

        public MapData() { }

        public static MapData getMapData()
        {
            if (mapData == null)
            {
                mapData = new MapData();
                mapData.players = new List<Player>();
            }
            return mapData;
        }

        public int registerPlayer(string ID, string username, Point pos, Color color)
        {
            //if (players == null)
            //    players = new List<Player>();
            players.Add(new Player(ID, idCounter++, username, color, pos));
            return idCounter - 1;
        }

        public void unregisterPlayer(string id)
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].ID == id)
                {
                    players.RemoveAt(i);
                    break;
                }
            }
        }

        public JObject getPlayersData()
        {
            JObject data = new JObject();
            foreach (var player in players)
            {
                data[player.id.ToString()] = player.GetMyPublicStats();
            }
            return data;
        }

        public JObject getPlayerDataByID(string ID)
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].ID == ID)
                {
                    return players[i].GetMyPublicStats();
                }
            }
            return null;
        }

        public void SendAll(WebSocketSessionManager Sessions, JObject data)
        {
            for (int i = 0; i < players.Count; i++)
            {
                data["id"] = players[i].id;
                Sessions.SendTo(data.ToString(), players[i].ID);
            }
        }

        public void UpdateClientsMap(WebSocketSessionManager Sessions)
        {
            JObject data = new JObject();
            data["players"] = MapData.getMapData().getPlayersData();
            data["playerCount"] = players.Count;
            data["type"] = "mapupdate";
            for (int i = 0; i < players.Count; i++)
            {
                data["id"] = players[i].id;
                Sessions.SendTo(data.ToString(), players[i].ID);
            }
        }
    }

    public class Main : WebSocketBehavior
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
            data["sender"] = MapData.getMapData().getPlayerDataByID(this.ID);
            data["type"] = "message";
            MapData.getMapData().SendAll(Sessions, data); // TODO: check if only message data is send  strip all other
            Send(msg);
        }

        protected override void OnOpen()
        {
            string username = Context.CookieCollection["username"].Value;
            Console.WriteLine(this.ID + " connected successfully");
            int id = MapData.getMapData().registerPlayer(this.ID, username, new Point(initialLoc[counter, 0], initialLoc[counter, 1]), colors[counter]);
            MapData.getMapData().UpdateClientsMap(Sessions);
            counter++;

            if (counter == initialLoc.GetLength(0))
            {
                counter = 0;
            }
        }
        protected override void OnClose(CloseEventArgs e)
        {
            MapData.getMapData().unregisterPlayer(this.ID);
            MapData.getMapData().UpdateClientsMap(Sessions);
            base.OnClose(e);
        }
    }

    public class ConsoleHelpers
    {
        public static void SetInitialWindowSize()
        {
            Console.SetWindowSize(Console.LargestWindowWidth / 100 * 75, Console.LargestWindowHeight / 2);
        }

        public static void PrintLogo()
        {
            Console.WriteLine("*************************************************************************************************************************************************");
            Console.WriteLine("*       :::::::::           :::        ::::::::       ::::::::::       ::::::::::       :::::::::::       ::::::::::       :::        ::::::::: *");
            Console.WriteLine("*      :+:    :+:        :+: :+:     :+:    :+:      :+:              :+:                  :+:           :+:              :+:        :+:    :+: *");
            Console.WriteLine("*     +:+    +:+       +:+   +:+    +:+             +:+              +:+                  +:+           +:+              +:+        +:+    +:+  *");
            Console.WriteLine("*    +#++:++#:       +#++:++#++:   +#+             +#++:++#         :#::+::#             +#+           +#++:++#         +#+        +#+    +:+   *");
            Console.WriteLine("*   +#+    +#+      +#+     +#+   +#+             +#+              +#+                  +#+           +#+              +#+        +#+    +#+    *");
            Console.WriteLine("*  #+#    #+#      #+#     #+#   #+#    #+#      #+#              #+#                  #+#           #+#              #+#        #+#    #+#     *");
            Console.WriteLine("* ###    ###      ###     ###    ########       ##########       ###              ###########       ##########       ########## #########       *");
            Console.WriteLine("*************************************************************************************************************************************************");
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void PrintInitialServerInfo(System.Net.IPAddress ip, int port)
        {
            Console.WriteLine("*****Websocket server started*****");
            Console.WriteLine("IP: {0}", ip);
            Console.WriteLine("PORT: {0}", port);
            Console.WriteLine("**********************************");
        }
    }

    public class ServerCommands
    {

        public static void StartCommandListener(WebSocketServer wssv)
        {
            string command;
            bool exit = false;
            while (!exit)
            {
                command = Console.ReadLine();
                switch (command)
                {
                    case "clear":
                        Console.Clear();
                        break;

                    case "players data":
                        JObject data = MapData.getMapData().getPlayersData();
                        int i = 0;
                        if (data[i.ToString()] == null)
                        {
                            Console.WriteLine("No players currently connected!");
                            break;
                        }                           
                        Console.WriteLine("**********************************************");
                        Console.WriteLine("*                PLAYERS DATA                *");
                        Console.WriteLine("**********************************************");
                        while (data[i.ToString()] != null)
                        {
                            Console.WriteLine("**********************************************");
                            Console.WriteLine("* Player username: {0, -20} *", data[i.ToString()]["username"]);
                            Console.WriteLine("* Player color: {0, -28} *", data[i.ToString()]["color"]);
                            Console.WriteLine("* Player location: X:{0}, Y:{1, -16} *", data[i.ToString()]["location"]["X"], data[i.ToString()]["location"]["Y"]);
                            Console.WriteLine("**********************************************");
                            i++;
                        }
                        
                        break;

                    case "start":
                        wssv.Start();
                        wssv.AddWebSocketService<Main>("/");
                        ConsoleHelpers.PrintInitialServerInfo(wssv.Address, wssv.Port);
                        break;


                    case "stop":
                        wssv.Stop();
                        Console.WriteLine("*****Websocket server stopped*****");
                        break;

                    case "exit":
                        exit = true;
                        break;

                    case "help":
                        Console.WriteLine("*****List of available commands*****");
                        Console.WriteLine("clear - clear the console");
                        Console.WriteLine("players data  - lists public data of connected players");
                        Console.WriteLine("start - start the Websocket Server");
                        Console.WriteLine("stop  - stop the Websocket Server");
                        Console.WriteLine("exit  - exit the application");
                        Console.WriteLine("************************************");
                        break;

                    default:
                        Console.WriteLine("Unknown Command: \"" + command + "\"");
                        Console.WriteLine("To list available commands, use command \"help\"");
                        break;
                }
            }


        }

        public class Program
        {
            public static void Main(string[] args)
            {
                ConsoleHelpers.SetInitialWindowSize();
                ConsoleHelpers.PrintLogo();
                var ip = "127.0.0.1";
                var port = 8080;
                var wssv = new WebSocketServer(System.Net.IPAddress.Parse(ip), port);
                StartCommandListener(wssv);
            }
        }
    }
}
