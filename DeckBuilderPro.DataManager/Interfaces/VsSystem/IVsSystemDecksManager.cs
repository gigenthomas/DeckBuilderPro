using DeckBuilderPro.Entity.VsSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enums = DeckBuilderPro.Entity.Enums;

namespace DeckBuilderPro.DataManager.Interfaces.VsSystem
{
    public interface IVsSystemDecksManager : IDataManager<VsSystemDeck, Enums.VsSystemDeckEntities>
    {
        VsSystemDeckCard AddCardsToDeck(string cardIdentifier, int deckId, int quantity, int quantityFromCollection);
        bool UpdateCardInDeck(string cardIdentifier, int deckId, int quantity, int quantityFromCollection);
        bool DeleteCardFromDeck(int deckCardId);
        int UpdateDeckCount(int deckId);
        IEnumerable<VsSystemCard> TypeAhead(string name);
        IEnumerable<VsSystemDeck> GetAll();
    }
}
