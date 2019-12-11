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
        private HttpServer httpsrv = null;
        private bool serverStatus = false;
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

        public List<string> InitializeConnection(string sql)
        {
            List<string> result = new List<string>();
            var dbMan = DBmanager.GetDBmanager();
            string tableName = dbMan.StartConnection(sql).Item2;
            dbMan.CloseConnection();
            var sqlDataReader = dbMan.StartConnection(sql).Item1;
            result.Add("*********************************");
            result.Add(tableName);
            while (sqlDataReader.Read())
            {
                result.Add("*********************************");
                for (int i=0; i < sqlDataReader.FieldCount; i++)
                {
                    result.Add(sqlDataReader.GetName(i) + ": " + sqlDataReader[i] + " ");
                }
                result.Add("*********************************");
            }
                Console.WriteLine("Query has been completed successfully");
            dbMan.CloseConnection();
            return result;
        }

        public bool GetServerStatus()
        {
            return serverStatus;
        }

        public void StartServer(int port)
        {
            if(!serverStatus)
            {
                serverStatus = true;
                httpsrv = new HttpServer(port);
                httpsrv.RootPath = ConfigurationManager.AppSettings["DocumentRootPath"];
                httpsrv.OnGet += (sender, e) => {
                    var req = e.Request;
                    var res = e.Response;
                    var path = req.RawUrl;
                    switch (path)
                    {
                        case "/users":
                            var sql = "SELECT * from user";
                            res.ContentType = "application/json";
                            res.WriteContent(Encoding.UTF8.GetBytes(GetRequest(sql, "users").ToString()));
                            break;

                        default:
                            res.ContentType = "application/json";
                            res.StatusCode = 404;
                            res.WriteContent(Encoding.UTF8.GetBytes(NotFoundError().ToString()));
                            break;
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
        }

        public void StopServer()
        {
            if(serverStatus)
                httpsrv.Stop();
            httpsrv = null;
            serverStatus = false;
        }

        public JObject GetRequest(string sql, string jsonName)
        {
            var dbMan = DBmanager.GetDBmanager();
            var sqlDataReader = dbMan.StartConnection(sql);
            var columnCount = sqlDataReader.Item1.FieldCount;
            JObject result = new JObject();
            JArray array = new JArray();
            while (sqlDataReader.Item1.Read())
            {
                JObject entry = new JObject();
                for (int i = 0; i < columnCount; i++)
                {
                    if (sqlDataReader.Item1.GetValue(i).GetType() == typeof(int))
                        entry.Add(sqlDataReader.Item1.GetName(i), int.Parse(sqlDataReader.Item1.GetValue(i).ToString()));
                    else
                        entry.Add(sqlDataReader.Item1.GetName(i), sqlDataReader.Item1.GetValue(i).ToString());
                }
                array.Add(entry);
                result[jsonName] = array;
            }
            return result;
        }

        public JObject NotFoundError()
        {
            JObject result = new JObject();
            result.Add("error", "404 Page not found");
            return result;
        }

    }
}
