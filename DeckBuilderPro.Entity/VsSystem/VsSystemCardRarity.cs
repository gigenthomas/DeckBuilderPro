using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeckBuilderPro.Entity.VsSystem
{
    public class VsSystemCardRarity : BaseEntity
    {
        public VsSystemCardRarity()
        {
            this.Cards = new List<VsSystemCard>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<VsSystemCard> Cards { get; set; }
    }
}
