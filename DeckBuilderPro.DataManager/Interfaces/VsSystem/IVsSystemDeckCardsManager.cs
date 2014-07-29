using DeckBuilderPro.Entity.VsSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enums = DeckBuilderPro.Entity.Enums;
namespace DeckBuilderPro.DataManager.Interfaces.VsSystem
{
    public interface IVsSystemDeckCardsManager : IDataManager<VsSystemDeckCard, Enums.VsSystemDeckCardEntities>
    {
        IEnumerable<VsSystemDeckCard> GetAll();
    }
}
