﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsocketClient
{
    public interface ICommand
    {
        void ExecuteAction();
        void UndoAction();
    }
}