using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeckBuilderPro.ViewModels.Interfaces;
using DeckBuilderPro.Pager.Interfaces;
using IRepository;

namespace DeckBuilderPro.ViewModels
{
    public class ListViewModel<TModel> : IListViewModel<TModel>
        where TModel : class
    {
        public IPager Pager {get ; set;}
        public IEnumerable<TModel> ItemList { get; set; }
        public TModel model { get; set; }
    }
}
