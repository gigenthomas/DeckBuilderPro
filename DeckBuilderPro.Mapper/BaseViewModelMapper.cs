using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRepository;
using IMapping;

namespace DeckBuilderPro.Mapper
{
    public class BaseViewModelMapper<TEntity, TModel> : IMapper<TEntity, TModel>
        where TEntity : BaseEntity
        where TModel : class
    {

        public virtual TEntity Map(TModel viewModel)
        {
            return AutoMapper.Mapper.Map<TModel, TEntity>(viewModel);
        }

        public virtual TModel Map(TEntity entity)
        {
            return AutoMapper.Mapper.Map<TEntity, TModel>(entity);
        }

        public virtual IEnumerable<TEntity> Map(IEnumerable<TModel> viewModels)
        {
            return AutoMapper.Mapper.Map<IEnumerable<TModel>, IEnumerable<TEntity>>(viewModels);
        }

        public virtual IEnumerable<TModel> Map(IEnumerable<TEntity> entities)
        {
            return AutoMapper.Mapper.Map<IEnumerable<TEntity>, IEnumerable<TModel>>(entities);
        }
    }

}
