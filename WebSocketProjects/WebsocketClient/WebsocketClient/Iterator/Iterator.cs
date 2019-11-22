using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsocketClient
{
    public interface GameIterator
    {
        IterableViewObject First();
        IterableViewObject Next();
        bool HasNext();
    }
}
