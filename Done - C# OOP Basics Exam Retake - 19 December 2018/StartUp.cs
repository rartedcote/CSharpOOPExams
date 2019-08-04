using SoftUniRestaurant.Core;
using System;
using System.Reflection;

namespace SoftUniRestaurant
{
    public class StartUp
    {
        public static void Main()
        {
            RestaurantController restaurantController = new RestaurantController();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputArgs = input
                    .Split(" ");

                string command = inputArgs[0];

                try
                {
                    switch (command)
                    {
                        case "AddFood":
                            {
                                string type = inputArgs[1];
                                string name = inputArgs[2];
                                decimal price = decimal.Parse(inputArgs[3]);

                                Console.WriteLine(restaurantController.AddFood(type, name, price));
                            }
                            break;

                        case "AddDrink":
                            {
                                string type = inputArgs[1];
                                string name = inputArgs[2];
                                int servingSize = int.Parse(inputArgs[3]);
                                string brand = inputArgs[4];

                                Console.WriteLine(restaurantController.AddDrink(type, name, servingSize, brand));
                            }
                            break;

                        case "AddTable":
                            {
                                string type = inputArgs[1];
                                int tableNumber = int.Parse(inputArgs[2]);
                                int capacity = int.Parse(inputArgs[3]);

                                Console.WriteLine(restaurantController.AddTable(type, tableNumber, capacity));
                            }
                            break;

                        case "ReserveTable":
                            {
                                Console.WriteLine(restaurantController.ReserveTable(int.Parse(inputArgs[1])));
                            }
                            break;

                        case "OrderFood":
                            {
                                int tableNumber = int.Parse(inputArgs[1]);
                                string foodName = inputArgs[2];

                                Console.WriteLine(restaurantController.OrderFood(tableNumber, foodName));
                            }
                            break;

                        case "OrderDrink":
                            {
                                int tableNumber = int.Parse(inputArgs[1]);
                                string drinkName = inputArgs[2];
                                string drinkBrand = inputArgs[3];

                                Console.WriteLine(restaurantController.OrderDrink(tableNumber, drinkName, drinkBrand));
                            }
                            break;

                        case "LeaveTable":
                            {
                                int tableNumber = int.Parse(inputArgs[1]);

                                Console.WriteLine(restaurantController.LeaveTable(tableNumber));
                            }
                            break;

                        case "GetFreeTablesInfo":
                            {
                                Console.WriteLine(restaurantController.GetFreeTablesInfo());
                            }
                            break;

                        case "GetOccupiedTablesInfo":
                            {
                                Console.WriteLine(restaurantController.GetOccupiedTablesInfo());
                            }
                            break;
                    }
                }

                catch (TargetInvocationException exc)
                {
                    Console.WriteLine(exc.InnerException.Message);
                    continue;
                }
            }

            Console.WriteLine(restaurantController.GetSummary());
        }
    }
}
