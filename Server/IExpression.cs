using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSocketServerWorking
{
    public interface IExpression
    {
        void Interpret(Context context);
    }
}
