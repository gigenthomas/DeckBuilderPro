using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckBuilderPro.ViewModels.VsSystem
{
    public class VsSystemDeckCardViewModel
    {
        public int Id { get; set; }
        public int DeckId { get; set; }
        public int CardId { get; set; }
        public string CardIdentifier { get; set; }
        public bool CheckoutFromCollection { get; set; }
        public bool AddToCollection { get; set; }
        public int Quantity { get; set; }
        public int OldQuantity { get; set; }
        public int QuantityFromCollection { get; set; }
        public int CollectionId { get; set; }
        public VsSystemCardViewModel Card { get; set; }
        
    }
}
