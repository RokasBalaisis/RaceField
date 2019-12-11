using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSocketServerWorking
{
    public class DataChange // TODO make abstarct class for different changes 
    {
        public JObject change; // TODO store change type to indicate that change it is
        public DataChange(JObject change)
        {
            this.change = change;
        } 

        public override string ToString()
        {
            return change.ToString();
        }
    }
}
