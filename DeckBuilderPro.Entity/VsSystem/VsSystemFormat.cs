using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeckBuilderPro.Entity.VsSystem
{
    public class VsSystemFormat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
        public ICollection<VsSystemDeck> Decks { get; set; }
    }
}
