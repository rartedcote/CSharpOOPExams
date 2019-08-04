using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using System;
using System.Linq;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }

            if (attackPlayer is Beginner)
            {
                BonusBeginnerStats(attackPlayer);
            }

            if (enemyPlayer is Beginner)
            {
                BonusBeginnerStats(enemyPlayer);
            }

            BonusHealthPoints(attackPlayer);
            BonusHealthPoints(enemyPlayer);

            int attackPlayerDamage = attackPlayer.CardRepository.Cards.ToList().Sum(c => c.DamagePoints);
            int enemyPlayerDamage = enemyPlayer.CardRepository.Cards.ToList().Sum(c => c.DamagePoints);

            while (true)
            {
                enemyPlayer.TakeDamage(attackPlayerDamage);

                if (enemyPlayer.IsDead)
                {
                    break;
                }

                attackPlayer.TakeDamage(enemyPlayerDamage);

                if (attackPlayer.IsDead)
                {
                    break;
                }
            }
        }

        private void BonusHealthPoints(IPlayer attackPlayer)
        {
            foreach (ICard card in attackPlayer.CardRepository.Cards)
            {
                attackPlayer.Health += card.HealthPoints;
            }
        }

        private void BonusBeginnerStats(IPlayer attackPlayer)
        {
            attackPlayer.Health += 40;

            foreach (ICard card in attackPlayer.CardRepository.Cards)
            {
                card.DamagePoints += 30;
            }
        }
    }
}