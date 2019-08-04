using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Drinks.Children
{
    class FuzzyDrink : Drink
    {
        private const decimal FuzzyDrinkprice = 2.50m;

        public FuzzyDrink(string name, int servingSize, string brand) 
            : base(name, servingSize, FuzzyDrinkprice, brand)
        {
        }
    }
}