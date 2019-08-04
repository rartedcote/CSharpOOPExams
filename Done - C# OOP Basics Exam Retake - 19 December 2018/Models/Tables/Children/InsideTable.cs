using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Tables.Children
{
    class InsideTable : Table
    {
        private const decimal pricePerPerson = 2.50m;

        public InsideTable(int tableNumber, int capacity) 
            : base(tableNumber, capacity, pricePerPerson)
        {
        }
    }
}
