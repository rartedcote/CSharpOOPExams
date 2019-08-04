using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        protected ICollection<IAnimal> ProcedureHistory = new List<IAnimal>();

        public abstract void DoService(IAnimal animal, int procedureTime);

        protected void CheckProcedureTime(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime < procedureTime)
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }
        }

        public string History()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{GetType().Name}");

            foreach (Animal animal in ProcedureHistory)
            {
                sb.AppendLine($"    Animal type: {animal.GetType().Name} - {animal.Name} - Happiness: {animal.Happiness} - Energy: {animal.Energy}");
            }

            return sb.ToString().Trim();
        }
    }
}