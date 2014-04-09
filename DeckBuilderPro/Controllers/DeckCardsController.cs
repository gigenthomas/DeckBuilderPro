using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeckBuilderPro.ViewModels.Interfaces;
using DeckBuilderPro.DataManager.Interfaces;
using DeckBuilderPro.Entity;
using DeckBuilderPro.ViewModels;
using Enums = DeckBuilderPro.Entity.Enums;
using DeckBuilderPro.DataManagers;

namespace DeckBuilderPro.Controllers
{
    public class DeckCardsController : Controller
    {

        private readonly IModelBuilder<DeckCard, DeckCardViewModel> _modelBuilder;
        private readonly IListModelBuilder<DeckCardViewModel> _listModelBuilder;
        private readonly IDataManager<DeckCard, DeckBuilderPro.Entity.Enums.DeckCardEntities> _dataManager;
        private readonly DeckBuilderPro.DataManager.Interfaces.ICollectionsManager _collectionsManager;
        private readonly IDecksManager _decksManager;

        public DeckCardsController(
            IDataManager<DeckCard, Enums.DeckCardEntities> dataManager, IModelBuilder<DeckCard, DeckCardViewModel> modelBuilder, IListModelBuilder<DeckCardViewModel> listModelBulder
            ,ICollectionsManager collectionsManager, IDecksManager decksManager
            )
        {
            _dataManager = dataManager;
            _modelBuilder = modelBuilder;
            _listModelBuilder = listModelBulder;
            _collectionsManager = collectionsManager;
            _decksManager = decksManager;
        }

        public ActionResult AddCards()
        {

            return View(_modelBuilder.CreateFrom(new DeckCard()));
        }

        [HttpPost]
        public ActionResult AddCards(DeckCardViewModel cardsToAdd)
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
            
            _decksManager.AddCardsToDeck(cardsToAdd.CardIdentifier, cardsToAdd.DeckId, cardsToAdd.Quantity, cardsCheckedOutFromCollection);
            return RedirectToAction("AddCards");

        }

        //
        // GET: /DeckCards/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /DeckCards/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /DeckCards/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /DeckCards/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /DeckCards/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /DeckCards/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /DeckCards/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /DeckCards/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
