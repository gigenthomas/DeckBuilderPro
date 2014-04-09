using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeckBuilderPro.Entity
{
    public class VsSystem_GameSet
    {
        public VsSystem_GameSet()
        {
            this.Cards = new List<VsSystem_Card>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int GameId { get; set; }
        public Nullable<int> NumberOfCards { get; set; }
        public bool HasSetIdentifier { get; set; }
        public string SetIdentifier { get; set; }
        public virtual Game Game { get; set; }
        public virtual ICollection<VsSystem_Card> Cards { get; set; }
    }
}
