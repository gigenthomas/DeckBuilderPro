using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeckBuilderPro.Entity.VsSystem
{
    public class VsSystemDeckCard : BaseEntity
    {
        public int CardId { get; set; }
        public int DeckId { get; set; }
        public int CardCount { get; set; }
        public int CardsFromCollection { get; set; }
        public VsSystemCard Card { get; set; }
        public VsSystemDeck Deck { get; set; }
    }
}
