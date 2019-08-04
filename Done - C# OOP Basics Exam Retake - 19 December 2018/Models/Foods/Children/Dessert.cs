using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Foods.Children
{
    class Dessert : Food
    {
        private const int initialServingSize = 200;

        public Dessert(string name, decimal price) 
            : base(name, initialServingSize, price)
        {
        }
    }
}
