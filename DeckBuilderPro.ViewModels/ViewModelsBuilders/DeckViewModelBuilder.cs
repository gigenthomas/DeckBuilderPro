using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeckBuilderPro.Entity;
using DeckBuilderPro.ViewModels.Interfaces;
using IMapping;

namespace DeckBuilderPro.ViewModels.ViewModelsBuilders
{
    public class DeckViewModelBuilder : IModelBuilder<Deck, DeckViewModel>
    {
        private readonly IMapper<Deck, DeckViewModel> _mapper;

        public DeckViewModelBuilder(IMapper<Deck, DeckViewModel> mapper)
        {
            _mapper = mapper;
        }

        public DeckViewModel CreateFrom(Deck deck)
        {
            DeckViewModel viewModel = _mapper.Map(deck);
            return viewModel;
        }

        public DeckViewModel CreateFrom(Deck deck, int UserId)
        {
            DeckViewModel viewModel = _mapper.Map(deck);
            return viewModel;
        }

        public DeckViewModel Rebuild(DeckViewModel viewModel)
        {
            return viewModel;
        }

        public DeckViewModel Rebuild(DeckViewModel viewModel, int UserId)
        {
            return viewModel;
        }

        public IEnumerable<DeckViewModel> CreateFrom(IEnumerable<Deck> decks)
        {
            return _mapper.Map(decks);
        }

        public IEnumerable<DeckViewModel> CreateFrom(IEnumerable<Deck> decks, int UserId)
        {
            return _mapper.Map(decks);
        }

    }
}
