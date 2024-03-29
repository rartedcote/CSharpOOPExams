﻿namespace AnimalCentre.Models.Animals.Child
{
    public class Lion : Animal
    {
        public Lion(string name, int energy, int happiness, int procedureTime) 
            : base(name, energy, happiness, procedureTime)
        {
        }

        public override string ToString()
        {
            return $"    Animal type: {GetType().Name} - {Name} - Happiness: {Happiness} - Energy: {Energy}";
        }
    }
}
