using DeckBuilderPro.Data;
using DeckBuilderPro.DataManager;
using DeckBuilderPro.DataManager.Interfaces;
using DeckBuilderPro.Entity;
using DeckBuilderPro.Entity.VsSystem;
using DeckBuilderPro.Mapper;
using DeckBuilderPro.ViewModels;
using DeckBuilderPro.ViewModels.Interfaces;
using DeckBuilderPro.ViewModels.ViewModelsBuilders;
using DeckBuilderPro.ViewModels.ViewModelsBuilders.VsSystem;
using DeckBuilderPro.ViewModels.VsSystem;
using IMapping;
using IRepository;
using Microsoft.Practices.Unity;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enums = DeckBuilderPro.Entity.Enums;
using VsSystemDataManager = DeckBuilderPro.DataManager.VsSystem;
using VsSystemDataManagerInterface = DeckBuilderPro.DataManager.Interfaces.VsSystem;

namespace DeckBuilderPro.Unity
{
    public static class UnityConfiguration
    {
        public static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container
               .RegisterType<IUnitOfWork, UnitOfWork>()
                //.RegisterType(typeof(IMapper<,>), typeof(ViewModelMapper<,>))
               .RegisterType<IMapper<Deck, DeckViewModel>, DeckViewModelMapper>()
               .RegisterType<IMapper<VsSystemCard, VsSystemCardViewModel>, VsSystemCardViewModelMapper>()
                //.RegisterType<IMapper<DeckCard, DeckCardViewModel>, DeckCardViewModelMapper>()               
               .RegisterType(typeof(IMapper<,>), typeof(GenericViewModelMapper<,>))
               .RegisterType(typeof(IListViewModel<>), typeof(ListViewModel<>))
               .RegisterType(typeof(IListModelBuilder<>), typeof(ListModelBuilder<>))
               .RegisterType<IModelBuilder<Game, GameViewModel>, GameModelBuilder>()
               .RegisterType<IDataManager<Game, Enums.GameEnities>, GamesDataManager>()
               .RegisterType<IModelBuilder<Manufacturer, ManufacturerViewModel>, ManufacturerModelBuilder>()
               .RegisterType<IDataManager<Manufacturer, Enums.ManufactuerEnities>, ManufacturersDataManager>()
               .RegisterType<IDataManager<VsSystem_Card, Enums.VsSystem_CardEnities>, VsSystem_CardsDataManager>()
               .RegisterType<IModelBuilder<VsSystem_Card, VsSystem_CardViewModel>, VsSystem_CardModelBuilder>()
               .RegisterType<IDataManager<Deck, Enums.DeckEntities>, DecksDataManager>()
               .RegisterType<IModelBuilder<Deck, DeckViewModel>, DeckViewModelBuilder>()
               .RegisterType<IDataManager<Collection, Enums.CollectionEntities>, CollectionsDataManager>()
               .RegisterType<IDataManager<CollectionCard, Enums.CollectionCardEntities>, CollectionCardsDataManager>()
               .RegisterType<IModelBuilder<Collection, CollectionViewModel>, CollectionViewModelBuilder>()
               .RegisterType<IModelBuilder<CollectionCard, CollectionCardViewModel>, CollectionCardViewModelBuilder>()
               .RegisterType<IModelBuilder<Game, DropDownListItemViewModel>, DropDownListItemViewModelBuilder<Game>>()
               .RegisterType<IModelBuilder<Collection, DropDownListItemViewModel>, DropDownListItemViewModelBuilder<Collection>>()
               .RegisterType<IDataManager<DeckCard, Enums.DeckCardEntities>, DeckCardsDataManager>()
               .RegisterType<IModelBuilder<DeckCard, DeckCardViewModel>, DeckCardViewModelBuilder>()
               .RegisterType<IModelBuilder<Deck, DropDownListItemViewModel>, DropDownListItemViewModelBuilder<Deck>>()
               .RegisterType<ICollectionsManager, CollectionsManager>()
               .RegisterType<ICardsManager, CardsManager>()
               .RegisterType<VsSystemDataManagerInterface.ICardsManager, VsSystemDataManager.CardsManager>()
               .RegisterType <IModelBuilder<VsSystemCard, VsSystemCardViewModel>, VsSystemCardViewModelBuilder>()
               .RegisterType<ICollectionsManager, CollectionsManager>()
               .RegisterType<IDecksManager, DecksManager>()
                ;

            return container;

        }
    }
}
