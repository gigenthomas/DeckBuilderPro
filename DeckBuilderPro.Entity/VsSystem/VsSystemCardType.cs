using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeckBuilderPro.Entity.VsSystem
{
    public class VsSystemCardType : BaseEntity
    {
        public VsSystemCardType()
        {
            this.Cards = new List<VsSystemCard>();
        }

        public string Name { get; set; }
        public ICollection<VsSystemCard> Cards { get; set; }
    }
}
