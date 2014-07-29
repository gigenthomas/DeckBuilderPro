using DeckBuilderPro.Entity.VsSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enums = DeckBuilderPro.Entity.Enums;

namespace DeckBuilderPro.DataManager.Interfaces.VsSystem
{
    public interface IVsSystemCollectionsManager : IDataManager<VsSystemCollection, Enums.VsSystemCollectionEntities>
    {
        bool AddCardsToCollection(int collectionId, int quantity, string cardIdentifier);
        int CheckCardsOutOfColection(int collectionId, int quantity, string cardIdentifier);
    }
}
