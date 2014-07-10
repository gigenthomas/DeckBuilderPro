using DeckBuilderPro.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeckBuilderPro.DataManager.Interfaces
{
    public interface IDecksManager
    {
        DeckCard AddCardsToDeck(string cardIdentifier, int deckId, int quantity, int quantityFromColection);
        bool UpdateCardInDeck(string cardIdentifier, int deckId, int quantity, int quantityFromCollection);
        bool DeleteCardFromDeck(int deckCardId);
        int UpdateDeckCount(int deckId);
        List<Card> TypeAhead(string name);
    }
}
