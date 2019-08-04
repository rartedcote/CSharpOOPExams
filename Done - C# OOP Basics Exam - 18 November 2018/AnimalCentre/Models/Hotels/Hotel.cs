using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Models.Hotels
{
    public class Hotel : IHotel
    {
        private const int capacity = 10;

        private Dictionary<string, IAnimal> animals = new Dictionary<string, IAnimal>();

        public IReadOnlyDictionary<string, IAnimal> Animals { get { return animals; } }

        public void Accommodate(IAnimal animal)
        {
            if (Animals.Count + 1 > capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NoSpace);
            }

            if (Animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }

            animals.Add(animal.Name, animal);
        }

        public string Adopt(string animalName, string owner)
        {
            if (!Animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            IAnimal animal = Animals[animalName];

            animal.IsAdopt = true;
            animal.Owner = owner;

            string chipText;

            if (animal.IsChipped)
            {
                chipText = $"{owner} adopted animal with chip";
            }

            else
            {
                chipText = $"{owner} adopted animal without chip";
            }

            animals.Remove(animalName);

            return chipText;
        }
    }
}