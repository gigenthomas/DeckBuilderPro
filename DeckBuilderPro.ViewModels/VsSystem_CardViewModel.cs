using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeckBuilderPro.Entity;
using System.ComponentModel;

namespace DeckBuilderPro.ViewModels
{
    public class VsSystem_CardViewModel
    {
        public VsSystem_CardViewModel()
        {
            this.GameSets = new List<GameSet>();
            this.VsSystem_CardText = new List<VsSystem_CardText>();
            this.VsSystem_TeamAffiliations = new List<VsSystem_TeamAffiliation>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        [DisplayName("Card Type")]
        public int CardTypeId { get; set; }

        public int GameId { get; set; }

        [DisplayName("Card Identifier")]
        public string CardIdentifier { get; set; }

        [DisplayName("Reprinted")]
        public bool IsReprint { get; set; }


        public string Version { get; set; }
        public int Cost { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }

        [DisplayName("Flight")]
        public bool HasFlight { get; set; }

        [DisplayName("Range")]
        public bool HasRange { get; set; }

        [DisplayName("Ongoing")]
        public bool IsOngoing { get; set; }

        [DisplayName("Rarity")]
        public int RarityId { get; set; }

        public virtual Game Game { get; set; }
        public virtual ICollection<GameSet> GameSets { get; set; }
        public virtual CardRarity CardRarity { get; set; }
        public CardType CardType { get; set; }
        public virtual ICollection<VsSystem_CardText> VsSystem_CardText { get; set; }
        public virtual ICollection<VsSystem_TeamAffiliation> VsSystem_TeamAffiliations { get; set; }
    }
}
