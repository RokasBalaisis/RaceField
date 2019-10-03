using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsocketClient
{
    /// <summary>
    /// Produktas - automobilis, kuris yra kuriamas Builder'io
    /// </summary>
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public float Handling { get; set; }
        public float Acceleration { get; set; }
        public float Speed { get; set; }

        public Car(int id, string model, float handling, float acceleration, float speed)
        {
            Id = id;
            Model = model;
            Handling = handling;
            Acceleration = acceleration;
            Speed = speed;
        }
    }
}
