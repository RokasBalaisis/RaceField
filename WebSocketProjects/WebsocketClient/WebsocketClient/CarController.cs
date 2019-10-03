using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WebsocketClient
{
    public class CarController
    {
        public void MakeSlowCar()
        {
            var builder = new SlowCarBuilder();
            var director = new CarBuilderDirector(builder);

            director.AskBuilderForCarPreparation();
            Car slowCar = builder.BuildCar();
            Console.WriteLine("Slow car built");
            Console.WriteLine("Id:{0}", slowCar.Id);
            Console.WriteLine("Model:{0}", slowCar.Model);
            Console.WriteLine("Handling:{0}", slowCar.Handling);
            Console.WriteLine("Acceleration:{0}", slowCar.Acceleration);
            Console.WriteLine("Speed:{0}", slowCar.Speed);
        }
    }
}
