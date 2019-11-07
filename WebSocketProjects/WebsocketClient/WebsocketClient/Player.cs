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
        public int speed;
        public int angle;
        public int mod;
        public Color color;

        private MoveAlgorithm moveAlgorithm;

        public Player(int id)
        {
            this.id = id;
            //this.position = position;
        }

        public void initializeCar()
        {
            car = new TransparentCar();
            car.Location = position;
        }

        public void setMoveAlgorithm (MoveAlgorithm algorithm)
        {
            this.moveAlgorithm = algorithm;
        }

        public void Move()
        {            
            moveAlgorithm.Move();
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

        public override bool Equals(object obj)
        {

            return id.Equals(((Player)obj).id);
        }
    }
}
