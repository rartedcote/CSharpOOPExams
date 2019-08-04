using PlayersAndMonsters.Models.Cards.Contracts;

namespace PlayersAndMonsters.Models.Cards
{
    public class MagicCard : Card
    {
        public MagicCard(string name) 
            : base(name, 5, 80)
        {
        }
    }
}
