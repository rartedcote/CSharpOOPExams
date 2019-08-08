using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Fighter : BaseMachine , IFighter
    {
        public Fighter(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints + 50, defensePoints - 25, 200)
        {
            AggressiveMode = true;
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            AggressiveMode = !AggressiveMode;

            if (AggressiveMode)
            {
                AttackPoints += 50;
                DefensePoints -= 25;
            }

            else
            {
                AttackPoints -= 50;
                DefensePoints += 25;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(base.ToString());

            sb.AppendLine($" *Aggressive: {(AggressiveMode ? "ON" : "OFF")}");

            return sb.ToString().Trim();
        }
    }
}
