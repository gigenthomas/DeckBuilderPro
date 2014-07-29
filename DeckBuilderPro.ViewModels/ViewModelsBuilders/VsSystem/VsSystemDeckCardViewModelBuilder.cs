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
    public class VsSystemDeckCardViewModelBuilder : IModelBuilder<VsSystemDeckCard, VsSystemDeckCardViewModel>
    {
        private readonly IMapper<VsSystemDeckCard, VsSystemDeckCardViewModel> _mapper;


        public VsSystemDeckCardViewModelBuilder(IMapper<VsSystemDeckCard, VsSystemDeckCardViewModel> mapper)
        {
            _mapper = mapper;
        }


        public VsSystemDeckCardViewModel CreateFrom(VsSystemDeckCard deckCard)
        {
            VsSystemDeckCardViewModel viewModel = _mapper.Map(deckCard);
            return viewModel;
        }

        public VsSystemDeckCardViewModel CreateFrom(VsSystemDeckCard deckCard, int UserId)
        {
            VsSystemDeckCardViewModel viewModel = _mapper.Map(deckCard);
            return viewModel;
        }

        public VsSystemDeckCardViewModel Rebuild(VsSystemDeckCardViewModel viewModel)
        {
            return viewModel;
        }

        public VsSystemDeckCardViewModel Rebuild(VsSystemDeckCardViewModel viewModel, int UserId)
        {
            return viewModel;
        }

        public IEnumerable<VsSystemDeckCardViewModel> CreateFrom(IEnumerable<VsSystemDeckCard> decks)
        {
            var deckCardsViewModels = _mapper.Map(decks);
            return deckCardsViewModels;
        }

        public IEnumerable<VsSystemDeckCardViewModel> CreateFrom(IEnumerable<VsSystemDeckCard> decks, int UserId)
        {
            var deckCardsViewModels = _mapper.Map(decks);
            return deckCardsViewModels;
        }

    }
}
