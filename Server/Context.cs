using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp.Server;

namespace WebSocketServerWorking
{
    public class Context
    {
        public string Name { get; set; }
        public WebSocketServer Wssv { get; set; }
        private HttpServerMiddleware httpServerMiddleware = new HttpServerMiddleware();

        public Context(string name, WebSocketServer wssv)
        {
            Name = name;
            Wssv = wssv;
        }

        public void sendMiddlewareRequest(string query)
        {
            httpServerMiddleware.SendRequest(query);
        }

        public List<string> ReturnMiddlewareResponse()
        {
            return httpServerMiddleware.ReturnResponse();
        }
    }
}
