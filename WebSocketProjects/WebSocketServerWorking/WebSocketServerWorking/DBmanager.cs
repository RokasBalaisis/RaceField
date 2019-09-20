using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSocketServerWorking
{
    public class DBmanager
    {
        static private DBmanager dBmanager;
        SqlConnection cnn;
        String connetionString = @"Data Source=remotemysql.com:3306;Initial Catalog=nt62qrWRGL;User ID=nt62qrWRGL;Password=JGyJoOraKI";
        String sql = "";
        SqlCommand command;
        SqlDataReader sqlDataReader;

        public DBmanager() { }

        public static DBmanager GetDBmanager()
        { //TOFO: make it thread safe
            if(dBmanager == null)
            {
                dBmanager = new DBmanager();
            }
            return dBmanager;
        }

        private void StartConnection(String sql)
        {
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            command = new SqlCommand(sql, cnn);
            sqlDataReader = command.ExecuteReader();
        }

        private void CloseConnection()
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
