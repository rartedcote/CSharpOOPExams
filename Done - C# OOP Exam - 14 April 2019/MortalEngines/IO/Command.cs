using MortalEngines.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.IO
{
    public class Command : ICommand
    {
        public Command(string commandType, params string[] commandParams)
        {
            CommandType = commandType;
            CommandParams = commandParams;
        }

        public string[] CommandParams { get; private set; }

        public string CommandType { get; private set; }
    }
}