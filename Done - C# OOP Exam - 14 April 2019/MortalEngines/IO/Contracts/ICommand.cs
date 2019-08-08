using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.IO.Contracts
{
    public interface ICommand
    {
        string CommandType { get; }
        string[] CommandParams { get; }
    }
}