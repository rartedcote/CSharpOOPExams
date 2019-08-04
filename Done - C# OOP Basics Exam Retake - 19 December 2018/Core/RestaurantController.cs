namespace SoftUniRestaurant.Core
{
    using Models.Drinks.Contracts;
    using Models.Foods.Contracts;
    using Models.Drinks;
    using Models.Foods;
    using Models.Tables.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SoftUniRestaurant.Models.Tables;
    using System.Text;

    public class RestaurantController
    {
        private ICollection<IDrink> drinks = new List<IDrink>();
        private ICollection<IFood> menu = new List<IFood>();
        private ICollection<ITable> tables = new List<ITable>();

        private decimal income = 0;

        public string AddFood(string type, string name, decimal price)
        {
            IFood food = FoodFactory.GetFood(type, name, price);

            if (!(food is null))
            {
                menu.Add(food);
                return $"Added {name} ({type}) with price {price:f2} to the pool";
            }

            return null;
        }

        public string AddDrink(string type, string name, int servingSize, string brand)
        {
            IDrink drink = DrinkFactory.GetDrink(type, name, servingSize, brand);

            if (!(drink is null))
            {
                drinks.Add(drink);
                return $"Added {name} ({brand}) to the drink pool";
            }

            return null;
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            string newType = $"{type}Table";
            ITable table = TableFactory.GetTable(newType, tableNumber, capacity);

            if (!(table is null))
            {
                tables.Add(table);
                return $"Added table number {tableNumber} in the restaurant";
            }

            return null;
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable unreservedTable = null;

            foreach (ITable table in tables)
            {
                if (!table.IsReserved && table.Capacity >= numberOfPeople)
                {
                    unreservedTable = table;
                    unreservedTable.Reserve(numberOfPeople);
                    break;
                }
            }

            if (unreservedTable is null)
            {
                return $"No available table for {numberOfPeople} people";
            }

            else
            {
                return $"Table {unreservedTable.TableNumber} has been reserved for {numberOfPeople} people";
            }
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            if (table is null)
            {
                return $"Could not find table with {tableNumber}";
            }

            IFood food = menu.FirstOrDefault(f => f.Name == foodName);

            if (food is null)
            {
                return $"No {foodName} in the menu";
            }

            table.OrderFood(food);

            return $"Table {tableNumber} ordered {foodName}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            if (table is null)
            {
                return $"Could not find table with {tableNumber}";
            }

            IDrink drink = drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);

            if (drink is null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }

            table.OrderDrink(drink);

            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {table.GetBill():F2}");

            income += table.GetBill();

            table.Clear();

            return sb.ToString().Trim();
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (ITable table in tables)
            {
                if (!table.IsReserved)
                {
                    sb.AppendLine(table.GetFreeTableInfo());
                }
            }

            return sb.ToString().Trim();
        }

        public string GetOccupiedTablesInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (ITable table in tables)
            {
                if (table.IsReserved)
                {
                    sb.AppendLine(table.GetOccupiedTableInfo());
                }
            }

            return sb.ToString().Trim();
        }

        public string GetSummary()
        {
            return $"Total income: {income:f2}lv";
        }
    }
}