using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRepository;

namespace DeckBuilderPro.Entity
{
    public class Collection : BaseEntity
    {
        public Collection()
        {
            this.CardsInCollection = new List<CollectionCard>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public int GameId { get; set; }
        public ICollection<CollectionCard> CardsInCollection { get; set; }
        public Game Game { get; set; }
        public User User { get; set; }

    }
}
