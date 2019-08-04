using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Foods.Children
{
    class Salad : Food
    {
        private const int initialServingSize = 300;

        public Salad(string name, decimal price) 
            : base(name, initialServingSize, price)
        {
        }
    }
}
