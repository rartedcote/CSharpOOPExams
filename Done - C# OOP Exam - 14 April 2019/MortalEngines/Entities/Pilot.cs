using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Pilot : IPilot
    {
        private string name;
        private List<IMachine> machines = new List<IMachine>();

        public Pilot(string name)
        {
            Name = name;
        }

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Pilot name cannot be null or empty string.");
                }

                name = value;
            }
        }

        public IReadOnlyCollection<IMachine> Machines { get => machines; }

        public void AddMachine(IMachine machine)
        {
            if (machine is null)
            {
                throw new NullReferenceException("Null machine cannot be added to the pilot.");
            }

            machines.Add(machine);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Name} - {Machines.Count} machines");

            foreach (IMachine machine in Machines)
            {
                sb.AppendLine(machine.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
