using DeckBuilderPro.DataManager.Interfaces;
using DeckBuilderPro.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enums = DeckBuilderPro.Entity.Enums;

namespace DeckBuilderPro.DataManager
{
    public class CardsManager : ICardsManager
    {

        public Card LookupCard(string cardIdentifier, int gameId)
        {
            var cardRepository = new DeckBuilderPro.DataManager.VsSystem_CardsDataManager(new Repository.UnitOfWork(new DeckBuilderPro.Data.DataContext()));
            var card = cardRepository.GetAll(new List<Enums.VsSystem_CardEnities> { }).Where(c => c.CardIdentifier.ToUpper() == cardIdentifier.ToUpper() && c.GameId == gameId).FirstOrDefault();
            if (card == null)
            {
                throw new Exception("Invalid Card");
            }
            return card;
        }

    }
}
