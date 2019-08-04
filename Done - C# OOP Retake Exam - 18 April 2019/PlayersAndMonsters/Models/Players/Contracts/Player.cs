using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Text;

namespace PlayersAndMonsters.Models.Players.Contracts
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;

        public Player(ICardRepository cardRepository, string username, int health)
        {
            CardRepository = cardRepository;
            Username = username;
            Health = health;
        }

        public ICardRepository CardRepository { get; private set; }

        public string Username
        {
            get => username;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Player's username cannot be null or an empty string.");
                }

                username = value;
            }
        }

        public int Health
        {
            get => health;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player's health bonus cannot be less than zero.");
                }

                health = value;
            }
        }

        public bool IsDead { get => Health == 0; }

        public void TakeDamage(int damagePoints)
        {
            if (damagePoints < 0)
            {
                throw new ArgumentException("Damage points cannot be less than zero.");
            }

            if (damagePoints >= Health)
            {
                Health = 0;
            }

            else
            {
                Health -= damagePoints;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Username: {Username} - Health: {Health} - Cards {CardRepository.Count}");

            foreach (ICard card in CardRepository.Cards)
            {
                sb.AppendLine(card.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}