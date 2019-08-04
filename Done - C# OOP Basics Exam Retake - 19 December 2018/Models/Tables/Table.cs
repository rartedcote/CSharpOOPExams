using SoftUniRestaurant.Models.Drinks.Contracts;
using SoftUniRestaurant.Models.Foods.Contracts;
using SoftUniRestaurant.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniRestaurant.Models.Tables
{
    public abstract class Table : ITable
    {
        private ICollection<IFood> foodOrders = new List<IFood>();
        private ICollection<IDrink> drinkOrders = new List<IDrink>();

        private int capacity;
        private int numberOfPeople;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;

            IsReserved = false;
        }

        public int TableNumber { get; private set; }

        public int Capacity
        {
            get => capacity;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0");
                }

                capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get => numberOfPeople;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }

                numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; private set; }

        public bool IsReserved { get; private set; }

        public decimal Price { get => NumberOfPeople * PricePerPerson; }

        public void Clear()
        {
            IsReserved = false;
            NumberOfPeople = 0;
            foodOrders = new List<IFood>();
            drinkOrders = new List<IDrink>();
        }

        public decimal GetBill()
        {
            decimal sum = foodOrders.Sum(f => f.Price);
            sum += drinkOrders.Sum(d => d.Price);
            sum += NumberOfPeople * PricePerPerson;

            return sum;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {TableNumber}");
            sb.AppendLine($"Type: {GetType().Name}");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.AppendLine($"Price per Person: {PricePerPerson}");

            return sb.ToString().Trim();
        }

        public string GetOccupiedTableInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {TableNumber}");
            sb.AppendLine($"Type: {GetType().Name}");
            sb.AppendLine($"Number of people: {NumberOfPeople}");

            if (foodOrders.Count == 0)
            {
                sb.AppendLine("Food orders: None");
            }

            else
            {
                sb.AppendLine($"Food orders: {foodOrders.Count}");

                foreach (IFood food in foodOrders)
                {
                    sb.AppendLine(food.ToString());
                }
            }

            if (drinkOrders.Count == 0)
            {
                sb.AppendLine("Drink orders: None");
            }

            else
            {
                sb.AppendLine($"Drink orders: {drinkOrders.Count}");

                foreach (IDrink drink in drinkOrders)
                {
                    sb.AppendLine(drink.ToString());
                }
            }

            return sb.ToString().Trim();
        }

        public void OrderDrink(IDrink drink)
        {
            drinkOrders.Add(drink);
        }

        public void OrderFood(IFood food)
        {
            foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            this.NumberOfPeople = numberOfPeople;
            IsReserved = true;
        }
    }
}