using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsocketClient
{
    public class CarCommand : ICommand
    {
        private readonly Car _car;
        private readonly CarAction _carAction;
        private readonly float _amount;

        public bool IsCommandExecuted { get; private set; }

        public CarCommand(Car car, CarAction carAction, float amount)
        {
            _car = car;
            _carAction = carAction;
            _amount = amount;
        }

        public void ExecuteAction()
        {
            if(_carAction == CarAction.IncreaseSpeed)
            {
                _car.IncreaseSpeed(_amount);
                IsCommandExecuted = true;
            }
            else
            {
               IsCommandExecuted = _car.DecreaseSpeed(_amount);
            }
        }

        public void UndoAction()
        {
            if (!IsCommandExecuted)
                return;
            if (_carAction == CarAction.IncreaseSpeed)
            {
                _car.DecreaseSpeed(_amount);
            }
            else
            {
                _car.IncreaseSpeed(_amount);
            }
        }
    }
}
