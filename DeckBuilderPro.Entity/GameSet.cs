using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeckBuilderPro.Entity
{
    public class GameSet
    {
        public GameSet()
        {
            this.Cards = new List<Card>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int GameId { get; set; }
        public Nullable<int> NumberOfCards { get; set; }
        public bool HasSetIdentifier { get; set; }
        public string SetIdentifier { get; set; }
        public virtual Game Game { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
    }
}
