using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeckBuilderPro.ViewModels.Interfaces;
using DeckBuilderPro.Entity;
using DeckBuilderPro.DataManager.Interfaces;
using Enums = DeckBuilderPro.Entity.Enums;
using IMapping;

namespace DeckBuilderPro.ViewModels.ViewModelsBuilders
{
    public class DeckCardViewModelBuilder : IModelBuilder<DeckCard, DeckCardViewModel>
    {

        private readonly IDataManager<DeckCard, Enums.DeckCardEntities> _deckCardsManager;
        private readonly IDataManager<Deck, Enums.DeckEntities> _decksManager;
        private readonly IDataManager<Collection, Enums.CollectionEntities> _collectionsManager;
        private readonly IModelBuilder<Deck, DropDownListItemViewModel> _dropDownListItemViewModelBuilder;
        private readonly IModelBuilder<Collection, DropDownListItemViewModel> _dropDownListItemViewModelBuilderCollection;
        private readonly IMapper<DeckCard, DeckCardViewModel> _mapper;


        public DeckCardViewModelBuilder(
            IDataManager<DeckCard, Enums.DeckCardEntities> deckCardsManager, 
            IDataManager<Deck, Enums.DeckEntities> deckManager, 
            IModelBuilder<Deck, DropDownListItemViewModel> dropDownListItemViewModelBuilder, 
            IModelBuilder<Collection, DropDownListItemViewModel> dropDownListItemViewModelBuilderCollection,
            IMapper<DeckCard, DeckCardViewModel> mapper, 
            IDataManager<Collection, Enums.CollectionEntities> collectionsManager)
        {
            _deckCardsManager = deckCardsManager;
            _decksManager = deckManager;
            _collectionsManager = collectionsManager;
            _dropDownListItemViewModelBuilder = dropDownListItemViewModelBuilder;
            _dropDownListItemViewModelBuilderCollection = dropDownListItemViewModelBuilderCollection;
            _mapper = mapper;
        }


        public DeckCardViewModel CreateFrom(DeckCard deckCard)
        {
            DeckCardViewModel viewModel = _mapper.Map(deckCard);
            viewModel.Decks = _dropDownListItemViewModelBuilder.CreateFrom(_decksManager.GetAllForDropdownList());
            viewModel.Collections = _dropDownListItemViewModelBuilderCollection.CreateFrom(_collectionsManager.GetAllForDropdownList());
            return viewModel;
        }

        public DeckCardViewModel CreateFrom(DeckCard deckCard, int UserId)
        {
            DeckCardViewModel viewModel = _mapper.Map(deckCard);
            viewModel.Decks = _dropDownListItemViewModelBuilder.CreateFrom(_decksManager.GetAllForDropdownList());
            viewModel.Collections = _dropDownListItemViewModelBuilderCollection.CreateFrom(_collectionsManager.GetAllForDropdownList());
            return viewModel;
        }

        public DeckCardViewModel Rebuild(DeckCardViewModel viewModel)
        {
            viewModel.Decks = _dropDownListItemViewModelBuilder.CreateFrom(_decksManager.GetAllForDropdownList());
            viewModel.Collections = _dropDownListItemViewModelBuilderCollection.CreateFrom(_collectionsManager.GetAllForDropdownList());
            return viewModel;
        }

        public DeckCardViewModel Rebuild(DeckCardViewModel viewModel, int UserId)
        {
            viewModel.Decks = _dropDownListItemViewModelBuilder.CreateFrom(_decksManager.GetAllForDropdownList());
            viewModel.Collections = _dropDownListItemViewModelBuilderCollection.CreateFrom(_collectionsManager.GetAllForDropdownList());
            return viewModel;
        }

        public IEnumerable<DeckCardViewModel> CreateFrom(IEnumerable<DeckCard> decks)
        {
            var deckCardsViewModels = _mapper.Map(decks);
            return deckCardsViewModels;
        }

        public IEnumerable<DeckCardViewModel> CreateFrom(IEnumerable<DeckCard> decks, int UserId)
        {
            var deckCardsViewModels = _mapper.Map(decks);
            return deckCardsViewModels;
        }
    }
}
