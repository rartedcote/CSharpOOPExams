using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures.Child
{
    public class NailTrim : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            CheckProcedureTime(animal, procedureTime);

            animal.Happiness -= 7;
            animal.ProcedureTime -= procedureTime;

            ProcedureHistory.Add(animal);
        }
    }
}
