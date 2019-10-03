using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsocketClient
{
    public interface ICarBuilder
    {
        void SetId();
        void SetModel();
        void SetHandling();
        void SetAcceleration();
        void SetSpeed();

        Car BuildCar();
    }
}
