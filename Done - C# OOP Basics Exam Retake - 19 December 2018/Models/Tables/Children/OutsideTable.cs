using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Tables.Children
{
    class OutsideTable : Table
    {
        private const decimal pricePerPerson = 3.50m;

        public OutsideTable(int tableNumber, int capacity) 
            : base(tableNumber, capacity, pricePerPerson)
        {
        }
    }
}
