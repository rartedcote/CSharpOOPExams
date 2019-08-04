using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Foods.Children
{
    class MainCourse : Food
    {
        private const int initialServingSize = 500;

        public MainCourse(string name, decimal price)
            : base(name, initialServingSize, price)
        {
        }
    }
}
