using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices;
using WebSocketSharp;
using WebSocketSharp.Net;
using System.Diagnostics;

namespace WebsocketClient
{
    public partial class Form1 : Form //     !!!!!!!! ! WARNING ! !!!!!!!!    must be first class in this file
    {
        public static bool isMessaging = false;
        public static bool isUpPressed = false;
        public static bool isDownPressed = false;
        public static bool isLeftPressed = false;
        public static bool isRightPressed = false;

        public static int speed = 20;
        public static int angle = 0;
        public static double mod = 0;
        public static double x = 200;
        public static double y = 200;        
        private MoveAlgorithm moveAlgorithm;

        public static bool isConnected = false;
        

        [DllImport("user32.dll", EntryPoint = "HideCaret")]
        public static extern long HideCaret(IntPtr hwnd);

        //current game information
        public List<Obstacle> obstacles;

        public Factory factory;
        public List<Collectable> collectables;
        public const int CollectablesOnMapCount = 5;
        public List<Player> players; // remake to be able to acce player by their id ... maybe
        public Player me;

        public Player GetPlayerById(int id)
        {
            for (int i = 0; i < players.Count; i++)
            {
                if(players[i].id == id)
                {
                    return players[i];
                }
            }
            return null;
        }

        public Form1()
        {
            InitializeComponent();
            factory = new CollectableFactory();
            players = new List<Player>();
            collectables = new List<Collectable>();
            for (int i = 0; i < CollectablesOnMapCount; i++)
            {
                collectables.Add(factory.GetCollectable(Collectable.Type.Bomb));
            }
        }

        private WebSocketAdapter client;
        const string host_begin = "ws://";
        Bitmap image;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            PlayingField_destroy();
            GameRate_Tick(sender,e);

            setMoveAlgorithm(new MoveStop()); // Initializing first time as stationary
            CarController carController = new CarController();
            carController.MakeSlowCar();
        }
        
