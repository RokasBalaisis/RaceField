using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using System.Windows.Forms;
using WebSocketSharp.Net;
using Newtonsoft.Json.Linq;

namespace WebsocketClient
{
    public class WebSocketAdapter
    {
        private WebSocket adaptee;
        private Form1 form1;

        public WebSocketAdapter(string url, Form1 form1)
        {
            adaptee = new WebSocket(url);
            this.form1 = form1;
        }

        public void SetOnMessageReceived(Action<string> action)
        {
            adaptee.OnMessage += (ss, ee) =>
            {
                if (form1.InvokeRequired)
                {
                    form1.BeginInvoke((MethodInvoker)delegate ()
                    {
                        action(ee.Data);
                    });
                }
                else
                {
                    action(ee.Data);
                }
            };
        }

        public void SetOnOpen(Action action)
        {
            adaptee.OnOpen += (ss, ee) =>
            {
                if (form1.InvokeRequired)
                {
                    form1.BeginInvoke((MethodInvoker)delegate ()
                    {
                        action();
                    });
                }
                else
                {
                    action();
                }
            };
        }

        public void SetOnClose(Action action)
        {
            adaptee.OnClose += (ss, ee) =>
            {
                if (form1.InvokeRequired)
                {
                    form1.BeginInvoke((MethodInvoker)delegate ()
                    {
                        action();
                    });
                }
                else
                {
                    action();
                }
            };
        }

        public void SetOnError(Action<string> action)
        {
            adaptee.OnError += (ss, ee) =>
            {
                if (form1.InvokeRequired)
                {
                    form1.BeginInvoke((MethodInvoker)delegate ()
                    {
                        action(ee.Message);
                    });
                }
                else
                {
                    action(ee.Message);
                }
            };
        }

        public void SetCookie(string name, string value)
        {
            adaptee.SetCookie(new Cookie(name, value));
        }

        public string Url()
        {
            return adaptee.Url.ToString();
        }

        public void Start()
        {
            adaptee.Connect();
        }

        public void Stop()
        {
            adaptee.Close();
        }

        public void Send(string message)
        {
            adaptee.Send(message);
        }
        public void Send(JObject message)
        {
            adaptee.Send(message.ToString());
        }
    }
}
