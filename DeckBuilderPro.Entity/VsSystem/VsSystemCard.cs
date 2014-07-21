using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeckBuilderPro.Entity.VsSystem
{
    public class VsSystemCard : BaseEntity
    {
        public VsSystemCard()
        {
            this.CardText = new List<VsSystemCardText>();
            this.TeamAffiliations = new List<VsSystemTeamAffiliation>();

        }

        public string Name { get; set; }
        public int CardTypeId { get; set; }
        public string CardIdentifier { get; set; }
        public bool IsReprint { get; set; }
        public VsSystemCardType CardType { get; set; }
        public string Version { get; set; }
        public int Cost { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public bool HasFlight { get; set; }
        public bool HasRange { get; set; }
        public bool IsOngoing { get; set; }
        public int RarityId { get; set; }
        public VsSystemCardRarity CardRarity { get; set; }
        public ICollection<VsSystemCardText> CardText { get; set; }
        public ICollection<VsSystemTeamAffiliation> TeamAffiliations { get; set; }
        public ICollection<VsSystemDeckCard> CardsInDeck { get; set; }
        public ICollection<VsSystemCollectionCard> CardsInCollection { get; set; }

    }
}
