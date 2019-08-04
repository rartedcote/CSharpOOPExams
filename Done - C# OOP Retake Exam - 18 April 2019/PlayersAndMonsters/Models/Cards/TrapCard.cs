using PlayersAndMonsters.Models.Cards.Contracts;

namespace PlayersAndMonsters.Models.Cards
{
    public class TrapCard : Card
    {
        public TrapCard(string name) 
            : base(name, 120, 5)
        {
        }
    }
}
