using DeckBuilderPro.Entity.VsSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enums = DeckBuilderPro.Entity.Enums;

namespace DeckBuilderPro.DataManager.Interfaces.VsSystem
{
    public interface IVsSystemCollectionCardsManager : IDataManager<VsSystemCollectionCard, Enums.VsSystemCollectionCardEntities>
    {
    }
}
