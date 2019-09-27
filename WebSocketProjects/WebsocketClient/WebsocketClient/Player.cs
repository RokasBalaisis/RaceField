using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WebsocketClient
{
    public class Player
    {
        public int id;
        public TransparentCar car;
        public Point position;

        public Player(int id, Point position)
        {
            this.id = id;
            this.position = position;
            car = new TransparentCar();
            car.Location = position;
            car.Invalidate();
        }
    }
}
