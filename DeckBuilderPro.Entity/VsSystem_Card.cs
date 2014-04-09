using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRepository;

namespace DeckBuilderPro.Entity
{
    public class VsSystem_Card : Card
    {
        public VsSystem_Card()
        {
            this.VsSystem_CardText = new List<VsSystem_CardText>();
            this.VsSystem_TeamAffiliations = new List<VsSystem_TeamAffiliation>();
        }

        public string Version { get; set; }
        public int Cost { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public bool HasFlight { get; set; }
        public bool HasRange { get; set; }
        public bool IsOngoing { get; set; }
        public int RarityId { get; set; }
        public CardRarity CardRarity { get; set; }
        public ICollection<VsSystem_CardText> VsSystem_CardText { get; set; }
        public ICollection<VsSystem_TeamAffiliation> VsSystem_TeamAffiliations { get; set; }

    }
}
