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
        private readonly IModelBuilder<DeckCard, DeckCardViewModel> _deckCardModelBuild;
        private readonly IDecksManager _deckManager;


        public DecksController(IDataManager<Deck, Enums.DeckEntities> dataManager, 
            IModelBuilder<Deck, DeckViewModel> modelBuilder,
            IModelBuilder<DeckCard, DeckCardViewModel> deckCardModelBuild
            , IListModelBuilder<DeckViewModel> listModelBulder
            , IDecksManager deckManager
            )
        {
            _dataManager = dataManager;
            _modelBuilder = modelBuilder;
            _listModelBuilder = listModelBulder;
            _deckCardModelBuild = deckCardModelBuild;
            _deckManager = deckManager;
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

        public JsonResult UpdateDeckCount(int id)
        {
            return Json(_deckManager.UpdateDeckCount(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult TypeAhead(string search)
        {
            var results = _deckManager.TypeAhead(search);
            return Json(results, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeckList2(int id)
        {
            var deckCard = new DeckCard();
            var model = _deckCardModelBuild.CreateFrom(deckCard);
            ViewBag.Id = id;
            return View(model);
        }


        public ActionResult ListDeck(int id)
        {
            var deck = _dataManager.FindById(id);
            if (deck == null)
            {
                throw new ArgumentNullException("Deck not Found");
            }
            var viewModel = _modelBuilder.CreateFrom(deck);
            var cardTypes = (from cd in viewModel.CardsInDeck select cd.Card.CardType).Distinct();
            viewModel.CardCountByCardType = cardTypes.Select( c => new CardCountItem { CardType = c.Name, CardCount = viewModel.CardsInDeck.Where(e => e.Card.CardTypeId == c.Id).Sum(cd => cd.Quantity)}).ToArray();
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
