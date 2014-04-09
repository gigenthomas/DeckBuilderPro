using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeckBuilderPro.Entity;
using DeckBuilderPro.ViewModels.Interfaces;
using DeckBuilderPro.DataManager.Interfaces;
using Enums = DeckBuilderPro.Entity.Enums;
using DeckBuilderPro.ViewModels;
using WebMatrix.WebData;

namespace DeckBuilderPro.Controllers
{
    public class CollectionsController : Controller
    {
        private readonly IModelBuilder<Collection, CollectionViewModel> _modelBuilder;
        private readonly IListModelBuilder<CollectionViewModel> _listModelBuilder;
        private readonly IDataManager<Collection, Enums.CollectionEntities> _dataManager;


        public CollectionsController(IDataManager<Collection, Enums.CollectionEntities> dataManager, IModelBuilder<Collection, CollectionViewModel> modelBuilder, IListModelBuilder<CollectionViewModel> listModelBulder)
        {
            _dataManager = dataManager;
            _modelBuilder = modelBuilder;
            _listModelBuilder = listModelBulder;
        }
        //
        // GET: /Collections/

        public ActionResult Index(int page = 1)
        {
            var pager = new DeckBuilderPro.Pager.ListPager();
            pager.CurrentPage = page;
            pager.NumberOfItemsPerPage = 30;
            var collections = _dataManager.GetPage(pager);
            return View(_listModelBuilder.CreateFrom(_modelBuilder.CreateFrom(collections), pager, _modelBuilder.CreateFrom(new Collection())));
        }

        public ActionResult ListCollection(int id)
        {
            var collection = _dataManager.FindById(id);
            if (collection == null)
            {
                throw new ArgumentNullException("Collection not Found");
            }
            var viewModel = _modelBuilder.CreateFrom(collection);
            return View(viewModel);
        }


        //
        // GET: /Collections/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Collections/Create

        public ActionResult Create()
        {
            
            return View(_modelBuilder.CreateFrom(new Collection()));
        }

        //
        // POST: /Collections/Create

        [HttpPost]
        public ActionResult Create(Collection collection)
        {
            try
            {
                // TODO: Add insert logic here
                collection.UserId = WebSecurity.GetUserId(User.Identity.Name);
                _dataManager.Create(collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Collections/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Collections/Edit/5

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
        // GET: /Collections/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Collections/Delete/5

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
