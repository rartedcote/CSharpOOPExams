﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Animals.Child
{
    public class Pig : Animal
    {
        public Pig(string name, int energy, int happiness, int procedureTime) 
            : base(name, energy, happiness, procedureTime)
        {
        }

        public override string ToString()
        {
            return $"    Animal type: {GetType().Name} - {Name} - Happiness: {Happiness} - Energy: {Energy}";
        }
    }
}