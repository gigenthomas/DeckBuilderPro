using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckBuilderPro.ViewModels.VsSystem
{
    public class VsSystemCardViewModel
    {
        public VsSystemCardViewModel()
        {
            //this.CardText = new List<VsSystemCardText>();
            this.TeamAffiliations = new List<VsSystemTeamAffiliationViewModel>();

        }

        public string Name { get; set; }
        public int CardTypeId { get; set; }
        public string CardIdentifier { get; set; }
        public bool IsReprint { get; set; }
        //public VsSystemCardType CardType { get; set; }
        public string Version { get; set; }
        public int Cost { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public bool HasFlight { get; set; }
        public bool HasRange { get; set; }
        public bool IsOngoing { get; set; }
        public int RarityId { get; set; }
        //public VsSystemCardRarity CardRarity { get; set; }
        //public ICollection<VsSystemCardText> CardText { get; set; }
        public ICollection<VsSystemTeamAffiliationViewModel> TeamAffiliations { get; set; }
        //public ICollection<VsSystemDeckCard> CardsInDeck { get; set; }
        //public ICollection<VsSystemCollectionCard> CardsInCollection { get; set; }
    }
}
