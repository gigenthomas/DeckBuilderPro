using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeckBuilderPro.Entity.VsSystem
{
    public class Deck : BaseEntity
    {
        public Deck()
        {
            this.CardsInDeck = new List<DeckCard>();
        }

        public string Name { get; set; }
        public int UserId { get; set; }
        public int CardCount { get; set; }
        public int GameId { get; set; }
        public Nullable<int> FormatId { get; set; }
        public ICollection<DeckCard> CardsInDeck { get; set; }
        public Format Format { get; set; }
        public Game Game { get; set; }
        public User User { get; set; }

    }
}
