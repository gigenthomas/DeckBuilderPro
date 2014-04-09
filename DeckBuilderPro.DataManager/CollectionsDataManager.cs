using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeckBuilderPro.Entity;
using Enums = DeckBuilderPro.Entity.Enums;
using IRepository;
using DeckBuilderPro.Pager.Interfaces;
using System.Linq.Expressions;

namespace DeckBuilderPro.DataManager
{
    public class CollectionsDataManager : BaseDataManager<Collection, Enums.CollectionEntities>
    {
        public CollectionsDataManager(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public override Collection FindById(int id)
        {
            IRepository<Collection> repository = _unitOfWork.Repository<Collection>();
            var query = repository.Query();
            query = query.Include(e => e.CardsInCollection.Select(c => c.Card).Select(s => s.CardType));

            query = query.Filter(e => e.Id == id);
            return query.Get().FirstOrDefault();
            //            return _unitOfWork.Repository<Deck>().FindById(id);
        }

        public override IEnumerable<Collection> GetAll(List<Enums.CollectionEntities> includes = null)
        {
            includes = new List<Enums.CollectionEntities> { };
            IRepository<Collection> repository = _unitOfWork.Repository<Collection>();
            var query = repository.Query();
            foreach (var include in includes)
            {
                query = query.Include(AddInclude(include));

            }
            
            Expression<Func<Collection, bool>> expression;
            expression = e => e.UserId == 7;
            query = query.Filter(expression);

            return query.Get();
        }

        public override IEnumerable<Collection> GetPage(IPager pager, List<Enums.CollectionEntities> includes = null)
        {
            includes = new List<Enums.CollectionEntities> { };
            int total = 0;
            IRepository<Collection> repository = _unitOfWork.Repository<Collection>();
            var query = repository.Query();
            foreach (var include in includes)
            {
                query = query.Include(AddInclude(include));

            }
            var results = query.OrderBy(c => c.OrderBy(p => p.Name)).GetPage(pager.CurrentPage, pager.NumberOfItemsPerPage, out total);
            pager.NumberOfItems = total;
            return results;
        }


        public override IEnumerable<Collection> GetAllForDropdownList()
        {
            return AddSelectItem(GetAll(), new Collection { Id = 0, Name = "Select Collection" });
        }

        public IEnumerable<Collection> GetMyCollections(int id)
        {
            var repository = _unitOfWork.Repository<Collection>();
            var query = repository.Query();
            query.Filter(c => c.UserId == id);
            var result = query.OrderBy(c => c.OrderBy(p => p.Name)).Get();
            return result;
        }

        private Expression<Func<Collection, object>> AddInclude(Enums.CollectionEntities entity)
        {
            //Expression<Func<Collection, object>> expression;
            //switch (entity)
            //{
            //    case Enums.CollectionEntities:
            //        {
            //            expression = e => e.Manufacturer;
            //            return expression;
            //        }
            //}
            throw new NotImplementedException("Enum Type unsupported: " + entity.ToString());
        }

    }
}
