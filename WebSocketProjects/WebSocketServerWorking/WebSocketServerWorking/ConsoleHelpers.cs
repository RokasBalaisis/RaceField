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

}
