using SoftUniRestaurant.Models.Drinks.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SoftUniRestaurant.Models.Drinks
{
    public static class DrinkFactory
    {
        public static Drink GetDrink(string type, string name, int servingSize, string brand)
        {
            Type drinkType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == type);

            return (Drink)Activator.CreateInstance(drinkType, name, servingSize, brand);
        }
    }
}