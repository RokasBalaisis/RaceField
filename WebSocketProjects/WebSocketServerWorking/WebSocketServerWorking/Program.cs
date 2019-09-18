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
