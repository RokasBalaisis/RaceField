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

        public static void StartCommandListener(WebSocketServer wssv, string[] args)
        {
            string first_command = args.Length > 0 ? args[0] : "";
            string command;
            bool exit = false;
            while (!exit)
            {
                command = first_command != "" ? first_command : Console.ReadLine();
                first_command = "";
                switch (command)
                {
                    case "clear":
                        Console.Clear();
                        break;

                    case "players data":
                        JObject data = null;//.getPlayersData();
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
                        wssv.AddWebSocketService<SocketComunicator>("/");
                        ConsoleHelpers.PrintInitialServerInfo(wssv.Address, wssv.Port);
                        break;


                    case "stop":
                        wssv.Stop();
                        Console.WriteLine("*****Websocket server stopped*****");
                        break;

                    case "exit":
                        exit = true;
                        break;

                    case "test":
                        DBmanager.GetDBmanager().Connect();
                        break;

                    case "help":
                        Console.WriteLine("*****List of available commands*****");
                        Console.WriteLine("clear - clear the console");
                        Console.WriteLine("http-server-start - starts HTTP server");
                        Console.WriteLine("players data  - lists public data of connected players");
                        Console.WriteLine("start - start the Websocket Server");
                        Console.WriteLine("seed-users-table - seeds users table with test data");
                        Console.WriteLine("clear-users-table - empties users table");
                        Console.WriteLine("stop  - stop the Websocket Server");
                        Console.WriteLine("exit  - exit the application");
                        Console.WriteLine("************************************");
                        break;

                    case "http-server-start":
                        HttpServerController.Instance.StartServer(8080);
                        break;

                    case "seed-users-table":
                        Random r = new Random();
                        for (int c = 0; c < 100; c++)             
                            HttpServerController.Instance.SeedTable("INSERT into user(username, nickname, password, car_model, credits) VALUES ('test" + c.ToString() + "', 'nickname" + c.ToString() + "', 'password" + c.ToString() + "'," + c.ToString() + "," + r.Next() + ")");
                        Console.WriteLine("Users table has been seeded");
                        break;

                    case "clear-users-table":
                        HttpServerController.Instance.SeedTable("TRUNCATE user");
                        Console.WriteLine("Users table has been reset");
                        break;
                   /* case "http-server-stop":
                        HttpServerController.Instance.
                        break;*/

                    default:
                        Console.WriteLine("Unknown Command: \"" + command + "\"");
                        Console.WriteLine("To list available commands, use command \"help\"");
                        break;
                }
            }


        }

        
    }
}
