using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSocketServerWorking
{
    public class NoExpression : IExpression
    {
            public void Interpret(Context context)
            {
                Console.WriteLine("Please enter a command, for command list, use command \"help\" ");
            }
    }
}
