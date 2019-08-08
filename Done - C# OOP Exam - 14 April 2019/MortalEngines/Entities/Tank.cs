using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Tank : BaseMachine, ITank
    {
        public Tank(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints - 40, defensePoints + 30, 100)
        {
            DefenseMode = true;
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            DefenseMode = !DefenseMode;

            if (DefenseMode)
            {
                AttackPoints += 40;
                DefensePoints += 30;
            }

            else
            {
                AttackPoints -= 40;
                DefensePoints += 30;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(base.ToString());

            sb.AppendLine($" *Defense: {(DefenseMode ? "ON" : "OFF")}");

            return sb.ToString().Trim();
        }
    }
}