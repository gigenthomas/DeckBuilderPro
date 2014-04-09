using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeckBuilderPro.ViewModels.Interfaces;
using DeckBuilderPro.DataManager.Interfaces;
using DeckBuilderPro.Entity;
using Enums = DeckBuilderPro.Entity.Enums;
using IMapping;


namespace DeckBuilderPro.ViewModels.ViewModelsBuilders
{
    public class CollectionCardViewModelBuilder : IModelBuilder<CollectionCard, CollectionCardViewModel>
    {
        private readonly IDataManager<CollectionCard, Enums.CollectionCardEntities> _colllectionCardsManager;
        private readonly IDataManager<Game, Enums.GameEnities> _gamesManager;
        private readonly IDataManager<Collection, Enums.CollectionEntities> _collectionsManager;
        private readonly IModelBuilder<Game, DropDownListItemViewModel> _dropDownListItemViewModelBuilder;
        private readonly IModelBuilder<Collection, DropDownListItemViewModel> _dropDownListItemViewModelBuilder2;
        private readonly IMapper<CollectionCard, CollectionCardViewModel> _mapper;


        public CollectionCardViewModelBuilder(IDataManager<CollectionCard, Enums.CollectionCardEntities> colllectionCardsManager, IDataManager<Game, Enums.GameEnities> gamesManager, IDataManager<Collection, Enums.CollectionEntities> collectionsManager, IModelBuilder<Game, DropDownListItemViewModel> dropDownListItemViewModelBuilder, IModelBuilder<Collection, DropDownListItemViewModel> dropDownListItemViewModelBuilder2, IMapper<CollectionCard, CollectionCardViewModel> mapper)
        {
            _colllectionCardsManager = colllectionCardsManager;
            _gamesManager = gamesManager;
            _collectionsManager = collectionsManager;
            _dropDownListItemViewModelBuilder = dropDownListItemViewModelBuilder;
            _dropDownListItemViewModelBuilder2 = dropDownListItemViewModelBuilder2;
            _mapper = mapper;
        }

        public CollectionCardViewModel CreateFrom(CollectionCard collectionCard)
        {
            CollectionCardViewModel viewModel = _mapper.Map(collectionCard);
            viewModel.Games = _dropDownListItemViewModelBuilder.CreateFrom(_gamesManager.GetAllForDropdownList());
            viewModel.Collections = _dropDownListItemViewModelBuilder2.CreateFrom(_collectionsManager.GetAllForDropdownList());
            return viewModel;
        }

        public CollectionCardViewModel CreateFrom(CollectionCard collectionCard, int UserId)
        {
            CollectionCardViewModel viewModel = _mapper.Map(collectionCard);
            viewModel.Games = _dropDownListItemViewModelBuilder.CreateFrom(_gamesManager.GetAllForDropdownList());
            viewModel.Collections = _dropDownListItemViewModelBuilder2.CreateFrom(_collectionsManager.GetAllForDropdownList());
            return viewModel;
        }

        public CollectionCardViewModel Rebuild(CollectionCardViewModel viewModel)
        {
            viewModel.Games = _dropDownListItemViewModelBuilder.CreateFrom(_gamesManager.GetAllForDropdownList());
            viewModel.Collections = _dropDownListItemViewModelBuilder2.CreateFrom(_collectionsManager.GetAllForDropdownList());
            return viewModel;
        }

        public CollectionCardViewModel Rebuild(CollectionCardViewModel viewModel, int UserId)
        {
            viewModel.Games = _dropDownListItemViewModelBuilder.CreateFrom(_gamesManager.GetAllForDropdownList());
            viewModel.Collections = _dropDownListItemViewModelBuilder2.CreateFrom(_collectionsManager.GetAllForDropdownList());
            return viewModel;
        }


        public IEnumerable<CollectionCardViewModel> CreateFrom(IEnumerable<CollectionCard> collections)
        {
            var collectionCardViewModels = _mapper.Map(collections);
            return collectionCardViewModels;
        }

        public IEnumerable<CollectionCardViewModel> CreateFrom(IEnumerable<CollectionCard> collections, int UserId)
        {
            var collectionCardViewModels = _mapper.Map(collections);
            return collectionCardViewModels;
        }

    }
}
