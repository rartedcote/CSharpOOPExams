using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures.Child
{
    public class Chip : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            CheckProcedureTime(animal, procedureTime);

            if (animal.IsChipped)
            {
                throw new ArgumentException($"{animal.Name} is already chipped");
            }

            animal.IsChipped = true;
            animal.Happiness -= 5;
            animal.ProcedureTime -= procedureTime;

            ProcedureHistory.Add(animal);
        }
    }
}