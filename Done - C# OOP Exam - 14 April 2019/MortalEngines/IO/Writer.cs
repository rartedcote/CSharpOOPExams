using MortalEngines.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.IO
{
    public class Writer : IWriter
    {
        public void Write(string content)
        {
            Console.WriteLine(content);
        }
    }
}