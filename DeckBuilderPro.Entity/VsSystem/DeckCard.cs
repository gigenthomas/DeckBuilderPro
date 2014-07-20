using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeckBuilderPro.Entity.VsSystem
{
    public class DeckCard : BaseEntity
    {
        public int CardId { get; set; }
        public int DeckId { get; set; }
        public int CardCount { get; set; }
        public int CardsFromCollection { get; set; }
        public Card Card { get; set; }
        public Deck Deck { get; set; }
    }
}
