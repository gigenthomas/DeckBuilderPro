using DeckBuilderPro.DataManager.Interfaces;
using DeckBuilderPro.Entity;
using DeckBuilderPro.ViewModels;
using DeckBuilderPro.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Enums = DeckBuilderPro.Entity.Enums;


namespace DeckBuilderPro.Controllers.Api
{
    public class CollectionsController : ApiController
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


        public IEnumerable<CollectionViewModel> GET()
        {
            var collections = _dataManager.GetAll();
            return _modelBuilder.CreateFrom(collections);
        }

    
    }
}
