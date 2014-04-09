using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeckBuilderPro.ViewModels
{
    public class DeckCardViewModel
    {
        public int Id { get; set; }
        public int DeckId { get; set; }
        public int CardId { get; set; }
        public string CardIdentifier { get; set; }
        public bool CheckoutFromCollection { get; set; }
        public bool AddToCollection { get; set; }
        public int Quantity { get; set; }
        public int QuantityFromCollection { get; set; }
        public int CollectionId { get; set; }
        public CardViewModel Card { get; set; }
        public IEnumerable<DropDownListItemViewModel> Decks { get; set; }
        public IEnumerable<DropDownListItemViewModel> Collections { get; set; }


    }
}
