using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckBuilderPro.ViewModels.VsSystem
{
    public class VsSystemDeckViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public int CardCount { get; set; }
        public Nullable<int> FormatId { get; set; }
        public ICollection<VsSystemDeckCardViewModel> CardsInDeck { get; set; }
        public ICollection<CardCountItem> CardCountByCardType { get; set; }

        public DeckCardViewModel AddCard { get; set; }
    }
}
