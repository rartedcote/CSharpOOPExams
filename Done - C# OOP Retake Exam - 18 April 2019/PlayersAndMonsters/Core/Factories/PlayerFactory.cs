using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PlayersAndMonsters.Core.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            Type typePlayer = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);

            IPlayer player = (IPlayer)Activator.CreateInstance(typePlayer, username);

            return player;
        }
    }
}