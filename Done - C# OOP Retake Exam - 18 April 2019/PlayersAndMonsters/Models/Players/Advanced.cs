using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players
{
    public class Advanced : Player
    {
        public Advanced(string username) 
            : base(new CardRepository(), username, 250)
        {
        }
    }
}