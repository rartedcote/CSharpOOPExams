﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities.Contracts
{
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot = null;

        public BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            Name = name;
            AttackPoints = attackPoints;
            DefensePoints = defensePoints;
            HealthPoints = healthPoints;

            Targets = new List<string>();
        }

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Machine name cannot be null or empty.");
                }

                name = value;
            }
        }


        public IPilot Pilot
        {
            get => pilot;

            set
            {
                if (value is null)
                {
                    throw new NullReferenceException("Pilot cannot be null.");
                }

                pilot = value;
            }
        }

        public double HealthPoints { get; set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IList<string> Targets { get; private set; }

        public void Attack(IMachine target)
        {
            if (target is null)
            {
                throw new NullReferenceException("Target cannot be null");
            }

            target.HealthPoints -= (AttackPoints - target.DefensePoints);

            if (target.HealthPoints < 0)
            {
                target.HealthPoints = 0;
            }

            Targets.Add(target.Name);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"- {Name}");
            sb.AppendLine($" *Type: {GetType().Name}");
            sb.AppendLine($" *Health: {HealthPoints:F2}");
            sb.AppendLine($" *Attack: {AttackPoints:F2}");
            sb.AppendLine($" *Defense: {DefensePoints:F2}");
            sb.AppendLine($" *Targets: {(Targets.Count == 0 ? "None" : string.Join(", ", Targets))}");

            return sb.ToString();
        }
    }
}