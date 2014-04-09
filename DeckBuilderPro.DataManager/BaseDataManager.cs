using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeckBuilderPro.DataManager.Interfaces;
using IRepository;
using DeckBuilderPro.Pager.Interfaces;

namespace DeckBuilderPro.DataManager
{
    public abstract class BaseDataManager<TEntity, TEnum> : IDataManager<TEntity, TEnum>
        where TEntity : BaseEntity
        where TEnum : struct
    {
        protected readonly IUnitOfWork _unitOfWork;

        public BaseDataManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public abstract IEnumerable<TEntity> GetAll(List<TEnum> includes = null);
        public abstract IEnumerable<TEntity> GetPage(IPager pager, List<TEnum> includes = null);
        public abstract IEnumerable<TEntity> GetAllForDropdownList();

        public virtual TEntity FindById(int id)
        {
            return _unitOfWork.Repository<TEntity>().FindById(id);
        }

        public virtual bool Create(TEntity newEntity)
        {
            try
            {
                _unitOfWork.Repository<TEntity>().Insert(newEntity);
                _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;

        }

        public virtual bool Update(TEntity newEntity)
        {
            try
            {
                _unitOfWork.Repository<TEntity>().Update(newEntity);
                _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;

        }

        public virtual bool DeleteById(int id)
        {
            try
            {
                var entity = _unitOfWork.Repository<TEntity>().FindById(id);
                _unitOfWork.Repository<TEntity>().Delete(entity);
                _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                return false;
            }

            return true;

        }

        public IEnumerable<TEntity> AddSelectItem(IEnumerable<TEntity> list, TEntity selectItem)
        {
            var returnList = list.ToList<TEntity>();
            returnList.Insert(0, selectItem);
            return returnList;
        }
    }
}
