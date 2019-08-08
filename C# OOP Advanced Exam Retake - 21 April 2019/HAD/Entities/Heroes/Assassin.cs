using System;
using System.Collections.Generic;
using System.Text;

namespace HAD.Entities.Heroes
{
    public class Assassin : BaseHero
    {
        public Assassin(string name) 
            : base(name, 25, 100, 15, 150, 300)
        {
        }
    }
}
