using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsocketClient.State
{
    class MoveStateContext
    {
        public MoveState currentState;

        public MoveStateContext()
        {
            currentState = new MoveStopState();
        }

        public void SetState(MoveState state)
        {
            currentState = state;
        }

        public void Move()
        {
            currentState.Move(this);
        }
    }
}
