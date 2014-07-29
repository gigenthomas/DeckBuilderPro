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
    public class VsSystemCollectionViewModelBuilder : IModelBuilder<VsSystemCollection, VsSystemCollectionViewModel>
    {
        private readonly IMapper<VsSystemCollection, VsSystemCollectionViewModel> _mapper;

        public VsSystemCollectionViewModelBuilder(IMapper<VsSystemCollection, VsSystemCollectionViewModel> mapper)
        {
            _mapper = mapper;
        }

        public VsSystemCollectionViewModel CreateFrom(VsSystemCollection collection)
        {
            VsSystemCollectionViewModel viewModel = _mapper.Map(collection);
            return viewModel;
        }

        public VsSystemCollectionViewModel CreateFrom(VsSystemCollection collection, int UserId)
        {
            VsSystemCollectionViewModel viewModel = _mapper.Map(collection);
            return viewModel;
        }

        public VsSystemCollectionViewModel Rebuild(VsSystemCollectionViewModel viewModel)
        {
            return viewModel;
        }

        public VsSystemCollectionViewModel Rebuild(VsSystemCollectionViewModel viewModel, int UserId)
        {
            return viewModel;
        }

        public IEnumerable<VsSystemCollectionViewModel> CreateFrom(IEnumerable<VsSystemCollection> collections)
        {
            var collectionsViewModels = _mapper.Map(collections);
            return collectionsViewModels;
        }

        public IEnumerable<VsSystemCollectionViewModel> CreateFrom(IEnumerable<VsSystemCollection> collections, int UserId)
        {
            var collectionsViewModels = _mapper.Map(collections);
            return collectionsViewModels;
        }
    }
}
