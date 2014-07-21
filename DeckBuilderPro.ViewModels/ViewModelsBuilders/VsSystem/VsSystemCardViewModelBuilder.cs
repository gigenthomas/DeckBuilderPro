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
    public class VsSystemCardViewModelBuilder : IModelBuilder<VsSystemCard, VsSystemCardViewModel>
    {
        private readonly IMapper<VsSystemCard, VsSystemCardViewModel> _mapper;

        public VsSystemCardViewModelBuilder(IMapper<VsSystemCard, VsSystemCardViewModel> mapper)
        {
            _mapper = mapper;
        }

        public VsSystemCardViewModel CreateFrom(VsSystemCard card)
        {
            VsSystemCardViewModel viewModel = _mapper.Map(card);
            return viewModel;
        }

        public IEnumerable<VsSystemCardViewModel> CreateFrom(IEnumerable<VsSystemCard> decks)
        {
            var deckCardsViewModels = _mapper.Map(decks);
            return deckCardsViewModels;
        }



        public VsSystemCardViewModel CreateFrom(VsSystemCard entity, int UserId)
        {
            throw new NotImplementedException();
        }

        public VsSystemCardViewModel Rebuild(VsSystemCardViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public VsSystemCardViewModel Rebuild(VsSystemCardViewModel viewModel, int UserId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VsSystemCardViewModel> CreateFrom(IEnumerable<VsSystemCard> dataModels, int UserId)
        {
            throw new NotImplementedException();
        }
    }
}
