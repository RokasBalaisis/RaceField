using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace WebSocketServerWorking
{
    public class DBmanager
    {
        private static class DatabaseManagerHolder
        {
            public static DBmanager instance = new DBmanager();
        }

        

        private const string ConnectionString = @"Data Source=remotemysql.com; Port=3306;Initial Catalog=nt62qrWRGL;User ID=nt62qrWRGL;Password=JGyJoOraKI";
        private string sql = "";

        MySqlConnection cnn;
        MySqlCommand command;
        MySqlDataReader sqlDataReader;
        
        public static DBmanager GetDBmanager()
        {
            return DatabaseManagerHolder.instance;
        }

        public (MySqlDataReader, string) StartConnection(string sql)
        {

            cnn = new MySqlConnection(ConnectionString);
            cnn.Open();
            command = new MySqlCommand(sql, cnn);
            sqlDataReader = command.ExecuteReader();
            return (sqlDataReader, cnn.GetSchema().TableName);
        }

        public void CloseConnection()
        {
            sqlDataReader.Close();
            command.Dispose();
            cnn.Close();
        }


        // connect user or register if no such user in database
        // TODO: pass username and password to this method and try connecting - getting user data
        // TODO: return player prefs
        public void Connect()
        {
            sql = "SELECT * from user";
            StartConnection(sql);
            while (sqlDataReader.Read())
            {
                Console.WriteLine(sqlDataReader.GetValue(0) + " " + sqlDataReader.GetValue(1));
            }
            CloseConnection();
        }

    }
}
