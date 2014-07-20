using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeckBuilderPro.Entity.VsSystem
{
    public class CardText : BaseEntity
    {
        public string RulesText { get; set; }
        public string FlavourText { get; set; }
        public virtual VsSystem_Card VsSystem_Card { get; set; }
    }
}
