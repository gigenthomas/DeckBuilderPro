using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeckBuilderPro.Entity.VsSystem
{
    public class Card : BaseEntity
    {
        public Card()
        {
            this.CardText = new List<CardText>();
            this.TeamAffiliations = new List<TeamAffiliation>();

        }

        public string Name { get; set; }
        public int CardTypeId { get; set; }
        public int GameId { get; set; }
        public string CardIdentifier { get; set; }
        public bool IsReprint { get; set; }
        public CardType CardType { get; set; }
        public string Version { get; set; }
        public int Cost { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public bool HasFlight { get; set; }
        public bool HasRange { get; set; }
        public bool IsOngoing { get; set; }
        public int RarityId { get; set; }
        public CardRarity CardRarity { get; set; }
        public ICollection<CardText> CardText { get; set; }
        public ICollection<TeamAffiliation> TeamAffiliations { get; set; }
        public ICollection<DeckCard> CardsInDeck { get; set; }
        public ICollection<CollectionCard> CardsInCollection { get; set; }

    }
}
