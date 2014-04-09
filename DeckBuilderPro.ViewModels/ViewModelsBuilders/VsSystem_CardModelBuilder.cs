using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeckBuilderPro.Entity;
using DeckBuilderPro.ViewModels.Interfaces;
using IMapping;
using DeckBuilderPro.DataManager.Interfaces;

namespace DeckBuilderPro.ViewModels.ViewModelsBuilders
{
    public class VsSystem_CardModelBuilder : IModelBuilder<VsSystem_Card, VsSystem_CardViewModel>
    {
        private readonly IMapper<VsSystem_Card, VsSystem_CardViewModel> _mapper;

        public VsSystem_CardModelBuilder(IMapper<VsSystem_Card, VsSystem_CardViewModel> mapper)
        {
            _mapper = mapper;
        }

        public VsSystem_CardViewModel CreateFrom(VsSystem_Card card)
        {
            VsSystem_CardViewModel viewModel = _mapper.Map(card);
            return viewModel;
        }

        public VsSystem_CardViewModel CreateFrom(VsSystem_Card card, int UserId)
        {
            VsSystem_CardViewModel viewModel = _mapper.Map(card);
            return viewModel;
        }

        public VsSystem_CardViewModel Rebuild(VsSystem_CardViewModel viewModel)
        {
            return viewModel;
        }

        public VsSystem_CardViewModel Rebuild(VsSystem_CardViewModel viewModel, int UserId)
        {
            return viewModel;
        }

        public IEnumerable<VsSystem_CardViewModel> CreateFrom(IEnumerable<VsSystem_Card> cards)
        {
            return _mapper.Map(cards);
        }

        public IEnumerable<VsSystem_CardViewModel> CreateFrom(IEnumerable<VsSystem_Card> cards, int UserId)
        {
            return _mapper.Map(cards);
        }
    }
}
