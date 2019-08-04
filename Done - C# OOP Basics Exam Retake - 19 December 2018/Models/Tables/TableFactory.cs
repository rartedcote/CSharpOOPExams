using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SoftUniRestaurant.Models.Tables
{
    public static class TableFactory
    {
        public static Table GetTable(string type, int tableNumber, int capacity)
        {
            Type tableType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == type);

            return (Table)Activator.CreateInstance(tableType, tableNumber, capacity);
        }
    }
}