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

    public class GamesController : Controller
    {
        private readonly IModelBuilder<Game, GameViewModel> _modelBuilder;
        private readonly IListModelBuilder<GameViewModel> _listModelBuilder;
        private readonly IDataManager<Game, Enums.GameEnities> _dataManager;

        public GamesController(IDataManager<Game, Enums.GameEnities> dataManager, IModelBuilder<Game, GameViewModel> modelBuilder, IListModelBuilder<GameViewModel> listModelBulder)
        {
            _dataManager = dataManager;
            _modelBuilder = modelBuilder;
            _listModelBuilder = listModelBulder;
        }

        //
        // GET: /Games/

        public ActionResult Index(int page = 1)
        {
            //var context = new DeckBuilderPro.Data.DataContext();
            //var unitOfWork = new Repository.UnitOfWork(context);
            //var cards = unitOfWork.Repository<VsSystem_Card>().Query().Get();


            var pager = new DeckBuilderPro.Pager.ListPager();
            pager.CurrentPage = page;
            pager.NumberOfItemsPerPage = 30;
            
            var games = _dataManager.GetPage(pager, new List<Enums.GameEnities> { Enums.GameEnities.Manufacturer });
            return View(_listModelBuilder.CreateFrom(_modelBuilder.CreateFrom(games), pager, _modelBuilder.CreateFrom(new Game())));
            
        }

        //
        // GET: /Games/Details/5

        public ActionResult Details(int id)
        {
            var game = _dataManager.FindById(id);
            return View(_modelBuilder.CreateFrom(game));
        }

        //
        // GET: /Games/Create

        public ActionResult Create()
        {
            return View(_modelBuilder.CreateFrom(new Game()));
        }

        //
        // POST: /Games/Create

        [HttpPost]
        public ActionResult Create(Game newGame)
        {
            try
            {
                // TODO: Add insert logic here
                _dataManager.Create(newGame);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Games/Edit/5

        public ActionResult Edit(int id)
        {
            var game = _dataManager.FindById(id);


            return View(_modelBuilder.CreateFrom(game));
        }

        //
        // POST: /Games/Edit/5

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
        // GET: /Games/Delete/5

        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                _dataManager.DeleteById(id);
            }
            catch
            {
            }
            return RedirectToAction("Index");

        }

        //
        // POST: /Games/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _dataManager.DeleteById(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
