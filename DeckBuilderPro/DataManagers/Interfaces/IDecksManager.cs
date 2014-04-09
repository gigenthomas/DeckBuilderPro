using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeckBuilderPro.DataManagers.Interfaces
{
    public interface IDecksManager
    {
        bool AddCardsToDeck(string cardIdentifier, int deckId, int quantity, int quantityFromColection);
    }
}