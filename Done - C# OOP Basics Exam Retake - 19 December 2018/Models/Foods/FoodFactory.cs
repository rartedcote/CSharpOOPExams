using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SoftUniRestaurant.Models.Foods
{
    public static class FoodFactory
    {
        public static Food GetFood(string type, string name, decimal price)
        {
            Type foodType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);

            return (Food)Activator.CreateInstance(foodType, name, price);
        }
    }
}