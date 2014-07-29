using DeckBuilderPro.Entity.VsSystem;
using DeckBuilderPro.ViewModels.Interfaces;
using DeckBuilderPro.ViewModels.VsSystem;
using IMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckBuilderPro.ViewModels.ViewModelsBuilders.VsSystem
{
        public class VsSystemDeckViewModelBuilder : IModelBuilder<VsSystemDeck, VsSystemDeckViewModel>
    {
        private readonly IMapper<VsSystemDeck, VsSystemDeckViewModel> _mapper;

        public VsSystemDeckViewModelBuilder(IMapper<VsSystemDeck, VsSystemDeckViewModel> mapper)
        {
            _mapper = mapper;
        }

        public VsSystemDeckViewModel CreateFrom(VsSystemDeck deck)
        {
            VsSystemDeckViewModel viewModel = _mapper.Map(deck);
            return viewModel;
        }

        public VsSystemDeckViewModel CreateFrom(VsSystemDeck deck, int UserId)
        {
            VsSystemDeckViewModel viewModel = _mapper.Map(deck);
            return viewModel;
        }

        public VsSystemDeckViewModel Rebuild(VsSystemDeckViewModel viewModel)
        {
            return viewModel;
        }

        public VsSystemDeckViewModel Rebuild(VsSystemDeckViewModel viewModel, int UserId)
        {
            return viewModel;
        }

        public IEnumerable<VsSystemDeckViewModel> CreateFrom(IEnumerable<VsSystemDeck> decks)
        {
            return _mapper.Map(decks);
        }

        public IEnumerable<VsSystemDeckViewModel> CreateFrom(IEnumerable<VsSystemDeck> decks, int UserId)
        {
            return _mapper.Map(decks);
        }

    }

}
