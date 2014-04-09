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
    public class CollectionCardsDataManager : BaseDataManager<CollectionCard, Enums.CollectionCardEntities>
    {
        public CollectionCardsDataManager(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public override IEnumerable<CollectionCard> GetAll(List<Enums.CollectionCardEntities> includes = null)
        {
            includes = new List<Enums.CollectionCardEntities> { };
            IRepository<CollectionCard> repository = _unitOfWork.Repository<CollectionCard>();
            var query = repository.Query();
            foreach (var include in includes)
            {
                query = query.Include(AddInclude(include));

            }



            return query.Get();
        }

        public override IEnumerable<CollectionCard> GetPage(IPager pager, List<Enums.CollectionCardEntities> includes = null)
        {
            includes = new List<Enums.CollectionCardEntities> { };
            int total = 0;
            IRepository<CollectionCard> repository = _unitOfWork.Repository<CollectionCard>();
            var query = repository.Query();
            foreach (var include in includes)
            {
                query = query.Include(AddInclude(include));

            }
            var results = query.OrderBy(c => c.OrderBy(p => p.CardId)).GetPage(pager.CurrentPage, pager.NumberOfItemsPerPage, out total);
            pager.NumberOfItems = total;
            return results;
        }


        public override IEnumerable<CollectionCard> GetAllForDropdownList()
        {
            return GetAll();
//            return AddSelectItem(GetAll(), new CollectionCard { Id = 0, Name = "Select Collection" });
        }

        private Expression<Func<CollectionCard, object>> AddInclude(Enums.CollectionCardEntities entity)
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
