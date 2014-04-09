using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeckBuilderPro.ViewModels
{
    public class CardViewModel
    {
        public string Name { get; set; }
        public int CardTypeId { get; set; }
        public int GameId { get; set; }
        public string CardIdentifier { get; set; }
        public bool IsReprint { get; set; }
        public CardTypeViewModel CardType { get; set; }

    }
}
