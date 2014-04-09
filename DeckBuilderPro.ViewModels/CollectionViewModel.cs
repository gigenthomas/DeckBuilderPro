using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeckBuilderPro.Entity;

namespace DeckBuilderPro.ViewModels
{
    public class CollectionViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public int GameId { get; set; }
        public ICollection<CollectionCard> CardsInCollection { get; set; }
        //public GameViewModel Game { get; set; }
        //public User User { get; set; }
        public IEnumerable<DropDownListItemViewModel> Games { get; set; }
    }
}
