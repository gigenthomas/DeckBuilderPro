using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeckBuilderPro.Entity.VsSystem
{
    public class VsSystemCollection : BaseEntity
    {
        public VsSystemCollection()
        {
            this.CardsInCollection = new List<VsSystemCollectionCard>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public ICollection<VsSystemCollectionCard> CardsInCollection { get; set; }
        public User User { get; set; }

    }
}
