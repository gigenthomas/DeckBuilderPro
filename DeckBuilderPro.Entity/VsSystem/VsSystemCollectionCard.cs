using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeckBuilderPro.Entity.VsSystem
{
    public class VsSystemCollectionCard : BaseEntity
    {
        public int CardId { get; set; }
        public int CollectionId { get; set; }
        public int CardCount { get; set; }
        public int CardsInDecks { get; set; }
        public VsSystemCollection Collection { get; set; }
        public VsSystemCard Card { get; set; }
    }
}
