using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices;
using WebSocketSharp.Net;

namespace WebsocketClient
{
    public partial class Form1 : Form //     !!!!!!!! ! WARNING ! !!!!!!!!    must be first class in this file
    {
        [DllImport("user32.dll", EntryPoint = "HideCaret")]
        public static extern long HideCaret(IntPtr hwnd);

        public Form1()
        {
            InitializeComponent();
        }

        private WebSocket client;
        const string host_begin = "ws://";
        Bitmap image;

        private void Form1_Load(object sender, EventArgs e)
        {
            image = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            PlayingField_Paint();
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

        private void SendBtn_Click(object sender, EventArgs e)
        {
            var content = textBox1.Text;
            textBox1.Text = "";
            JObject message = new JObject();
            message["message"] = content;
            client.Send(message.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string host = host_begin + IPinput.Text + ":" + PortInput.Text;
            client = new WebSocket(host);

            client.OnOpen += (ss, ee) =>
            {
                
                listBox1.Items.Add(string.Format("Connected to {0} successfully ", host));
            };

            client.OnError += (ss, ee) =>
               listBox1.Items.Add("Error: " + ee.Message);

            client.OnMessage += (ss, ee) =>
            {
                MessageReceived(ss, ee);
            };

            client.OnClose += (ss, ee) =>
            {
                listBox1.Items.Add(string.Format("Disconnected with {0}", host));
                PlayingField_Paint();
            };
            client.SetCookie(new Cookie("username", usernameInput.Text));
            client.Connect();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            client.Close();
            PlayingField_Paint();
        }

        private void PlayingField_Paint()
        {

            Graphics g = Graphics.FromImage(image);
            g.FillRectangle(Brushes.Black, pictureBox1.ClientRectangle);
            pictureBox1.Invalidate();
            //player initial location should be received from server along with map size and data
        }

        private void DrawPlayer(Point position, Color color)
        {
            
            Point[] points = new Point[4];
            points[0] = new Point(-5 + position.X, -5 + position.Y);
            points[1] = new Point(-5 + position.X, 5 + position.Y);
            points[2] = new Point(5 + position.X, 5 + position.Y);
            points[3] = new Point(5 + position.X, -5 + position.Y);

            Brush brush = new SolidBrush(color);
            Graphics g = Graphics.FromImage(image);
            g.FillPolygon(brush, points); // needs graphics object don't know how to get it
            pictureBox1.Invalidate();
        }

        private void MessageReceived(object ss, MessageEventArgs ee) // root message get function to call other functions to parse messages
        {
            listBox1.Items.Add("Response: " + ee.Data);
            JObject data = JObject.Parse(ee.Data);
            if (data["type"].ToString() == "message")
            {
                string text = data["message"].ToString();
                Color color = Color.FromName(data["sender"]["color"].ToString());
                richTextBox1.SelectedRtf = string.Format(@"{{\rtf1\ansi \b {0} \b0 }}", data["sender"]["username"] + ": ");
                richTextBox1.SelectedRtf = string.Format(@"{{\rtf1\ansi \plain {0} \plain0 \par }}", text);
                string[] lines = richTextBox1.Lines;    // Count the lines of rich text box
                var start = richTextBox1.GetFirstCharIndexFromLine(lines.Count() - 2);  // Get the 1st char index of the appended text
                var length = lines[lines.Count() - 2].Length; // Get the last char index of appended text

                richTextBox1.Select(start, length);
                richTextBox1.SelectionColor = color;

            }
            else
            {//type mapupdate
                PlayingField_Paint();
                int playercount = Int16.Parse(data["playerCount"].ToString());
                playerCounter.Text = "Players: " + playercount;
                playerCounter.BringToFront();
                int id = Int16.Parse(data["id"].ToString());
                foreach (var player in (JObject)data["players"])
                {
                    string key = player.Key;
                    int thisid = Int16.Parse(key);
                    JToken value = player.Value;
                    JToken location = value["location"];
                    Point locationpoint = new Point(Int16.Parse(location["X"].ToString()), Int16.Parse(location["Y"].ToString()));
                    Color color = Color.FromName(value["color"].ToString());
                    if (id == thisid)
                    {
                        DrawPlayer(locationpoint, color);
                    }
                    else
                    {
                        DrawPlayer(locationpoint, color);
                    }
                }
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(image, 0, 0, image.Width, image.Height);
        }
       
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            // set the current caret position to the end
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            // scroll it automatically
            richTextBox1.ScrollToCaret();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                SendBtn.PerformClick();

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

    }

    public class Player
    {
        // all player drawing stats settings and functions to draw it
        // maybe some other class for current player, because it will have more functionality and controlls 
    }


}
