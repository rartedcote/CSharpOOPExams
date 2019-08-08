using MortalEngines.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MortalEngines.IO
{
    public class Reader : IReader
    {
        public IList<ICommand> ReadCommands()
        {
            string input;
            List<ICommand> commands = new List<ICommand>();

            while ((input = Console.ReadLine()) != "Quit")
            {
                string[] commandSplit = input.Split(" ");
                string commandType = commandSplit[0];
                string[] commandParams = commandSplit.Skip(1).ToArray();

                ICommand command = new Command(commandType, commandParams);

                commands.Add(command);
            }

            return commands;
        }
    }
}