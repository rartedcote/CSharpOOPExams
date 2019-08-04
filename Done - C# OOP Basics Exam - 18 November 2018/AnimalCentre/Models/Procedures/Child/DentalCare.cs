using System;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures.Child
{
    public class DentalCare : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            CheckProcedureTime(animal, procedureTime);

            animal.Happiness += 12;
            animal.Energy += 10;
            animal.ProcedureTime -= procedureTime;

            ProcedureHistory.Add(animal);
        }
    }
}
