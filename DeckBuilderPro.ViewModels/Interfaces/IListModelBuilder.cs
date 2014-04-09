using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeckBuilderPro.Pager.Interfaces;

namespace DeckBuilderPro.ViewModels.Interfaces
{
    public interface IListModelBuilder<TModel> 
        where TModel : class
    {
        IListViewModel<TModel> CreateFrom(IEnumerable<TModel> viewModelCollection, IPager pager, TModel model);
    }
}
