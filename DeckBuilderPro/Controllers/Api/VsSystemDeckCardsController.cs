using DeckBuilderPro.DataManager.Interfaces.VsSystem;
using DeckBuilderPro.Entity.VsSystem;
using DeckBuilderPro.ViewModels.Interfaces;
using DeckBuilderPro.ViewModels.VsSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DeckBuilderPro.Controllers.Api
{
    public class VsSystemDeckCardsController : ApiController
    {
        private readonly IModelBuilder<VsSystemDeckCard, VsSystemDeckCardViewModel> _modelBuilder;
        private readonly IVsSystemCollectionsManager _collectionsManager;
        private readonly IVsSystemDeckCardsManager _deckCardsManager;
        private readonly IVsSystemDecksManager _decksManager;

        public VsSystemDeckCardsController(
            IVsSystemDeckCardsManager deckCardManager,
            IVsSystemCollectionsManager collectionsManager,
            IVsSystemDecksManager decksManager,
            IModelBuilder<VsSystemDeckCard, VsSystemDeckCardViewModel> modelBuilder
            )
        {
            _modelBuilder = modelBuilder;
            _collectionsManager = collectionsManager;
            _deckCardsManager = deckCardManager;
            _decksManager = decksManager;
        }

        public VsSystemDeckCardViewModel Post(VsSystemDeckCardViewModel cardsToAdd)
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

        public bool Put(VsSystemDeckCardViewModel updatedDeckCard)
        {
            int cardsCheckedOutFromCollection = 0;
            var quantityToAdd = 0;
            if (updatedDeckCard.OldQuantity != null)
            {
                quantityToAdd = updatedDeckCard.Quantity - updatedDeckCard.OldQuantity;
            }
            else
            {
                quantityToAdd = updatedDeckCard.Quantity;
            }
            if (updatedDeckCard.AddToCollection)
            {
                _collectionsManager.AddCardsToCollection(updatedDeckCard.CollectionId, quantityToAdd, updatedDeckCard.CardIdentifier);
            }
            if (updatedDeckCard.CheckoutFromCollection)
            {
                cardsCheckedOutFromCollection = _collectionsManager.CheckCardsOutOfColection(updatedDeckCard.CollectionId, quantityToAdd, updatedDeckCard.CardIdentifier);
            }

            return _decksManager.UpdateCardInDeck(updatedDeckCard.CardIdentifier, updatedDeckCard.DeckId, updatedDeckCard.Quantity, cardsCheckedOutFromCollection);
        }

    }
}
