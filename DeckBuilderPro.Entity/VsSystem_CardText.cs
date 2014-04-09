using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeckBuilderPro.Entity
{
    public class VsSystem_CardText
    {
        public int CardId { get; set; }
        public string RulesText { get; set; }
        public string FlavourText { get; set; }
        public virtual VsSystem_Card VsSystem_Card { get; set; }
    }
}