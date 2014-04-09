using DeckBuilderPro.DataManager.Interfaces;
using DeckBuilderPro.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enums = DeckBuilderPro.Entity.Enums;

namespace DeckBuilderPro.DataManager
{
    public class CollectionsManager : ICollectionsManager
    {
        private readonly IDataManager<CollectionCard, Enums.CollectionCardEntities> _collectionCardDataManager;
        private readonly IDataManager<Collection, Enums.CollectionEntities> _collectionDataManager;
        private readonly ICardsManager _cardManager;

        public CollectionsManager(
            IDataManager<CollectionCard, Enums.CollectionCardEntities> collectionCardDataManager,
            IDataManager<Collection, Enums.CollectionEntities> collectionDataManager,
            ICardsManager cardManager
        )
        {
            _collectionCardDataManager = collectionCardDataManager;
            _collectionDataManager = collectionDataManager;
            _cardManager = cardManager;
        }

        public int CheckCardsOutOfColection(int collectionId, int quantity, string cardIdentifier)
        {
            int cardsCheckedOut = 0;
            try
            {
                var collection = _collectionDataManager.FindById(collectionId);
                var card = _cardManager.LookupCard(cardIdentifier, collection.GameId);

                if (card == null)
                {
                    throw new Exception("Invalid Card");
                }

                CollectionCard myCard = _collectionCardDataManager.GetAll(new List<Enums.CollectionCardEntities> { }).Where(c => c.CardId == card.Id && c.CollectionId == collectionId).FirstOrDefault();
                if ((myCard.CardCount - myCard.CardsInDecks) >= quantity)
                {
                    myCard.CardsInDecks += quantity;
                    cardsCheckedOut = quantity;
                }
                else
                {
                    cardsCheckedOut = (myCard.CardCount - myCard.CardsInDecks);
                    myCard.CardsInDecks += cardsCheckedOut;
                }
                _collectionCardDataManager.Update(myCard);
                return cardsCheckedOut;

            }
            catch (Exception e)
            {
                return cardsCheckedOut;
            }
        }

        public bool AddCardsToCollection(int collectionId, int quantity, string cardIdentifier)
        {
            try
            {
                var collection = _collectionDataManager.FindById(collectionId);
                var card = _cardManager.LookupCard(cardIdentifier, collection.GameId);

                if (card == null)
                {
                    throw new Exception("Invalid Card");
                }

                CollectionCard myCard = _collectionCardDataManager.GetAll(new List<Enums.CollectionCardEntities> { }).Where(c => c.CardId == card.Id && c.CollectionId == collectionId).FirstOrDefault();
                if (myCard == null)
                {
                    myCard = new CollectionCard();
                    myCard.CardId = card.Id;
                    myCard.CollectionId = collectionId;
                    myCard.CardCount = quantity;
                    myCard.CardsInDecks = 0;
                    _collectionCardDataManager.Create(myCard);

                }
                else
                {
                    myCard.CardCount = myCard.CardCount + quantity;
                    _collectionCardDataManager.Update(myCard);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}
