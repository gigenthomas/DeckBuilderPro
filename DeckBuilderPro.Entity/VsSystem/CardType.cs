using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeckBuilderPro.Entity.VsSystem
{
    public class CardType : BaseEntity
    {
        public CardType()
        {
            this.Cards = new List<Card>();
        }

        public string Name { get; set; }
        public ICollection<Card> Cards { get; set; }
    }
}
