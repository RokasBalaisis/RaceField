using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WebsocketClient
{
    public class Memento
    {
        private int health;
        private Point position;
        private int angle;
        private int mod;

        public void setState(int health, Point position, int angle, int mod)
        {
            this.health = health;
            this.position = position;
            this.angle = angle;
            this.mod = mod;
        }

        public Tuple<int, Point, int, int> getState()
        {
            return new Tuple<int, Point, int, int>(health, position, angle, mod);
        }
    }
}
