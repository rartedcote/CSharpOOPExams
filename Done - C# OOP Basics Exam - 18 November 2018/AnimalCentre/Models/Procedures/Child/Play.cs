using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures.Child
{
    public class Play : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            CheckProcedureTime(animal, procedureTime);

            animal.Energy -= 6;
            animal.Happiness += 12;
            animal.ProcedureTime -= procedureTime;

            ProcedureHistory.Add(animal);
        }
    }
}