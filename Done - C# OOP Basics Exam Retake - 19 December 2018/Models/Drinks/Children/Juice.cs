﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Drinks.Children
{
    class Juice : Drink
    {
        private const decimal JuicePrice = 1.80m;

        public Juice(string name, int servingSize, string brand) 
            : base(name, servingSize, JuicePrice, brand)
        {
        }
    }
}