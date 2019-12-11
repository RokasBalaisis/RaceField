using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsocketClient
{
    class Car_ModifySpeed
    {
        private readonly List<ICommand> _commands;
        private ICommand _command;

        public Car_ModifySpeed()
        {
            _commands = new List<ICommand>();
        }

        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        public void Invoke()
        {
            _commands.Add(_command);
            _command.ExecuteAction();
        }

        public void UndoActions()
        {
            foreach(var command in Enumerable.Reverse(_commands))
            {
                command.UndoAction();
            }
        }
    }
}
