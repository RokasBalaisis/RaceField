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

        public void IncreaseSpeed(float amount)
        {
            Speed += amount;
            Console.WriteLine($"The speed for the {Id}: {Model} has been increased by {amount}.");
        }

        public bool DecreaseSpeed(float amount)
        {
            if(amount < Speed)
            {
                Speed -= amount;
                Console.WriteLine($"The speed for the {Id}: {Model} has been decreased by {amount}");
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"Current speed  for the {Id}: {Model}  is {Speed}.";
        }
    }
}
