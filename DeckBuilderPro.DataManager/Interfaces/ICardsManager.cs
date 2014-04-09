using DeckBuilderPro.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeckBuilderPro.DataManager.Interfaces
{
    public interface ICardsManager
    {
        Card LookupCard(string cardIdentifier, int gameId);
    }
}
