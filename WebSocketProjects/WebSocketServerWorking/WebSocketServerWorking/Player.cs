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
    public class Player
    {
        public Point location { get; private set; } // user location should be changed via method after all checks if distance speed ok
        public string ID; //secret sesssion id
        public string username; // player username // should not be used for identification in client side
        public string nickname; // player nickname
        public int id; // public player id
        public int carModel; // id of car model

        //Settings
        Color color;

        public Player(string id, int pubid, string username, string nickname, Color color, Point pos, int carModel = 0)
        {
            ID = id;
            this.id = pubid;
            this.username = username;
            this.nickname = nickname;
            location = pos;
            this.color = color;
            this.carModel = carModel;
        }

        /*
        * FUNCTION: Gets player's short identification information
        * RETURN: 
        */
        public JObject GetMyTag()
        {
            JObject data = new JObject();
            data["id"] = id;
            data["nickname"] = nickname;
            return data;
        }

        /*
         * FUNCTION: Gets sensitive player data - can be sent only to that user
         * RETURN: 
         */
        public JObject GetMyStats()
        {
            JObject data = new JObject();
            data["id"] = id;
            data["nickname"] = nickname;
            data["username"] = username;
            data["color"] = color.Name;
            data["location"] = new JObject();
            data["location"]["X"] = location.X;
            data["location"]["Y"] = location.Y;
            data["carModel"] = carModel;
            return data;
        }

        /*
         *  FUNCTION: Gets public player data - can be sent to other user
         *  RETURN: 
         */
        public JObject GetMyPublicStats()
        {
            JObject data = new JObject();
            data["nickname"] = nickname;
            data["location"] = new JObject();
            data["color"] = color.Name;
            data["location"]["X"] = location.X;
            data["location"]["Y"] = location.Y;
            data["carModel"] = carModel;
            return data;
        }
    }
}
