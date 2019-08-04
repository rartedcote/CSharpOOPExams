using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players
{
    public class Beginner : Player
    {
        public Beginner(string username) 
            : base(new CardRepository(), username, 50)
        {
        }
    }
}