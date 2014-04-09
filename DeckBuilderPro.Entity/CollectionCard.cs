using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRepository;

namespace DeckBuilderPro.Entity
{
    public class CollectionCard : BaseEntity
    {
        public int CardId { get; set; }
        public int CollectionId { get; set; }
        public int CardCount {get; set;}
        public int CardsInDecks { get; set; }
        public Collection Collection { get; set; }
        public Card Card { get; set; }
    }
}
