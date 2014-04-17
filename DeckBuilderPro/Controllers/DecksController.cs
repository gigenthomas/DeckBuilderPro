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

namespace DeckBuilderPro.Controllers
{
    [Authorize]
    public class DecksController : Controller
    {
        //
        // GET: /Decks/

        private readonly IModelBuilder<Deck, DeckViewModel> _modelBuilder;
        private readonly IListModelBuilder<DeckViewModel> _listModelBuilder;
        private readonly IDataManager<Deck, DeckBuilderPro.Entity.Enums.DeckEntities> _dataManager;

        public DecksController(IDataManager<Deck, Enums.DeckEntities> dataManager, 
            IModelBuilder<Deck, DeckViewModel> modelBuilder
            , IListModelBuilder<DeckViewModel> listModelBulder
            )
        {
            _dataManager = dataManager;
            _modelBuilder = modelBuilder;
            _listModelBuilder = listModelBulder;
        }

        public ActionResult Index(int page = 1)
        {
            var decks = _dataManager.GetAll();
            var pager = new DeckBuilderPro.Pager.ListPager();
            pager.CurrentPage = page;
            pager.NumberOfItemsPerPage = 30;
            return View(_listModelBuilder.CreateFrom(_modelBuilder.CreateFrom(decks), pager, _modelBuilder.CreateFrom(new Deck())));
        }

        public ActionResult Index2()
        {
            return View();
        }

        public ActionResult ListDeck(int id)
        {
            var deck = _dataManager.FindById(id);
            if (deck == null)
            {
                throw new ArgumentNullException("Deck not Found");
            }
            var viewModel = _modelBuilder.CreateFrom(deck);
            return View(viewModel);
        }

        //
        // GET: /Decks/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Decks/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Decks/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                //// TODO: Add insert logic here
                //var contex = new DataContext();
                //var uof = new UnitOfWork(contex);
                //var deck = new Deck { Name = "Lost Spider Clones", GameId = 1, UserId = WebSecurity.GetUserId(User.Identity.Name) };
                ////uof.Repository<Deck>().Insert(deck);
                ////uof.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult AddCards()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCards(FormCollection collection)
        {
            return View();
        }


        //
        // GET: /Decks/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Decks/Edit/5

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
        // GET: /Decks/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Decks/Delete/5

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
