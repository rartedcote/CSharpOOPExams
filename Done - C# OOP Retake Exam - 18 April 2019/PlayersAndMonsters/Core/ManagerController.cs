namespace PlayersAndMonsters.Core
{
    using System;
    using System.Text;
    using Contracts;
    using PlayersAndMonsters.Core.Factories;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories;

    public class ManagerController : IManagerController
    {
        private BattleField battleField = new BattleField();

        private CardRepository cardRepository = new CardRepository();
        private PlayerRepository playerRepository = new PlayerRepository();

        private PlayerFactory playerFactory = new PlayerFactory();
        private CardFactory cardFactory = new CardFactory();

        public ManagerController()
        {
        }

        public string AddPlayer(string type, string username)
        {
            playerRepository.Add(playerFactory.CreatePlayer(type, username));

            return $"Successfully added player of type {type} with username: {username}";
        }

        public string AddCard(string type, string name)
        {
            cardRepository.Add(cardFactory.CreateCard(type, name));

            return $"Successfully added card of type {type}Card with name: {name}";
        }

        public string AddPlayerCard(string username, string cardName)
        {
            IPlayer player = playerRepository.Find(username);
            ICard card = cardRepository.Find(cardName);

            player.CardRepository.Add(card);

            return $"Successfully added card: {cardName} to user: {username}";
        }

        public string Fight(string attackUser, string enemyUser)
        {
            IPlayer attackPlayer = playerRepository.Find(attackUser);
            IPlayer enemyPlayer = playerRepository.Find(enemyUser);

            battleField.Fight(attackPlayer, enemyPlayer);

            return $"Attack user health {attackPlayer.Health} - Enemy user health {enemyPlayer.Health}";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var person in playerRepository.Players)
            {
                sb.AppendLine(person.ToString());
                sb.AppendLine("###");
            }

            return sb.ToString().Trim();
        }
    }
}