using DeckBuilderPro.Entity;
using DeckBuilderPro.ViewModels;
using DeckBuilderPro.ViewModels.Interfaces;
using DeckBuilderPro.DataManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Enums = DeckBuilderPro.Entity.Enums;


namespace DeckBuilderPro.Controllers.Api
{
    public class DeckCardsController : ApiController
    {
        private readonly IModelBuilder<DeckCard, DeckCardViewModel> _modelBuilder;
        private readonly DeckBuilderPro.DataManager.Interfaces.ICollectionsManager _collectionsManager;
        private readonly IListModelBuilder<DeckCardViewModel> _listModelBuilder;
        private readonly IDataManager<DeckCard, DeckBuilderPro.Entity.Enums.DeckCardEntities> _dataManager;
        private readonly IDecksManager _decksManager;


        public DeckCardsController(
            IDataManager<DeckCard, Enums.DeckCardEntities> dataManager, IModelBuilder<DeckCard, DeckCardViewModel> modelBuilder, IListModelBuilder<DeckCardViewModel> listModelBulder
            , ICollectionsManager collectionsManager, IDecksManager decksManager
            )
        {
            _dataManager = dataManager;
            _modelBuilder = modelBuilder;
            _listModelBuilder = listModelBulder;
            _collectionsManager = collectionsManager;
            _decksManager = decksManager;
        }

        public DeckCardViewModel Post(DeckCardViewModel cardsToAdd)
        {
            int cardsCheckedOutFromCollection = 0;
            if (cardsToAdd.AddToCollection)
            {
                _collectionsManager.AddCardsToCollection(cardsToAdd.CollectionId, cardsToAdd.Quantity, cardsToAdd.CardIdentifier);
            }
            if (cardsToAdd.CheckoutFromCollection)
            {
                cardsCheckedOutFromCollection = _collectionsManager.CheckCardsOutOfColection(cardsToAdd.CollectionId, cardsToAdd.Quantity, cardsToAdd.CardIdentifier);
            }

            var deckCard = _decksManager.AddCardsToDeck(cardsToAdd.CardIdentifier, cardsToAdd.DeckId, cardsToAdd.Quantity, cardsCheckedOutFromCollection);
            var viewModel = _modelBuilder.CreateFrom(deckCard);
            return viewModel;
        }

        // DELETE api/decks/5
        public bool Delete(int id)
        {
            //return true;
            return _decksManager.DeleteCardFromDeck(id);
        }

        public bool Put(DeckCardViewModel updatedDeckCard)
        {
            int cardsCheckedOutFromCollection = 0;
            var quantityToAdd = 0;
            quantityToAdd = updatedDeckCard.Quantity - updatedDeckCard.OldQuantity;
            //if (updatedDeckCard.OldQuantity != null)
            //{
            //    quantityToAdd = updatedDeckCard.Quantity - updatedDeckCard.OldQuantity;
            //}
            //else
            //{
            //    quantityToAdd = updatedDeckCard.Quantity;
            //}
            if (updatedDeckCard.AddToCollection)
            {
                if(quantityToAdd > 0)
                {
                    _collectionsManager.AddCardsToCollection(updatedDeckCard.CollectionId, quantityToAdd, updatedDeckCard.CardIdentifier);
                }
            }
            if (updatedDeckCard.CheckoutFromCollection)
            {
                cardsCheckedOutFromCollection = _collectionsManager.CheckCardsOutOfColection(updatedDeckCard.CollectionId, quantityToAdd, updatedDeckCard.CardIdentifier);
            }

            return _decksManager.UpdateCardInDeck(updatedDeckCard.CardIdentifier, updatedDeckCard.DeckId, updatedDeckCard.Quantity, cardsCheckedOutFromCollection);
        }

    }
}
