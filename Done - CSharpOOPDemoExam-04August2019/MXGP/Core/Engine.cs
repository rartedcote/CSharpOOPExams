using MXGP.Core.Contracts;
using MXGP.IO;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MXGP.Core
{
    public class Engine : IEngine
    {
        private ConsoleReader reader = new ConsoleReader();
        private ConsoleWriter writer = new ConsoleWriter();

        public Engine()
        {

        }

        IChampionshipController champController = new ChampionshipController();

        public void Run()
        {
            string input;
            while ((input = reader.ReadLine()) != "End")
            {
                string[] splitInput = input.Split(" ");
                try
                {
                    switch (splitInput[0])
                    {
                        case "CreateRider":
                            {
                                string name = splitInput[1];

                                writer.WriteLine(champController.CreateRider(name));
                            }
                            break;

                        case "CreateMotorcycle":
                            {
                                string type = splitInput[1];
                                string model = splitInput[2];
                                int horsePower = int.Parse(splitInput[3]);

                                writer.WriteLine(champController.CreateMotorcycle(type, model, horsePower));
                            }
                            break;

                        case "AddMotorcycleToRider":
                            {
                                string name = splitInput[1];
                                string motorName = splitInput[2];

                                writer.WriteLine(champController.AddMotorcycleToRider(name, motorName));
                            }
                            break;

                        case "AddRiderToRace":
                            {
                                string raceName = splitInput[1];
                                string riderName = splitInput[2];

                                writer.WriteLine(champController.AddRiderToRace(raceName, riderName));
                            }
                            break;

                        case "CreateRace":
                            {
                                string name = splitInput[1];
                                int laps = int.Parse(splitInput[2]);

                                writer.WriteLine(champController.CreateRace(name, laps));
                            }
                            break;

                        case "StartRace":
                            {
                                string name = splitInput[1];
                                writer.WriteLine(champController.StartRace(name));
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    if (ex is TargetInvocationException)
                    {
                        Console.WriteLine(ex.InnerException.Message);
                    }

                    else
                    {
                        Console.WriteLine(ex.Message);
                    }
                    continue;
                }
            }
        }
    }
}