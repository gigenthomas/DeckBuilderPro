using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using DeckBuilderPro.ViewModels;
using DeckBuilderPro.ViewModels.Interfaces;
using DeckBuilderPro.DataManager.Interfaces;
using DeckBuilderPro.Entity;
using Enums = DeckBuilderPro.Entity.Enums;
using WebMatrix.WebData;


namespace DeckBuilderPro.Controllers.Api
{
    public class DecksController : ApiController
    {
        private IModelBuilder<Deck, DeckViewModel> _modelBuilder;
        private IListModelBuilder<DeckViewModel> _listModelBuilder;
        private IDataManager<Deck, DeckBuilderPro.Entity.Enums.DeckEntities> _dataManager;
        
        public DecksController(IDataManager<Deck, Enums.DeckEntities> dataManager, IModelBuilder<Deck, DeckViewModel> modelBuilder, IListModelBuilder<DeckViewModel> listModelBulder)
        {
            _dataManager = dataManager;
            _modelBuilder = modelBuilder;
            _listModelBuilder = listModelBulder;

        }
        // GET api/decks
        public IEnumerable<DeckViewModel> Get()
        {
            var decks = _dataManager.GetAll();
            if (decks == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return _modelBuilder.CreateFrom(decks);
        }

        // GET api/decks/5
        public DeckViewModel Get(int id)
        {

            var deck = _dataManager.FindById(id);
            if (deck == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            var viewModel = _modelBuilder.CreateFrom(deck);
            return viewModel;

        }

        // POST api/decks
        public void Post(DeckViewModel value)
        {
            var deckEnitity = new Deck();
            deckEnitity.Name = value.Name;
            deckEnitity.GameId = value.GameId;
            deckEnitity.UserId = WebSecurity.GetUserId(User.Identity.Name);
            _dataManager.Create(deckEnitity);
        }

        // PUT api/decks/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/decks/5
        public void Delete(int id)
        {
        }
    }
}
