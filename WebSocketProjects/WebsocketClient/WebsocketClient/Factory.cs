using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsocketClient
{
    public abstract class Factory
    {
        public abstract Collectable GetCollectable(Collectable.Type type);
    }
}