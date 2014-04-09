using DeckBuilderPro.DataManager;
using DeckBuilderPro.DataManager.Interfaces;
using DeckBuilderPro.DataManagers;
using DeckBuilderPro.DataManagers.Interfaces;
using DeckBuilderPro.Entity;
using DeckBuilderPro.ViewModels;
using DeckBuilderPro.ViewModels.Interfaces;
using DeckBuilderPro.ViewModels.ViewModelsBuilders;
using IRepository;
using Microsoft.Practices.Unity;
using System.Web.Http;
using UnityWebApi = Unity.WebApi;
using UnityMvc = Unity.Mvc4;
using Enums = DeckBuilderPro.Entity.Enums;
using System.Web.Mvc;
using IMapping;
using DeckBuilderPro.Unity;


namespace DeckBuilderPro
{
    public static class UnityConfig
    {
        public static void Initialise()
        {
            //var container = BuildUnityContainer();

            var container = UnityConfiguration.BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityMvc.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new UnityWebApi.UnityDependencyResolver(container);
        }

        //private static IUnityContainer BuildUnityContainer()
        //{
        //    var container = new UnityContainer();

        //    container
        //       .RegisterType<IDbContext, DataContext>()
        //       .RegisterType<IUnitOfWork, UnitOfWork>()
        //       //.RegisterType(typeof(IMapper<,>), typeof(ViewModelMapper<,>))
        //       .RegisterType<IMapper<Deck, DeckViewModel>, DeckViewModelMapper>()
        //       //.RegisterType<IMapper<DeckCard, DeckCardViewModel>, DeckCardViewModelMapper>()               
        //       .RegisterType(typeof(IMapper<,>), typeof(GenericViewModelMapper<,>))
        //       .RegisterType(typeof(IListViewModel<>), typeof(ListViewModel<>))
        //       .RegisterType(typeof(IListModelBuilder<>), typeof(ListModelBuilder<>))
        //       .RegisterType<IModelBuilder<Game, GameViewModel>, GameModelBuilder>()
        //       .RegisterType<IDataManager<Game, Enums.GameEnities>, GamesDataManager>()
        //       .RegisterType<IModelBuilder<Manufacturer, ManufacturerViewModel>, ManufacturerModelBuilder>()
        //       .RegisterType<IDataManager<Manufacturer, Enums.ManufactuerEnities>, ManufacturersDataManager>()
        //       .RegisterType<IDataManager<VsSystem_Card, Enums.VsSystem_CardEnities>, VsSystem_CardsDataManager>()
        //       .RegisterType<IModelBuilder<VsSystem_Card, VsSystem_CardViewModel>, VsSystem_CardModelBuilder>()
        //       .RegisterType<IDataManager<Deck, Enums.DeckEntities>, DecksDataManager>()
        //       .RegisterType<IModelBuilder<Deck, DeckViewModel>, DeckViewModelBuilder>()
        //       .RegisterType<IDataManager<Collection, Enums.CollectionEntities>, CollectionsDataManager>()
        //       .RegisterType<IDataManager<CollectionCard, Enums.CollectionCardEntities>, CollectionCardsDataManager>()
        //       .RegisterType<IModelBuilder<Collection, CollectionViewModel>, CollectionViewModelBuilder>()
        //       .RegisterType<IModelBuilder<CollectionCard, CollectionCardViewModel>, CollectionCardViewModelBuilder>()
        //       .RegisterType<IModelBuilder<Game, DropDownListItemViewModel>, DropDownListItemViewModelBuilder<Game>>()
        //       .RegisterType<IModelBuilder<Collection, DropDownListItemViewModel>, DropDownListItemViewModelBuilder<Collection>>()
        //       .RegisterType<IDataManager<DeckCard, Enums.DeckCardEntities>, DeckCardsDataManager>()
        //       .RegisterType<IModelBuilder<DeckCard, DeckCardViewModel>, DeckCardViewModelBuilder>()
        //       .RegisterType<IModelBuilder<Deck, DropDownListItemViewModel>, DropDownListItemViewModelBuilder<Deck>>()
        //       .RegisterType<ICollectionsManager, CollectionsManager>()
        //       .RegisterType<ICardsManager, CardsManager>()
        //       .RegisterType<ICollectionsManager, CollectionsManager>()
        //       .RegisterType<IDecksManager, DecksManager>()
        //        ;



        //    //.RegisterType(typeof(IListModelBuilder<,>), typeof(ListModelBuilder<>)) 
        //    //.RegisterType<IMapper<VsSystem_Card, VsSystem_CardViewModel>, ViewModelMapper<VsSystem_Card, VsSystem_CardViewModel>>()
        //    //.RegisterType<IMapper<Manufacturer, ManufacturerViewModel>, ViewModelMapper<Manufacturer, ManufacturerViewModel>>()
        //    //.RegisterType<IMapper<Game,GameViewModel>,ViewModelMapper<Game, GameViewModel>>()


        //    // register all your components with the container here
        //    // e.g. container.RegisterType<ITestService, TestService>();            
            
        //    return container;
        //}

    }
}