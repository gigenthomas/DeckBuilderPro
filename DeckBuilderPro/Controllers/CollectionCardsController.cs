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
using WebMatrix.WebData;
using DeckBuilderPro.DataManagers;
using DeckBuilderPro.DataManager.Interfaces;

namespace DeckBuilderPro.Controllers
{
    public class CollectionCardsController : Controller
    {
        private readonly IModelBuilder<CollectionCard, CollectionCardViewModel> _modelBuilder;
        private readonly IListModelBuilder<CollectionCardViewModel> _listModelBuilder;
        private readonly ICollectionsManager _collectionsManager;

        public CollectionCardsController(
            IModelBuilder<CollectionCard, CollectionCardViewModel> modelBuilder, IListModelBuilder<CollectionCardViewModel> listModelBulder,
            ICollectionsManager collectionsManager
            )
        {
            _modelBuilder = modelBuilder;
            _listModelBuilder = listModelBulder;
            _collectionsManager = collectionsManager;
        }

        public ActionResult AddCards()
        {
            return View(_modelBuilder.CreateFrom(new CollectionCard()));
        }

        [HttpPost]
        public ActionResult AddCards(CollectionCardViewModel newCard)
        {
            _collectionsManager.AddCardsToCollection(newCard.CollectionId, newCard.Quantity, newCard.CardIdentifier);
            return RedirectToAction("AddCards");
        }


        //
        // GET: /CollectionCards/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /CollectionCards/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /CollectionCards/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CollectionCards/Create

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
        // GET: /CollectionCards/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /CollectionCards/Edit/5

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
        // GET: /CollectionCards/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /CollectionCards/Delete/5

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
