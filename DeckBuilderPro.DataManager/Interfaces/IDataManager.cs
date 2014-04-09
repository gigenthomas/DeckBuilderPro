using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRepository;
using DeckBuilderPro.Pager.Interfaces;

namespace DeckBuilderPro.DataManager.Interfaces
{
    public interface IDataManager<TEntity, TEnum> 
        where TEntity : BaseEntity
        where TEnum : struct
    {
        IEnumerable<TEntity> GetAll(List<TEnum> includes = null);
        IEnumerable<TEntity> GetPage(IPager pager, List<TEnum> includes = null); 
        IEnumerable<TEntity> GetAllForDropdownList();
        bool DeleteById(int id);
        TEntity FindById(int id);
        bool Create(TEntity newEntity);
        bool Update(TEntity newEntity);
    }
}
