using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRepository;


namespace DeckBuilderPro.Entity
{
    public class Game : BaseEntity
    {
        public Game()
        {
            this.CardRarities = new List<CardRarity>();
            this.Cards = new List<Card>();
            this.CardTypes = new List<CardType>();
            this.Formats = new List<Format>();
            this.GameSets = new List<GameSet>();
        }

        public string Name { get; set; }
        public int ManufacturerId { get; set; }
        public ICollection<CardRarity> CardRarities { get; set; }
        public ICollection<Card> Cards { get; set; }
        public ICollection<CardType> CardTypes { get; set; }
        public ICollection<Format> Formats { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public ICollection<GameSet> GameSets { get; set; }
        public ICollection<Collection> Collections { get; set; }
        public ICollection<Deck> Decks { get; set; }

    }
}
