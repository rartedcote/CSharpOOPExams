using System;
using System.Collections.Generic;
using System.Text;

namespace HAD.Entities.Heroes
{
    public class Wizard : BaseHero
    {
        public Wizard(string name) 
            : base(name, 25, 25, 100, 100, 250)
        {
        }
    }
}
