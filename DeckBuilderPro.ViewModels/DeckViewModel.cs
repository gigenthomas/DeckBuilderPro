using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeckBuilderPro.Entity;
using Newtonsoft.Json;

namespace DeckBuilderPro.ViewModels
{
    public class DeckViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public int CardCount { get; set; }
        public int GameId { get; set; }
        public Nullable<int> FormatId { get; set; }
        public ICollection<DeckCardViewModel> CardsInDeck { get; set; }
        public ICollection<CardCountItem> CardCountByCardType { get; set; }

        public DeckCardViewModel AddCard { get; set; }
        //public ICollection<DeckCard> CardsInDeck { get; set; }
        //public Format Format { get; set; }
        //public Game Game { get; set; }
        //public User User { get; set; }
    }
}
