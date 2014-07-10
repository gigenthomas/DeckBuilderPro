using DeckBuilderPro.DataManager.Interfaces;
using DeckBuilderPro.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enums = DeckBuilderPro.Entity.Enums;

namespace DeckBuilderPro.DataManager
{
    public class DecksManager : IDecksManager
    {
        private readonly IDataManager<DeckCard, Enums.DeckCardEntities> _deckCardDataManager;
        private readonly IDataManager<Deck, Enums.DeckEntities> _deckDataManager;
        private readonly ICardsManager _cardManager;

        public DecksManager(IDataManager<DeckCard, Enums.DeckCardEntities> deckCardDataManager, IDataManager<Deck, Enums.DeckEntities> deckDataManager, ICardsManager cardManager)
        {
            _deckCardDataManager = deckCardDataManager;
            _deckDataManager = deckDataManager;
            _cardManager = cardManager;
        }

        public List<Card> TypeAhead(string name)
        {
            return _cardManager.TypeAheadByName(name, 1);
        }

        public int UpdateDeckCount(int deckId)
        {
            var deck = _deckDataManager.FindById(deckId);
            deck.CardCount = deck.CardsInDeck.Sum(cid => cid.CardCount);
            _deckDataManager.Update(deck);
            return deck.CardCount;
        }

        public bool DeleteCardFromDeck(int deckCardId)
        {
            try
            {
                DeckCard myDCard = _deckCardDataManager.GetAll(new List<Enums.DeckCardEntities> { }).Where(c => c.Id == deckCardId).FirstOrDefault();
                if (myDCard == null)
                {
                }
                else
                {
                    var deck = _deckDataManager.FindById(myDCard.DeckId);
                    if (deck == null)
                    {
                        throw new NullReferenceException("Deck Not Found");
                    }
                    deck.CardCount -= myDCard.CardCount;
                    _deckCardDataManager.DeleteById(deckCardId);
                    _deckDataManager.Update(deck);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        
        public bool UpdateCardInDeck(string cardIdentifier, int deckId, int quantity, int quantityFromCollection)
        {
            try
            {
                var deck = _deckDataManager.FindById(deckId);
                if (deck == null)
                {
                    throw new NullReferenceException("Deck Not Found");
                }

                var card = _cardManager.LookupCard(cardIdentifier, deck.GameId);
                DeckCard myDCard = _deckCardDataManager.GetAll(new List<Enums.DeckCardEntities> { }).Where(c => c.CardId == card.Id && c.DeckId == deckId).FirstOrDefault();
                if (myDCard == null)
                {
                    throw new NullReferenceException("Card Not Found");
                }
                else
                {

                    deck.CardCount -= myDCard.CardCount;
                    myDCard.CardCount = quantity;
                    deck.CardCount += quantity;
                    myDCard.CardsFromCollection = quantityFromCollection;
                    _deckCardDataManager.Update(myDCard);
                    _deckDataManager.Update(deck);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public DeckCard AddCardsToDeck(string cardIdentifier, int deckId, int quantity, int quantityFromCollection)
        {
            try
            {
                var deck = _deckDataManager.FindById(deckId);
                if (deck == null)
                {
                    throw new NullReferenceException("Deck Not Found");
                }

                var card = _cardManager.LookupCard(cardIdentifier, deck.GameId);
                DeckCard myDCard = _deckCardDataManager.GetAll(new List<Enums.DeckCardEntities> { }).Where(c => c.CardId == card.Id && c.DeckId == deckId).FirstOrDefault();
                if (myDCard == null)
                {
                    myDCard = new DeckCard();
                    myDCard.CardId = card.Id;
                    myDCard.DeckId = deckId;
                    myDCard.CardCount = quantity;
                    myDCard.CardsFromCollection = quantityFromCollection;
                    _deckCardDataManager.Create(myDCard);
                    deck.CardCount += quantity;
                    myDCard = _deckCardDataManager.FindById(myDCard.Id);
                    _deckDataManager.Update(deck);
                }
                else
                {
                    myDCard.CardCount += quantity;
                    myDCard.CardsFromCollection += quantityFromCollection;
                    deck.CardCount += quantity;
                    _deckCardDataManager.Update(myDCard);
                    _deckDataManager.Update(deck);
                }
                return myDCard;
            }
            catch (Exception e)
            {
                return null;
            }

        }
    }
}
