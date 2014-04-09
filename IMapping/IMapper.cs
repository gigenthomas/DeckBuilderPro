using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMapping
{
    public interface IMapper<TEntity, TModel>
        where TEntity : BaseEntity
        where TModel : class
    {
        TEntity Map(TModel viewModel);

        TModel Map(TEntity entity);

        IEnumerable<TEntity> Map(IEnumerable<TModel> viewModels);

        IEnumerable<TModel> Map(IEnumerable<TEntity> entities);

    }
}
