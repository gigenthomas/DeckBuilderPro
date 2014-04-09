using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRepository;


namespace DeckBuilderPro.Entity
{
    public class Manufacturer : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Game> Games { get; set; }
    }
}
