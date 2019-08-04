using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders.Contracts;
using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Races
{
    public class Race : IRace
    {
        private List<IRider> riders = new List<IRider>();

        private string name;
        private int laps;

        public Race(string name, int laps)
        {
            Name = name;
            Laps = laps;
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

        public int Laps
        {
            get => laps;

            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps, 1));
                }

                laps = value;
            }
        }

        public IReadOnlyCollection<IRider> Riders { get => riders; }

        public void AddRider(IRider rider)
        {
            if (rider is null)
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.RiderInvalid));
            }

            if (!rider.CanParticipate)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RiderNotParticipate, rider.Name));
            }

            if (riders.Contains(rider))
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.RiderAlreadyAdded, rider.Name, this.Name));
            }

            riders.Add(rider);
        }
    }
}