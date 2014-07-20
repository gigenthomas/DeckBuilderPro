using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRepository;
using VsSystem = DeckBuilderPro.Entity.VsSystem;

namespace DeckBuilderPro.Entity
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string ZipCode { get; set; }
        public int CountryId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int IsMale { get; set; }
        public virtual ICollection<Collection> Collections { get; set; }
        public ICollection<Deck> Decks { get; set; }
        public virtual ICollection<VsSystem.Collection> VsSystemCollections { get; set; }
        public ICollection<VsSystem.Deck> VsSystemDecks { get; set; }

    }
}
