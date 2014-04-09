using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeckBuilderPro.Entity
{
    public class CardRarity
    {
        public CardRarity()
        {
            this.VsSystem_Cards = new List<VsSystem_Card>();
        }

        public int Id { get; set; }
        public int GameId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual Game Game { get; set; }
        public virtual ICollection<VsSystem_Card> VsSystem_Cards { get; set; }
    }
}
