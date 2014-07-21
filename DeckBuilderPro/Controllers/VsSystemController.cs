using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeckBuilderPro.Entity;
using DeckBuilderPro.ViewModels;
using DeckBuilderPro.ViewModels.Interfaces;
using DeckBuilderPro.DataManager.Interfaces;
using Enums = DeckBuilderPro.Entity.Enums;
using DeckBuilderPro.ViewModels.VsSystem;
using DeckBuilderPro.Entity.VsSystem;
using DeckBuilderPro.ViewModels.ViewModelsBuilders.VsSystem;
namespace DeckBuilderPro.Controllers
{
    public class VsSystemController : Controller
    {
        private readonly IModelBuilder<VsSystem_Card, VsSystem_CardViewModel> _modelBuilder;
        private readonly IListModelBuilder<VsSystem_CardViewModel> _listModelBuilder;
        private readonly IDataManager<VsSystem_Card, Enums.VsSystem_CardEnities> _dataManager;
        private readonly DeckBuilderPro.DataManager.Interfaces.VsSystem.ICardsManager _newDataManager;
        private readonly IModelBuilder<VsSystemCard, VsSystemCardViewModel> _VsSystemCardModelBuilder;
        

        public VsSystemController(IDataManager<VsSystem_Card, Enums.VsSystem_CardEnities> dataManager, IModelBuilder<VsSystem_Card, VsSystem_CardViewModel> modelBuilder, IListModelBuilder<VsSystem_CardViewModel> listModelBulder,
            DeckBuilderPro.DataManager.Interfaces.VsSystem.ICardsManager newDataManager, IModelBuilder<VsSystemCard, VsSystemCardViewModel> vsSystemCardModelBuilder
            )
        {
            _dataManager = dataManager;
            _modelBuilder = modelBuilder;
            _listModelBuilder = listModelBulder;
            _newDataManager = newDataManager;
            _VsSystemCardModelBuilder = vsSystemCardModelBuilder;
        }
        //
        // GET: /VsSystem/
        [Authorize]
        public ActionResult Index(int page = 1)
        {
            var pager = new DeckBuilderPro.Pager.ListPager();
            pager.CurrentPage = page   ;
            pager.NumberOfItemsPerPage = 30;
            var cards = _dataManager.GetPage(pager, new List<Enums.VsSystem_CardEnities> { Enums.VsSystem_CardEnities.CardRarity, Enums.VsSystem_CardEnities.CardType });
            return View(_listModelBuilder.CreateFrom(_modelBuilder.CreateFrom(cards), pager, _modelBuilder.CreateFrom(new VsSystem_Card())));
        }

        //
        // GET: /VsSystem/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /VsSystem/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /VsSystem/Create

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
        // GET: /VsSystem/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /VsSystem/Edit/5

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
        // GET: /VsSystem/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /VsSystem/Delete/5

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

        public JsonResult TypeAhead(string search)
        {
            var results =  _newDataManager.TypeAheadByName(search);
            var modelResults = _VsSystemCardModelBuilder.CreateFrom(results);
            return Json(modelResults, JsonRequestBehavior.AllowGet);
        }

    }
}
