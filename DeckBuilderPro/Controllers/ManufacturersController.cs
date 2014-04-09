using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IRepository;
using DeckBuilderPro.Entity;
using DeckBuilderPro.DataManager.Interfaces;
using DeckBuilderPro.ViewModels;
using DeckBuilderPro.ViewModels.Interfaces;
using Enums = DeckBuilderPro.Entity.Enums;

namespace DeckBuilderPro.Controllers
{
    public class ManufacturersController : Controller
    {
        private readonly IModelBuilder<Manufacturer, ManufacturerViewModel> _modelBuilder;
        private readonly IListModelBuilder<ManufacturerViewModel> _listModelBuilder;
        private readonly IDataManager<Manufacturer, Enums.ManufactuerEnities> _dataManager;

        public ManufacturersController(IDataManager<Manufacturer, Enums.ManufactuerEnities> dataManager, IModelBuilder<Manufacturer, ManufacturerViewModel> modelBuilder, IListModelBuilder<ManufacturerViewModel> listModelBulder)
        {
            _dataManager = dataManager;
            _modelBuilder = modelBuilder;
            _listModelBuilder = listModelBulder;
        }

        //
        // GET: /Manufacturers/

        public ActionResult Index()
        {
            var manufacturers = _dataManager.GetAll();
            
            return View(_listModelBuilder.CreateFrom(_modelBuilder.CreateFrom(manufacturers), new DeckBuilderPro.Pager.ListPager(), _modelBuilder.CreateFrom(new Manufacturer())));
        }

        //
        // GET: /Manufacturers/Details/5

        public ActionResult Details(int id)
        {
            var manufacturer = _dataManager.FindById(id);
            return View(_modelBuilder.CreateFrom(manufacturer));
        }

        //
        // GET: /Manufacturers/Create

        public ActionResult Create()
        {
            return View(_modelBuilder.CreateFrom(new Manufacturer()));
        }

        //
        // POST: /Manufacturers/Create

        [HttpPost]
        public ActionResult Create(Manufacturer newManufacturer)
        {
            try
            {
                // TODO: Add insert logic here
                _dataManager.Create(newManufacturer);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Manufacturers/Edit/5

        public ActionResult Edit(int id)
        {
            var manufacturer = _dataManager.FindById(id);
            return View(_modelBuilder.CreateFrom(manufacturer));
        }

        //
        // POST: /Manufacturers/Edit/5

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
        // GET: /Manufacturers/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Manufacturers/Delete/5

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
