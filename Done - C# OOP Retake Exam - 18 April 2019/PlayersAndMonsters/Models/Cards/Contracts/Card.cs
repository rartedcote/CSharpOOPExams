using System;

namespace PlayersAndMonsters.Models.Cards.Contracts
{
    public abstract class Card : ICard
    {
        private string name;
        private int damagePoints;
        private int healthPoints;

        public Card(string name, int damagePoints, int healthPoints)
        {
            Name = name;
            DamagePoints = damagePoints;
            HealthPoints = healthPoints;
        }

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Card's name cannot be null or an empty string.");
                }

                name = value;
            }
        }

        public int DamagePoints
        {
            get => damagePoints;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Card's damage points cannot be less than zero.");
                }

                damagePoints = value;
            }
        }

        public int HealthPoints
        {
            get => healthPoints;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Card's HP cannot be less than zero.");
                }

                healthPoints = value;
            }
        }

        public override string ToString()
        {
            return $"Card: {Name} - Damage: {DamagePoints}";
        }
    }
}