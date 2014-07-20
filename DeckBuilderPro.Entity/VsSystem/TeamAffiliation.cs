using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeckBuilderPro.Entity.VsSystem
{
    public class TeamAffiliation : BaseEntity
    {
        public TeamAffiliation()
        {
            this.Cards = new List<Card>();
        }

        public string Name { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
    }
}
