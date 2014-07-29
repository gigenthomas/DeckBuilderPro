using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckBuilderPro.ViewModels.VsSystem
{
    public class VsSystemCollectionViewModel
    {
        public VsSystemCollectionViewModel()
        {
            this.CardsInCollection = new List<VsSystemCollectionCardViewModel>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public ICollection<VsSystemCollectionCardViewModel> CardsInCollection { get; set; }
        //public User User { get; set; }
    }
}
