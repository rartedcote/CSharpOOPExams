using AnimalCentre.Models.Contracts;
using System;

namespace AnimalCentre.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        private int happiness;
        private int energy;

        public Animal(string name, int energy, int happiness, int procedureTime)
        {
            Name = name;
            Energy = energy;
            Happiness = happiness;
            ProcedureTime = procedureTime;

            Owner = "Centre";
            IsAdopt = false;
            IsChipped = false;
            IsVaccinated = false;
        }

        public string Name { get; private set; }

        public int Happiness
        {
            get => happiness;

            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidHappiness);
                }

                happiness = value;
            }
        }

        public int Energy
        {
            get => energy;

            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidEnergy);
                }

                energy = value;
            }
        }

        public int ProcedureTime { get; set; }

        public string Owner { get; set; }

        public bool IsAdopt { get; set; }

        public bool IsChipped { get; set; }

        public bool IsVaccinated { get; set; }
    }
}