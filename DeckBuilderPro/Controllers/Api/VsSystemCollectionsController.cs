using DeckBuilderPro.DataManager.Interfaces.VsSystem;
using DeckBuilderPro.Entity.VsSystem;
using DeckBuilderPro.ViewModels.Interfaces;
using DeckBuilderPro.ViewModels.VsSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DeckBuilderPro.Controllers.Api
{
    public class VsSystemCollectionsController : ApiController
    {
        private readonly IModelBuilder<VsSystemCollection, VsSystemCollectionViewModel> _modelBuilder;
        private readonly IVsSystemCollectionsManager _vsSystemCollectionsManager;

        public VsSystemCollectionsController(
            IVsSystemCollectionsManager vsSystemCollectionsManager,
            IModelBuilder<VsSystemCollection, VsSystemCollectionViewModel> modelBuilder)
        {
            _vsSystemCollectionsManager = vsSystemCollectionsManager;
            _modelBuilder = modelBuilder;
        }


        public IEnumerable<VsSystemCollectionViewModel> GET()
        {
            var collections = _vsSystemCollectionsManager.GetAll();
            return _modelBuilder.CreateFrom(collections);
        }

        public VsSystemCollectionViewModel Get(int id)
        {
            var collection = _vsSystemCollectionsManager.FindById(id);
            var collectionModel = _modelBuilder.CreateFrom(collection);
            return collectionModel;
        }

    }
}
