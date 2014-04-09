using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeckBuilderPro.ViewModels
{
    public class CollectionCardViewModel
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public string CardIdentifier { get; set; }
        public int CollectionId {get; set;}
        public int Quantity { get; set; }

        public IEnumerable<DropDownListItemViewModel> Games { get; set; }
        public IEnumerable<DropDownListItemViewModel> Collections { get; set; }
    }
}
