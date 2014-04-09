using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeckBuilderPro.DataManagers.Interfaces;
using DeckBuilderPro.Entity;
using DeckBuilderPro.DataManager.Interfaces;
using Enums = DeckBuilderPro.Entity.Enums;

namespace DeckBuilderPro.DataManagers
{
    //public class DecksManager : IDecksManager
    //{
    //    private readonly IDataManager<DeckCard, Enums.DeckCardEntities> _deckCardDataManager;
    //    private readonly IDataManager<Deck, Enums.DeckEntities> _deckDataManager;
    //    private readonly ICardsManager _cardManager;

    //    public DecksManager(IDataManager<DeckCard, Enums.DeckCardEntities> deckCardDataManager,IDataManager<Deck, Enums.DeckEntities> deckDataManager, ICardsManager cardManager)
    //    {
    //        _deckCardDataManager = deckCardDataManager;
    //        _deckDataManager = deckDataManager;
    //        _cardManager = cardManager;
    //    }


    //    public bool AddCardsToDeck(string cardIdentifier, int deckId, int quantity, int quantityFromCollection)
    //    {
    //        try
    //        {
    //            var deck = _deckDataManager.FindById(deckId);
    //            if(deck == null)
    //            {
    //                throw new NullReferenceException("Deck Not Found");
    //            }

    //            var card = _cardManager.LookupCard(cardIdentifier, deck.GameId);
    //            DeckCard myDCard = _deckCardDataManager.GetAll(new List<Enums.DeckCardEntities> { }).Where(c => c.CardId == card.Id && c.DeckId == deckId).FirstOrDefault();
    //            if (myDCard == null)
    //            {
    //                myDCard = new DeckCard();
    //                myDCard.CardId = card.Id;
    //                myDCard.DeckId = deckId;
    //                myDCard.CardCount = quantity;
    //                myDCard.CardsFromCollection = quantityFromCollection;
    //                _deckCardDataManager.Create(myDCard);
    //                deck.CardCount += quantity;
    //                _deckDataManager.Update(deck);
    //            }
    //            else
    //            {
    //                myDCard.CardCount += quantity;
    //                myDCard.CardsFromCollection += quantityFromCollection;
    //                _deckCardDataManager.Update(myDCard);
    //            }
    //            return true;
    //        }
    //        catch (Exception e)
    //        {
    //            return false;
    //        }

    //    }
    //}
}