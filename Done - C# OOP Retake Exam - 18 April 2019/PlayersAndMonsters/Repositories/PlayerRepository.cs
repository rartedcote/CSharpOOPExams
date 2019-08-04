using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlayersAndMonsters.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        public PlayerRepository()
        {
            Players = new List<IPlayer>();
        }

        public int Count { get => Players.Count; }

        public IReadOnlyCollection<IPlayer> Players { get; private set; }

        public void Add(IPlayer player)
        {
            if (player is null)
            {
                throw new ArgumentException("Player cannot be null");
            }

            else if (Players.Select(x => x.Username).ToList().Contains(player.Username))
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }

            var tempList = Players.ToList();
            tempList.Add(player);
            Players = tempList;
        }

        public IPlayer Find(string username)
        {
            return Players.FirstOrDefault(p => p.Username == username);
        }

        public bool Remove(IPlayer player)
        {
            return Players.ToList().Remove(Find(player.Username));
        }
    }
}