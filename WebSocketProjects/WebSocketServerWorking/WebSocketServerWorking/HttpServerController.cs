using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp.Server;
using WebSocketSharp;
using WebSocketSharp.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace WebSocketServerWorking
{
    public sealed class HttpServerController
    {
        private static readonly HttpServerController instance = new HttpServerController();
        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static HttpServerController()
        {

        }

        private HttpServerController()
        {
        }

        public static HttpServerController Instance
        {
            get{ return instance; }
        }



        public void StartServer(int port)
        {
            var httpsrv = new HttpServer(port);
            httpsrv.RootPath = ConfigurationManager.AppSettings["DocumentRootPath"];
            httpsrv.OnGet += (sender, e) => {
                var req = e.Request;
                var res = e.Response;

                var path = req.RawUrl;
                if (path == "/users")
                {
                    var sql = "SELECT * from user";
                    var result = GetRequest(sql, "users");
                    var resultBytes = Encoding.UTF8.GetBytes(result.ToString());
                    res.ContentType = "application/json";
                    res.WriteContent(resultBytes);
                }

            };

            httpsrv.Start();
            if (httpsrv.IsListening)
            {
                Console.WriteLine("Listening on port {0}, and providing WebSocket services:", httpsrv.Port);
                foreach (var path in httpsrv.WebSocketServices.Paths)
                    Console.WriteLine("- {0}", path);
            }
        }



        public JObject GetRequest(string sql, string jsonName)
        {
            var dbMan = DBmanager.GetDBmanager();
            var sqlDataReader = dbMan.StartConnection(sql);
            var columnCount = sqlDataReader.FieldCount;
            JObject result = new JObject();
            JArray array = new JArray();
            while (sqlDataReader.Read())
            {
                JObject entry = new JObject();
                for (int i = 0; i < columnCount; i++)
                {
                    if (sqlDataReader.GetValue(i).GetType() == typeof(int))
                        entry.Add(sqlDataReader.GetName(i), int.Parse(sqlDataReader.GetValue(i).ToString()));
                    else
                        entry.Add(sqlDataReader.GetName(i), sqlDataReader.GetValue(i).ToString());
                }
                array.Add(entry);
                result[jsonName] = array;
            }
            return result;
        }

    }
}

