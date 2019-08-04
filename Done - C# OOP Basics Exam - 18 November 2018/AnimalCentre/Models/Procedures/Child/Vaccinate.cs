using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures.Child
{
    public class Vaccinate : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            CheckProcedureTime(animal, procedureTime);

            animal.Energy -= 8;
            animal.IsVaccinated = true;
            animal.ProcedureTime -= procedureTime;

            ProcedureHistory.Add(animal);
        }
    }
}