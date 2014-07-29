using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeckBuilderPro.Entity.VsSystem
{
    public class VsSystemDeck : BaseEntity
    {
        public VsSystemDeck()
        {
            this.CardsInDeck = new List<VsSystemDeckCard>();
        }

        public string Name { get; set; }
        public int UserId { get; set; }
        public int CardCount { get; set; }
        public Nullable<int> FormatId { get; set; }
        public ICollection<VsSystemDeckCard> CardsInDeck { get; set; }
        public VsSystemFormat Format { get; set; }
        public User User { get; set; }

    }
}
