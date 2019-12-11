using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsocketClient
{
    public class CarBuilderDirector
    {
        private ICarBuilder Builder;
        public CarBuilderDirector(ICarBuilder builder)
        {
            Builder = builder;
        }

        public void AskBuilderForCarPreparation()
        {
            Builder.SetId();
            Builder.SetModel();
            Builder.SetHandling();
            Builder.SetAcceleration();
            Builder.SetSpeed();
        }
    }
}
