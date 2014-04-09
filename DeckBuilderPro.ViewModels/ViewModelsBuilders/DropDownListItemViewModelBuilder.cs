using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeckBuilderPro.ViewModels.Interfaces;
using IRepository;
using IMapping;

namespace DeckBuilderPro.ViewModels.ViewModelsBuilders
{
    public class DropDownListItemViewModelBuilder<TEntity> : IModelBuilder<TEntity, DropDownListItemViewModel> 
        where TEntity : BaseEntity
    {
        private readonly IMapper<TEntity, DropDownListItemViewModel> _mapper;

        public DropDownListItemViewModelBuilder(IMapper<TEntity, DropDownListItemViewModel> mapper)
        {
            _mapper = mapper;
        }

        public DropDownListItemViewModel CreateFrom(TEntity deck)
        {
            DropDownListItemViewModel viewModel = _mapper.Map(deck);
            return viewModel;
        }

        public DropDownListItemViewModel CreateFrom(TEntity deck, int UserId)
        {
            DropDownListItemViewModel viewModel = _mapper.Map(deck);
            return viewModel;
        }

        public DropDownListItemViewModel Rebuild(DropDownListItemViewModel viewModel)
        {
            return viewModel;
        }

        public DropDownListItemViewModel Rebuild(DropDownListItemViewModel viewModel, int UserId)
        {
            return viewModel;
        }

        public IEnumerable<DropDownListItemViewModel> CreateFrom(IEnumerable<TEntity> decks)
        {
            return _mapper.Map(decks);
        }

        public IEnumerable<DropDownListItemViewModel> CreateFrom(IEnumerable<TEntity> decks, int UserId)
        {
            return _mapper.Map(decks);
        }
    }
}
