using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeckBuilderPro.Entity;
using DeckBuilderPro.ViewModels.Interfaces;
using IMapping;
using Enums = DeckBuilderPro.Entity.Enums;
using DeckBuilderPro.DataManager.Interfaces;
using IRepository;

namespace DeckBuilderPro.ViewModels.ViewModelsBuilders
{
    public class CollectionViewModelBuilder : IModelBuilder<Collection, CollectionViewModel>
    {
        private readonly IDataManager<Game, Enums.GameEnities> _gamesManager;
        private readonly IMapper<Collection, CollectionViewModel> _mapper;
        private readonly IModelBuilder<Game, DropDownListItemViewModel> _dropDownListItemViewModelBuilder;

        public CollectionViewModelBuilder(IDataManager<Game, Enums.GameEnities> gamesManager, IMapper<Collection, CollectionViewModel> mapper, IModelBuilder<Game, DropDownListItemViewModel> dropDownListItemViewModelBuilder)
        {
            _gamesManager = gamesManager;
            _mapper = mapper;
            _dropDownListItemViewModelBuilder = dropDownListItemViewModelBuilder;
        }

        public CollectionViewModel CreateFrom(Collection collection)
        {
            CollectionViewModel viewModel = _mapper.Map(collection);
            viewModel.Games = _dropDownListItemViewModelBuilder.CreateFrom(_gamesManager.GetAllForDropdownList());
            return viewModel;
        }

        public CollectionViewModel CreateFrom(Collection collection, int UserId)
        {
            CollectionViewModel viewModel = _mapper.Map(collection);
            viewModel.Games = _dropDownListItemViewModelBuilder.CreateFrom(_gamesManager.GetAllForDropdownList());
            return viewModel;
        }

        public CollectionViewModel Rebuild(CollectionViewModel viewModel)
        {
            viewModel.Games = _dropDownListItemViewModelBuilder.CreateFrom(_gamesManager.GetAllForDropdownList());
            return viewModel;
        }

        public CollectionViewModel Rebuild(CollectionViewModel viewModel, int UserId)
        {
            viewModel.Games = _dropDownListItemViewModelBuilder.CreateFrom(_gamesManager.GetAllForDropdownList());
            return viewModel;
        }

        public IEnumerable<CollectionViewModel> CreateFrom(IEnumerable<Collection> collections)
        {
            var collectionsViewModels = _mapper.Map(collections);
            return collectionsViewModels;
        }

        public IEnumerable<CollectionViewModel> CreateFrom(IEnumerable<Collection> collections, int UserId)
        {
            var collectionsViewModels = _mapper.Map(collections);
            return collectionsViewModels;
        }
    }
}
