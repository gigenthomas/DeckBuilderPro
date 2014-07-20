using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeckBuilderPro.Entity.VsSystem
{
    public class Collection : BaseEntity
    {
        public Collection()
        {
            this.CardsInCollection = new List<CollectionCard>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public ICollection<CollectionCard> CardsInCollection { get; set; }
        public User User { get; set; }

    }
}
