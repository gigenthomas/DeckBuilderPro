using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeckBuilderPro.Entity
{
    public class VsSystem_TeamAffiliation
    {
        public VsSystem_TeamAffiliation()
        {
            this.VsSystem_Cards = new List<VsSystem_Card>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<VsSystem_Card> VsSystem_Cards { get; set; }
    }
}