        private void Form1_Resize(object sender, EventArgs e) // TODO: set default playing field ratio and hangle resizing all objects IF PAGE for e.g. MAXIMIZED IT SHOULD keep ratio to playingfield not window. and set it in the middle
        {
            Control control = (Control)sender;

            // Ensure the Form remains square (Height = Width). 
            if (control.Size.Height != control.Size.Width)
            {
                control.Size = new Size(control.Size.Width, control.Size.Width);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (isMessaging)
            {
            }
            else
            {
                if (e.KeyCode == Keys.Oemtilde) // go into messaging mode
                {
                    isMessaging = true;
                    InputMessageField.Focus();
                }
                else if (e.KeyCode == Keys.Up)
                {
                    isUpPressed = true;
                    
                    setMoveAlgorithm(new MoveFaster());

                }
                else if (e.KeyCode == Keys.Down)
                {
                    isDownPressed = true;
                    
                    setMoveAlgorithm(new MoveSlower());
                }
                else if (e.KeyCode == Keys.Left)
                {
                    isLeftPressed = true;
                    //angle -= 10;                    
                    setMoveAlgorithm(new MoveTurn(isLeftPressed, isRightPressed));
                }
                else if (e.KeyCode == Keys.Right)
                {
                    isRightPressed = true;                    
                    //angle += 10;
                    setMoveAlgorithm(new MoveTurn(isLeftPressed, isRightPressed));

                }
                else if (e.KeyCode == Keys.Z)
                {
                    setMoveAlgorithm(new MoveStop());
                }
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (isMessaging)
            {

            }
            else
            {
                if (e.KeyCode == Keys.Up)
                {
                    isUpPressed = false;
                    
                }
                else if (e.KeyCode == Keys.Down)
                {
                    isDownPressed = false;
                    
                }
                else if (e.KeyCode == Keys.Left)
                {
                    isLeftPressed = false;

                    //after turning setting move algorithm to previous
                    if (mod > 0)
                    {
                        setMoveAlgorithm(new MoveFaster());
                    }
                    else if (mod == 0)
                    {
                        setMoveAlgorithm(new MoveStop());
                    }
                    else if (mod < 0)
                    {
                        setMoveAlgorithm(new MoveSlower());
                    }
                }
                else if (e.KeyCode == Keys.Right)
                {
                    isRightPressed = false;

                    //after turning setting move algorithm to previous
                    if (mod > 0)
                    {
                        setMoveAlgorithm(new MoveFaster());
                    }
                    else if (mod == 0)
                    {
                        setMoveAlgorithm(new MoveStop());
                    }
                    else if (mod < 0)
                    {
                        setMoveAlgorithm(new MoveSlower());
                    }
                }

                /*if(e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                {
                    mod = 0;
                }*/

            }
        }

        private void GameRate_Tick(object sender, EventArgs e)
        {
            // TODO: add logic for moving
            // moving should be car like up- forward, down-slowing, left\right - rotating
            Timer timer = new Timer();
            timer.Interval = (100); // 10 secs
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e) // TODO remove this and transfer all code to GameRate_Tick // this is overkill
        {
            x += (speed * mod) * Math.Cos(Math.PI / 150 * angle);
            y += (speed * mod) * Math.Sin(Math.PI / 150 * angle);

            Point position = new Point(Convert.ToInt32(x),Convert.ToInt32(y));
            if(me != null)
            {
                me.car.Location = position;

                JObject message = new JObject();
                message["type"] = "updateLocation";
                message["location"] = new JObject();
                message["location"]["X"] = position.X;
                message["location"]["Y"] = position.Y;
                client.Send(message);
            }
            //DrawPlayer(position, Color.Red); // TODO: make drawing and call it here

            moveAlgorithm.Move();
            
        }

        //sets desired strategy pattern for movement (speeding, slowing, turning, or stopped)
        private void setMoveAlgorithm(MoveAlgorithm algorithm)
        {
            moveAlgorithm = algorithm;
        }



        public Point RotatePoint(Point p1, Point p2, double angle)
        {

            double radians = ConvertToRadians(angle);
            double sin = Math.Sin(radians);
            double cos = Math.Cos(radians);

            // Translate point back to origin
            p1.X -= p2.X;
            p1.Y -= p2.Y;

            // Rotate point
            double xnew = p1.X * cos - p1.Y * sin;
            double ynew = p1.X * sin + p1.Y * cos;

            // Translate point back
            Point newPoint = new Point((int)xnew + p2.X, (int)ynew + p2.Y);
            return newPoint;
        }

        public double ConvertToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
        }

        private void MessageInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                var content = InputMessageField.Text;
                InputMessageField.Text = "";
                JObject message = new JObject();
                message["type"] = "message";
                message["message"] = content;
                client.Send(message);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Oemtilde)
            {
                isMessaging = false;
                this.Focus(); // TODO: remove focus from input field to form - this don't work
            }
        }

        private void ConnectBTN_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                string host = host_begin + IPinput.Text + ":" + PortInput.Text;
                client = new WebSocketAdapter(host, this);

                MainMenuPanel.Visible = false;
                //TODO: add screen disabler - grey half transparent panel in background
                client.SetOnOpen(OnOpen);
                client.SetOnError(OnError);
                client.SetOnMessageReceived(MessageReceived);
                client.SetOnClose(OnClose);
                client.SetCookie("username", usernameInput.Text); // TODO maybe username not nickname
                client.Start();
            }
        }
        private void OnOpen()
        {
            isConnected = true;
            DebugLog(string.Format("Connected to {0} successfully ", client.Url()));
        }

        private void OnError(string message)
        {
            DebugLog("Error: " + message);
        }

        private void OnClose()
        {
            isConnected = false;
            DebugLog(string.Format("Disconnected with {0}", client.Url()));
            PlayingField_destroy();
        }

        private void MessageReceived(string dataString) // Facade // root message get function to call other functions to parse messages
        {
            DebugLog("Response: " + dataString);
            JObject data = JObject.Parse(dataString);
            switch (data["type"].ToString())
            {
                case "message":
                    ChatMessageReceived(data);
                    break;
                case "mapUpdate":
                    MapUpdateReceived(data);
                    break;
                case "mapSetup":
                    MapSetupReceived(data);
                    break;
                default:
                    DebugLog("ERROR undefined message received!!!");
                    break;
            }
        }

        private void DisconnectBTN_Click(object sender, EventArgs e)
        {
            client.Stop();
        }

        // paint map then connected to game
        private void PlayingField_setup() // TODO paint map (put all objects on map)
        {
            // map data should be gained from server
        }

        // draw map if disconnected from game or draw default if just turned on game
        private void PlayingField_destroy() // TODO remove all game info, clear area and paint default map (put all objects on map)
        {
            // map data should be gained from server
        }

        // update objects on playing field and stats
        // Param: data - changes of 
        private void PlayingField_update(JArray data) // TODO code static object position update or new adding, drops add, player postition update, statistics update
        {
            
        }

        private void SpawnPlayer(Player player) // create player car on map
        {
            player.initializeCar();
            this.Controls.Add(player.car);
        }

        private void ChatMessageReceived(JObject data)
        {
            string text = data["message"].ToString();

            Color color = GetPlayerById(int.Parse(data["sender"]["id"].ToString())).color;
            TextingField.SelectedRtf = string.Format(@"{{\rtf1\ansi \b {0} \b0 }}", data["sender"]["nickname"] + ": ");
            TextingField.SelectedRtf = string.Format(@"{{\rtf1\ansi \plain {0} \plain0 \par }}", text);
            string[] lines = TextingField.Lines;    // Count the lines of rich text box
            var start = TextingField.GetFirstCharIndexFromLine(lines.Count() - 2);  // Get the 1st char index of the appended text
            var length = lines[lines.Count() - 2].Length; // Get the last char index of appended text

            TextingField.Select(start, length);
            TextingField.SelectionColor = color;
        }

        private void MapUpdateReceived(JObject data) // received map changes data so apply to current localy saved game state
        {
            //PlayingField_update((JArray) data["mapChanges"]);

            foreach(var change in (JArray)data["mapChanges"])
            {
                if(change["type"].ToString() == "updateLocation") // TODO create static constants with API names
                {
                    int pubid = int.Parse(change["id"].ToString());
                    Point newpos = new Point(int.Parse(change["location"]["X"].ToString()), int.Parse(change["location"]["Y"].ToString()));
                    Player newplayer = new Player(pubid); // not smart to create new player each time
                    int index = players.IndexOf(newplayer);
                    if (index > 0)
                    {
                        Console.WriteLine("Location changed for: " + change["id"].ToString());
                        Console.WriteLine(players[index].car.Location.ToString());
                        Console.WriteLine(newpos.ToString());
                        players[index].position = newpos;
                        players[index].car.Location = newpos;
                    }
                }
            }
            //parse changes array here not give to other methods
        }

        private void MapSetupReceived(JObject data) // received data of all map so draw or update its up to client
        {
            //setting statistic
            int playercount = Int16.Parse(data["playerCount"].ToString());
            playerCounter.Text = "Players: " + playercount;
            playerCounter.BringToFront();
            //setting my data
            int myid = int.Parse(data["myData"]["id"].ToString());
            //spawning obstacles
            // TODO check obstacles list and add if none exists

            //adding players
            foreach (var player in (JObject)data["players"]) // TODO check if exists and update or create if not exists
            {
                string key = player.Key;
                int thisid = Int16.Parse(key);
                JToken value = player.Value;
                int id = thisid;// int.Parse(key);
                JToken location = value["location"];
                Point locationpoint = new Point(Int16.Parse(location["X"].ToString()), Int16.Parse(location["Y"].ToString()));
                Color color = Color.FromName(value["color"].ToString());
                //float angle = float.Parse(value["rotation"].ToString());

                Player newplayer = new Player(id); // not smart to create new player each time
                newplayer.position = locationpoint;
                newplayer.color = color;

                int idx = players.IndexOf(newplayer);
                if (idx == -1) // create new
                {
                    DebugLog("NEW PLAYER ADDED");
                    idx = players.Count;
                    players.Add(newplayer);
                    SpawnPlayer(newplayer);
                    if(id == myid)
                    {
                        x = newplayer.position.X; // TODO this variable should be in player object not form
                        y = newplayer.position.Y; // TODO this variable should be in player object not form 
                        me = newplayer;
                    }
                } // update existing
                else
                {
                    players[idx].position = newplayer.position;
                    players[idx].car.Location = players[idx].position;
                }
            }

            //spawning player cars
            // TODO check cars list and add if none exists
            
            //spawning packets
            // TODO check collectables list and add if none exists
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(image, 0, 0, image.Width, image.Height);
        }
       
        private void TextingField_TextChanged(object sender, EventArgs e)
        {
            // set the current caret position to the end
            TextingField.SelectionStart = TextingField.Text.Length;
            // scroll it automatically
            TextingField.ScrollToCaret();
        }

        private void DBPanelCnnectBTN_Click(object sender, EventArgs e)
        {
            // TODO: connect to databse register if not exists or connect and get player prefs from DB
        }

        // TODO make anabstract class for logger that can be singleton
        void DebugLog(string message)
        {
            DebugLogField.Select(DebugLogField.TextLength, DebugLogField.TextLength);
            DebugLogField.SelectedRtf = string.Format(@"{{\rtf1\ansi \plain {0} \plain0 \par }}", message);
            DebugLogField.ScrollToCaret();
        }
    }
}
