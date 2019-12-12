using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSocketServerWorking
{
    public class TerminalExpression : IExpression
    {
        public bool TerminalState { get; set; }

        public TerminalExpression(bool terminalState)
        {
            TerminalState = terminalState;
        }

        public void Interpret(Context context)
        {
            switch (context.Name)
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
                    context.Wssv.Start();
                    context.Wssv.AddWebSocketService<SocketComunicator>("/");
                    ConsoleHelpers.PrintInitialServerInfo(context.Wssv.Address, context.Wssv.Port);
                    break;


                case "stop":
                    context.Wssv.Stop();
                    Console.WriteLine("*****Websocket server stopped*****");
                    break;

                case "exit":
                    ExitTerminal();
                    break;


                case "help":
                    Console.WriteLine("*****List of available commands*****");
                    Console.WriteLine("clear - clear the console");
                    Console.WriteLine("custom-sql-query - writes custom SQL query to database");
                    Console.WriteLine("http-server-start - starts HTTP server");
                    Console.WriteLine("http-server-stop - stops HTTP server");
                    Console.WriteLine("players data  - lists public data of connected players");
                    Console.WriteLine("start - start the Websocket Server");
                    Console.WriteLine("seed-users-table - seeds users table with test data");
                    Console.WriteLine("clear-users-table - empties users table");
                    Console.WriteLine("stop  - stop the Websocket Server");
                    Console.WriteLine("exit  - exit the application");
                    Console.WriteLine("************************************");
                    break;

                case "http-server-start":
                    if (HttpServerController.Instance.GetServerStatus() == true)
                    {
                        Console.WriteLine("Http server was already started.");
                    }
                    else
                    {
                        HttpServerController.Instance.StartServer(8080);
                    }
                    break;

                case "http-server-stop":
                    if (HttpServerController.Instance.GetServerStatus())
                    {
                        HttpServerController.Instance.StopServer();
                        Console.WriteLine("Http server has been stopped successfully");
                    }
                    else
                        Console.WriteLine("Http server is not started yet.");
                    break;

                case "seed-users-table":
                    Random r = new Random();
                    for (int c = 0; c < 100; c++)
                        context.sendMiddlewareRequest("INSERT into user(username, nickname, password, car_model, credits) VALUES ('test" + c.ToString() + "', 'nickname" + c.ToString() + "', 'password" + c.ToString() + "'," + c.ToString() + "," + r.Next() + ")");
                    Console.WriteLine("Users table has been seeded");
                    break;

                case "clear-users-table":
                    context.sendMiddlewareRequest("TRUNCATE user");
                    Console.WriteLine("Users table has been reset");
                    break;

                case "custom-sql-query":
                    Console.WriteLine("Please write new SQL query: ");
                    string query = Console.ReadLine();
                    context.sendMiddlewareRequest(query);
                    foreach (string s in context.ReturnMiddlewareResponse())
                        Console.WriteLine(s);
                    break;

                default:
                    Console.WriteLine("Unknown Command: \"" + context.Name + "\"");
                    Console.WriteLine("To list available commands, use command \"help\"");
                    break;
            }
        }

        public void ExitTerminal()
        {
            TerminalState = true;
        }
    }
}
