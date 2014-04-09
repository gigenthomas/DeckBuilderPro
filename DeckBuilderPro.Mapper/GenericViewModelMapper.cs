using IMapping;
using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckBuilderPro.Mapper
{
    public class GenericViewModelMapper<TEntity, TModel> : BaseViewModelMapper<TEntity, TModel>
        where TEntity : BaseEntity
        where TModel : class
    {
        static GenericViewModelMapper()
        {
            AutoMapper.Mapper.CreateMap<TEntity, TModel>();
            AutoMapper.Mapper.CreateMap<TModel, TEntity>();
        }
    }
}
