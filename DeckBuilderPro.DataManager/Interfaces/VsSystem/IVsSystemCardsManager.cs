using DeckBuilderPro.Entity.VsSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeckBuilderPro.DataManager.Interfaces.VsSystem
{
    public interface IVsSystemCardsManager
    {
        VsSystemCard LookupCard(string cardIdentifier);
        ICollection<VsSystemCard> TypeAheadByName(string name);
    }
}
