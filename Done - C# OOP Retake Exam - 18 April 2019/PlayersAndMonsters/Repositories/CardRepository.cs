using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Repositories
{
    public class CardRepository : ICardRepository
    {
        public CardRepository()
        {
            Cards = new List<ICard>();
        }

        public int Count { get { return Cards.Count; } }

        public IReadOnlyCollection<ICard> Cards { get; private set; }

        public void Add(ICard card)
        {
            if (card is null)
            {
                throw new ArgumentException("Card cannot be null!");
            }

            else if (Cards.Select(x => x.Name).ToList().Contains(card.Name))
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }

            var tempList = Cards.ToList();
            tempList.Add(card);
            Cards = tempList;
        }

        public ICard Find(string name)
        {
            return Cards.FirstOrDefault(c => c.Name == name);
        }

        public bool Remove(ICard card)
        {
            return Cards.ToList().Remove(Find(card.Name));
        }
    }
}
