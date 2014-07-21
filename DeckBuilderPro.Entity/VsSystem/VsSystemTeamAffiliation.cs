using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeckBuilderPro.Entity.VsSystem
{
    public class VsSystemTeamAffiliation : BaseEntity
    {
        public VsSystemTeamAffiliation()
        {
            this.Cards = new List<VsSystemCard>();
        }

        public string Name { get; set; }
        public virtual ICollection<VsSystemCard> Cards { get; set; }
    }
}
