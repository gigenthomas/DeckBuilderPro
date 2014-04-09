using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRepository;

namespace DeckBuilderPro.ViewModels.Interfaces
{
    public interface IModelBuilder<TEntity, TViewModel>
        where TEntity : BaseEntity
        where TViewModel : class
    {
        TViewModel CreateFrom(TEntity entity);
        TViewModel CreateFrom(TEntity entity, int UserId);
        TViewModel Rebuild(TViewModel viewModel);
        TViewModel Rebuild(TViewModel viewModel, int UserId);
        IEnumerable<TViewModel> CreateFrom(IEnumerable<TEntity> dataModels);
        IEnumerable<TViewModel> CreateFrom(IEnumerable<TEntity> dataModels, int UserId);
    }

}
