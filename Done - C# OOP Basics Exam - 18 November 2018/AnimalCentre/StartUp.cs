using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AnimalCentre.MortalEngines;

namespace AnimalCentre
{
    public class StartUp
    {
        public static Dictionary<string, List<string>> adoptedAnimals = new Dictionary<string, List<string>>();

        public static void Main(string[] args)
        {
            MortalEngines.AnimalCentre animalCentre = new MortalEngines.AnimalCentre();


            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] dataSplit = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (dataSplit[0])
                {
                    case "RegisterAnimal":
                        try
                        {
                            RegisterAnimal(dataSplit.Skip(1).ToArray(), animalCentre);
                        }
                        catch (Exception tiex)
                        {
                            if (tiex is TargetInvocationException)
                            {
                                Console.WriteLine($"{tiex.InnerException.GetType().Name}: {tiex.InnerException.Message}");
                            }

                            else
                            {
                                Console.WriteLine($"{tiex.GetType().Name}: {tiex.Message}");
                            }
                            continue;
                        }
                        break;

                    case "Chip":
                        try
                        {
                            ChipAnimal(dataSplit.Skip(1).ToArray(), animalCentre);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"{ex.GetType().Name}: {ex.Message}");
                            continue;
                        }
                        break;

                    case "Vaccinate":
                        try
                        {
                            VaccinateAnimal(dataSplit.Skip(1).ToArray(), animalCentre);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"{ex.GetType().Name}: {ex.Message}");
                            continue;
                        }
                        break;

                    case "Fitness":
                        try
                        {
                            FitnessAnimal(dataSplit.Skip(1).ToArray(), animalCentre);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"{ex.GetType().Name}: {ex.Message}");
                            continue;
                        }
                        break;

                    case "Play":
                        try
                        {
                            PlayWithAnimal(dataSplit.Skip(1).ToArray(), animalCentre);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"{ex.GetType().Name}: {ex.Message}");
                            continue;
                        }
                        break;

                    case "DentalCare":
                        try
                        {
                            DentalCareAnimal(dataSplit.Skip(1).ToArray(), animalCentre);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"{ex.GetType().Name}: {ex.Message}");
                            continue;
                        }
                        break;

                    case "NailTrim":
                        try
                        {
                            NailTrimAnimal(dataSplit.Skip(1).ToArray(), animalCentre);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"{ex.GetType().Name}: {ex.Message}");
                            continue;
                        }
                        break;

                    case "Adopt":
                        try
                        {
                            AdoptAnimal(dataSplit.Skip(1).ToArray(), animalCentre);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"{ex.GetType().Name}: {ex.Message}");
                            continue;
                        }
                        break;

                    case "History":
                        try
                        {
                            HistoryAnimal(dataSplit.Skip(1).ToArray(), animalCentre);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"{ex.GetType().Name}: {ex.Message}");
                            continue;
                        }
                        break;
                }
            }

            foreach (var item in adoptedAnimals.OrderBy(x => x.Key))
            {
                Console.WriteLine($"--Owner: {item.Key}");
                Console.WriteLine($"    - Adopted animals: {string.Join(" ", item.Value)}");
            }
        }

        private static void HistoryAnimal(string[] args, MortalEngines.AnimalCentre animalCentre)
        {
            string procedureType = args[0];

            Console.WriteLine(animalCentre.History(procedureType));
        }

        private static void AdoptAnimal(string[] args, MortalEngines.AnimalCentre animalCentre)
        {
            string name = args[0];
            string owner = args[1];

            Console.WriteLine(animalCentre.Adopt(name, owner));

            if (adoptedAnimals.ContainsKey(owner))
            {
                adoptedAnimals[owner].Add(name);
            }

            else
            {
                adoptedAnimals.Add(owner, new List<string>());
                adoptedAnimals[owner].Add(name);
            }
        }

        private static void NailTrimAnimal(string[] args, MortalEngines.AnimalCentre animalCentre)
        {
            string name = args[0];
            int procedureTime = int.Parse(args[1]);

            Console.WriteLine(animalCentre.NailTrim(name, procedureTime));
        }

        private static void DentalCareAnimal(string[] args, MortalEngines.AnimalCentre animalCentre)
        {
            string name = args[0];
            int procedureTime = int.Parse(args[1]);

            Console.WriteLine(animalCentre.DentalCare(name, procedureTime));
        }

        private static void PlayWithAnimal(string[] args, MortalEngines.AnimalCentre animalCentre)
        {
            string name = args[0];
            int procedureTime = int.Parse(args[1]);

            Console.WriteLine(animalCentre.Play(name, procedureTime));
        }

        private static void FitnessAnimal(string[] args, MortalEngines.AnimalCentre animalCentre)
        {
            string name = args[0];
            int procedureTime = int.Parse(args[1]);

            Console.WriteLine(animalCentre.Fitness(name, procedureTime));
        }

        private static void VaccinateAnimal(string[] args, MortalEngines.AnimalCentre animalCentre)
        {
            string name = args[0];
            int procedureTime = int.Parse(args[1]);

            Console.WriteLine(animalCentre.Vaccinate(name, procedureTime));
        }

        private static void ChipAnimal(string[] args, MortalEngines.AnimalCentre animalCentre)
        {
            string name = args[0];
            int procedureTime = int.Parse(args[1]);

            Console.WriteLine(animalCentre.Chip(name, procedureTime));
        }

        private static void RegisterAnimal(string[] args, MortalEngines.AnimalCentre animalCentre)
        {
            string type = args[0];
            string name = args[1];
            int energy = int.Parse(args[2]);
            int happiness = int.Parse(args[3]);
            int procedureTime = int.Parse(args[4]);

            Console.WriteLine(animalCentre.RegisterAnimal(type, name, energy, happiness, procedureTime));
        }
    }
}