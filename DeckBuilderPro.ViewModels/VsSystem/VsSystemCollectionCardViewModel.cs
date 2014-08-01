using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckBuilderPro.ViewModels.VsSystem
{
    public class VsSystemCollectionCardViewModel
    {
        public int CardId { get; set; }
        public int CollectionId { get; set; }
        public int CardCount { get; set; }
        public int CardsInDecks { get; set; }
        //public VsSystemCollectionViewModel Collection { get; set; }
        public VsSystemCardViewModel Card { get; set; }
    }
}
