using PlayersAndMonsters.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PlayersAndMonsters.Core
{
    class Engine : IEngine
    {
        private ManagerController managerController = new ManagerController();
        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != "Exit")
            {
                string[] splitInput = input.Split(" ");
                string commandType = splitInput[0];

                try
                {
                    switch (commandType)
                    {
                        case "AddPlayer":
                            {
                                string playerType = splitInput[1];
                                string username = splitInput[2];

                                Console.WriteLine(managerController.AddPlayer(playerType, username));
                            }
                            break;

                        case "AddCard":
                            {
                                string cardType = splitInput[1];
                                string name = splitInput[2];

                                Console.WriteLine(managerController.AddCard(cardType, name));
                            }
                            break;

                        case "AddPlayerCard":
                            {
                                string username = splitInput[1];
                                string cardName = splitInput[2];

                                Console.WriteLine(managerController.AddPlayerCard(username, cardName));
                            }
                            break;

                        case "Fight":
                            {
                                string attackerName = splitInput[1];
                                string enemyUser = splitInput[2];

                                Console.WriteLine(managerController.Fight(attackerName, enemyUser));
                            }
                            break;

                        case "Report":
                            Console.WriteLine(managerController.Report());
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
                }
            }
        }
    }
}