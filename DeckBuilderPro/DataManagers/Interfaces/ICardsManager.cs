using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeckBuilderPro.Entity;

namespace DeckBuilderPro.DataManagers.Interfaces
{
    public interface ICardsManager
    {
        Card LookupCard(string cardIdentifier, int gameId);
    }
}