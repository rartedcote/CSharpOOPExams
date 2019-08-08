using MortalEngines.Core.Contracts;
using MortalEngines.IO;
using MortalEngines.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Core
{
    public class Engine : IEngine
    {
        private IReader reader = new Reader();
        private IWriter writer = new Writer();
        private IMachinesManager machinesManager = new MachinesManager();

        public void Run()
        {
            IList<ICommand> commands = reader.ReadCommands();

            foreach (ICommand command in commands)
            {
                try
                {
                    string[] commandParams = command.CommandParams;
                    switch (command.CommandType)
                    {
                        case "HirePilot":
                            {
                                writer.Write(machinesManager.HirePilot(commandParams[0]));
                            }
                            break;

                        case "PilotReport":
                            {
                                writer.Write(machinesManager.PilotReport(commandParams[0]));
                            }
                            break;

                        case "ManufactureTank":
                            {
                                writer.Write(machinesManager.ManufactureTank(commandParams[0], double.Parse(commandParams[1]), double.Parse(commandParams[2])));
                            }
                            break;

                        case "ManufactureFighter":
                            {
                                writer.Write(machinesManager.ManufactureFighter(commandParams[0], double.Parse(commandParams[1]), double.Parse(commandParams[2])));
                            }
                            break;

                        case "MachineReport":
                            {
                                writer.Write(machinesManager.MachineReport(commandParams[0]));
                            }
                            break;

                        case "AggressiveMode":
                            {
                                writer.Write(machinesManager.ToggleFighterAggressiveMode(commandParams[0]));
                            }
                            break;

                        case "DefenseMode":
                            {
                                writer.Write(machinesManager.ToggleTankDefenseMode(commandParams[0]));
                            }
                            break;

                        case "Engage":
                            {
                                writer.Write(machinesManager.EngageMachine(commandParams[0], commandParams[1]));
                            }
                            break;

                        case "Attack":
                            {
                                writer.Write(machinesManager.AttackMachines(commandParams[0], commandParams[1]));
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
        }
    }
}