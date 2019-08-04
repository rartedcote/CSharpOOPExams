using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Hotels;
using AnimalCentre.Models.Procedures;
using AnimalCentre.Models.Procedures.Child;
using AnimalCentre.MortalEngines.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AnimalCentre.MortalEngines
{
    public class AnimalCentre : IAnimalCentre
    {
        private Chip chip = new Chip();
        private DentalCare dentalCare = new DentalCare();
        private Fitness fitness = new Fitness();
        private NailTrim nailTrim = new NailTrim();
        private Play play = new Play();
        private Vaccinate vaccinate = new Vaccinate();
        private Hotel hotel = new Hotel();

        private void CheckIfAnimalExist(string name)
        {
            if (!hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AnimalNotExist, name));
            }
        }

        public string Adopt(string animalName, string owner)
        {
            CheckIfAnimalExist(animalName);

            return hotel.Adopt(animalName, owner);
        }

        public string Chip(string name, int procedureTime)
        {
            CheckIfAnimalExist(name);

            chip.DoService(hotel.Animals[name], procedureTime);

            return $"{name} had chip procedure";
        }

        public string DentalCare(string name, int procedureTime)
        {
            CheckIfAnimalExist(name);

            dentalCare.DoService(hotel.Animals[name], procedureTime);

            return $"{name} had dental care procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            CheckIfAnimalExist(name);

            fitness.DoService(hotel.Animals[name], procedureTime);

            return $"{name} had fitness procedure";
        }

        public string History(string type)
        {
            switch (type)
            {
                case "Chip":
                    return chip.History();
                case "DentalCare":
                    return dentalCare.History();
                case "Fitness":
                    return fitness.History();
                case "NailTrim":
                    return nailTrim.History();
                case "Play":
                    return play.History();
                default:
                    return vaccinate.History();
            }
        }

        public string NailTrim(string name, int procedureTime)
        {
            CheckIfAnimalExist(name);

            nailTrim.DoService(hotel.Animals[name], procedureTime);

            return $"{name} had nail trim procedure";
        }

        public string Play(string name, int procedureTime)
        {
            CheckIfAnimalExist(name);

            play.DoService(hotel.Animals[name], procedureTime);

            return $"{name} was playing for {procedureTime} hours";
        }

        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            Type animalType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == type);

            IAnimal animal = (IAnimal)Activator.CreateInstance(animalType, name, energy, happiness, procedureTime);

            hotel.Accommodate(animal);

            return $"Animal {name} registered successfully";
        }

        public string Vaccinate(string name, int procedureTime)
        {
            CheckIfAnimalExist(name);

            vaccinate.DoService(hotel.Animals[name], procedureTime);

            return $"{name} had vaccination procedure";
        }
    }
}