using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeckBuilderPro.Entity
{
    public class CardType
    {
        public CardType()
        {
            this.Cards = new List<Card>();
        }

        public int Id { get; set; }
        public int GameId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
        public virtual Game Game { get; set; }
    }
}
