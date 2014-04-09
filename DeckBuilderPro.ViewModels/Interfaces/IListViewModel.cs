using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRepository;
using DeckBuilderPro.Pager.Interfaces;

namespace DeckBuilderPro.ViewModels.Interfaces
{
    public interface IListViewModel<TModel> 
        where TModel : class
    {
        IPager Pager {get; set;}
        IEnumerable<TModel> ItemList {get; set;}
        TModel model { get; set; }
    }
}
