using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeckBuilderPro.Entity;
using DeckBuilderPro.DataManagers.Interfaces;
using Enums = DeckBuilderPro.Entity.Enums;


namespace DeckBuilderPro.DataManagers
{
    //public class CardsManager : ICardsManager
    //{
    //    public Card LookupCard(string cardIdentifier, int gameId)
    //    {
    //        var cardRepository = new DeckBuilderPro.DataManager.VsSystem_CardsDataManager(new Repository.UnitOfWork(new DeckBuilderPro.Data.DataContext()));
    //        var card = cardRepository.GetAll(new List<Enums.VsSystem_CardEnities> { }).Where(c => c.CardIdentifier.ToUpper() == cardIdentifier.ToUpper() && c.GameId == gameId).FirstOrDefault();
    //        if (card == null)
    //        {
    //            throw new Exception("Invalid Card");
    //        }
    //        return card;
    //    }

    //}
}