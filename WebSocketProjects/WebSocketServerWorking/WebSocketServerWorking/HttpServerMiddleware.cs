using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSocketServerWorking
{
    class HttpServerMiddleware : IHttpServer
    {
        private List<string> result = null;
        HttpServerController httpServerController = HttpServerController.Instance;
        public List<string> ReturnResponse()
        {
            return result;
        }

        public void SendRequest(string query)
        {
            if (String.IsNullOrWhiteSpace(query))
            {
                Console.WriteLine("Incorrect SQL query");
            }
            else
            {
                if(result != null)
                    result.Clear();
                result = httpServerController.InitializeConnection(query);
            }
        }
    }
}
