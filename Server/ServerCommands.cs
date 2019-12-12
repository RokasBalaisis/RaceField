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
            TerminalExpression root = new TerminalExpression(exit);
            NoExpression noexpr = new NoExpression();
            while (!exit)
            {
                command = first_command != "" ? first_command : Console.ReadLine();
                first_command = "";
                Context context = new Context(command, wssv);
                if(context.Name == "")
                {
                    noexpr.Interpret(context);
                }
                else
                {
                    root.Interpret(context);
                }
                
            }


        }

        
    }
}
