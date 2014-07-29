using DeckBuilderPro.DataManager.Interfaces;
using DeckBuilderPro.DataManager.Interfaces.VsSystem;
using DeckBuilderPro.Entity;
using DeckBuilderPro.Entity.VsSystem;
using DeckBuilderPro.ViewModels;
using DeckBuilderPro.ViewModels.Interfaces;
using DeckBuilderPro.ViewModels.VsSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebMatrix.WebData;
using Enums = DeckBuilderPro.Entity.Enums;

namespace DeckBuilderPro.Controllers.Api
{
    [System.Web.Http.Authorize]
    public class VsSystemDecksController : ApiController
    {
        private IModelBuilder<VsSystemDeck, VsSystemDeckViewModel> _deckModelBuilder;
        private readonly IVsSystemDecksManager _decksManager;

        public VsSystemDecksController(
            IVsSystemDecksManager decksManager,
            IModelBuilder<VsSystemDeck, VsSystemDeckViewModel> deckModelBuilder)
        {
            _decksManager = decksManager;
            _deckModelBuilder = deckModelBuilder;

        }
        // GET api/decks
        public IEnumerable<VsSystemDeckViewModel> Get()
        {
            var decks = _decksManager.GetAll();
            if (decks == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return _deckModelBuilder.CreateFrom(decks);
        }

        // GET api/decks/5
        public VsSystemDeckViewModel Get(int id)
        {

            var deck = _decksManager.FindById(id);
            if (deck == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            var viewModel = _deckModelBuilder.CreateFrom(deck);
            return viewModel;

        }

        
        // POST api/decks
        public VsSystemDeckViewModel Post(VsSystemDeckViewModel value)
        {
            var deckEnitity = new VsSystemDeck();
            deckEnitity.Name = value.Name;
            deckEnitity.UserId = WebSecurity.GetUserId(User.Identity.Name);
            _decksManager.Create(deckEnitity);
            var viewModel = _deckModelBuilder.CreateFrom(deckEnitity);
            return viewModel;

        }

        // PUT api/decks/5
        public void Put(int id, [FromBody]string value)
        {
        }

        
        // DELETE api/decks/5
        public void Delete(int id)
        {
            int a = id;
        }
    }

}
