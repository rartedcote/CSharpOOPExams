using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Foods.Children
{
    class Soup : Food
    {
        private const int initialServingSize = 245;

        public Soup(string name, decimal price)
            : base(name, initialServingSize, price)
        {
        }
    }
}
