using DeckBuilderPro.DataManager.Interfaces.VsSystem;
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
    public class VsSystemCollectionCardViewModelBuilder : IModelBuilder<VsSystemCollectionCard, VsSystemCollectionCardViewModel>
    {
        private readonly IVsSystemCollectionCardsManager _colllectionCardsManager;
        private readonly IMapper<VsSystemCollectionCard, VsSystemCollectionCardViewModel> _mapper;


        public VsSystemCollectionCardViewModelBuilder(
            IVsSystemCollectionCardsManager colllectionCardsManager,
            IMapper<VsSystemCollectionCard, VsSystemCollectionCardViewModel> mapper)
        {
            _colllectionCardsManager = colllectionCardsManager;
            _mapper = mapper;
        }

        public VsSystemCollectionCardViewModel CreateFrom(VsSystemCollectionCard collectionCard)
        {
            VsSystemCollectionCardViewModel viewModel = _mapper.Map(collectionCard);
            return viewModel;
        }

        public VsSystemCollectionCardViewModel CreateFrom(VsSystemCollectionCard collectionCard, int UserId)
        {
            VsSystemCollectionCardViewModel viewModel = _mapper.Map(collectionCard);
            return viewModel;
        }

        public VsSystemCollectionCardViewModel Rebuild(VsSystemCollectionCardViewModel viewModel)
        {
            return viewModel;
        }

        public VsSystemCollectionCardViewModel Rebuild(VsSystemCollectionCardViewModel viewModel, int UserId)
        {
            return viewModel;
        }


        public IEnumerable<VsSystemCollectionCardViewModel> CreateFrom(IEnumerable<VsSystemCollectionCard> collections)
        {
            var collectionCardViewModels = _mapper.Map(collections);
            return collectionCardViewModels;
        }

        public IEnumerable<VsSystemCollectionCardViewModel> CreateFrom(IEnumerable<VsSystemCollectionCard> collections, int UserId)
        {
            var collectionCardViewModels = _mapper.Map(collections);
            return collectionCardViewModels;
        }

    }
}
