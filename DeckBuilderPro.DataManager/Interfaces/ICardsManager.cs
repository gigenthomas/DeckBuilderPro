using DeckBuilderPro.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enums = DeckBuilderPro.Entity.Enums;

namespace DeckBuilderPro.DataManager.Interfaces
{
    public interface ICardsManager : IDataManager<Card, Enums.CardEntities>
    {
        Card LookupCard(string cardIdentifier, int gameId);
        List<Card> TypeAheadByName(string name, int gameId);
    }
}
