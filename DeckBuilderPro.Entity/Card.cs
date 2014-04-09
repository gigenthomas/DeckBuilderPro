using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRepository;

namespace DeckBuilderPro.Entity
{
    public class Card : BaseEntity
    {
        public Card()
        {
            this.GameSets = new List<GameSet>();
        }

        public string Name { get; set; }
        public int CardTypeId { get; set; }
        public int GameId { get; set; }
        public string CardIdentifier { get; set; }
        public bool IsReprint { get; set; }
        public CardType CardType { get; set; }
        public Game Game { get; set; }
        public ICollection<GameSet> GameSets { get; set; }
        public ICollection<DeckCard> CardsInDeck { get; set; }
        public ICollection<CollectionCard> CardsInCollection { get; set; }
    }
}
