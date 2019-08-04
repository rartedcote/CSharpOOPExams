using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Riders.Contracts;
using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Riders
{
    public class Rider : IRider
    {
        private string name;

        public Rider(string name)
        {
            Name = name;
        }

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, 5));
                }

                name = value;
            }
        }

        public IMotorcycle Motorcycle { get; private set; }

        public int NumberOfWins { get; private set; } = 0;

        public bool CanParticipate { get; private set; } = false;

        public void AddMotorcycle(IMotorcycle motorcycle)
        {
            if (motorcycle is null)
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.MotorcycleInvalid));
            }

            Motorcycle = motorcycle;
            CanParticipate = true;
        }

        public void WinRace()
        {
            NumberOfWins++;
        }
    }
}