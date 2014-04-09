using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeckBuilderPro.DataManagers.Interfaces
{
    public interface ICollectionsManager
    {
        bool AddCardsToCollection(int collectionId, int quantity, string cardIdentifier);
        int CheckCardsOutOfColection(int collectionId, int quantity, string cardIdentifier);
    }
}