using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeckBuilderPro.ViewModels.Interfaces;
using DeckBuilderPro.Pager.Interfaces;

namespace DeckBuilderPro.ViewModels.ViewModelsBuilders
{
    public class ListModelBuilder<TModel> : IListModelBuilder<TModel>
        where TModel : class

    {
        private IListViewModel<TModel> _listViewModel;

        public ListModelBuilder(IListViewModel<TModel> listViewModel)
        {
            _listViewModel = listViewModel;
        }
        public IListViewModel<TModel> CreateFrom(IEnumerable<TModel> viewModel, IPager pager, TModel model)
        {
            _listViewModel.Pager = pager;
            _listViewModel.ItemList = viewModel;
            _listViewModel.model = model;
            return _listViewModel;
        }
    }
}
