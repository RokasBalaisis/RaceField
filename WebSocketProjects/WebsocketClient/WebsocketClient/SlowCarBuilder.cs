using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsocketClient
{
    public class SlowCarBuilder : ICarBuilder
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public float Handling { get; set; }
        public float Acceleration { get; set; }
        public float Speed { get; set; }

        public void SetId()
        {
            Id = 1;
        }

        public void SetModel()
        {
            Model = "car_green.png";
        }

        public void SetHandling()
        {
            Handling = 0.25f;
        }

        public void SetAcceleration()
        {
            Acceleration = 0.35f;
        }

        public void SetSpeed()
        {
            Speed = 1.5000000f;
        }

        public Car BuildCar()
        {
            return new Car(Id, Model, Handling, Acceleration, Speed);
        }

    }
}
