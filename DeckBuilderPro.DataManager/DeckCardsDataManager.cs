using System;
using System.Linq;
using System.Text;
using DeckBuilderPro.Entity;
using Enums = DeckBuilderPro.Entity.Enums;
using IRepository;
using DeckBuilderPro.Pager.Interfaces;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DeckBuilderPro.DataManager
{
    public class DeckCardsDataManager : BaseDataManager<DeckCard, Enums.DeckCardEntities>
    {
        public DeckCardsDataManager(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public override IEnumerable<DeckCard> GetAll(List<Enums.DeckCardEntities> includes = null)
        {
            includes = new List<Enums.DeckCardEntities> { };
            IRepository<DeckCard> repository = _unitOfWork.Repository<DeckCard>();
            var query = repository.Query();
            foreach (var include in includes)
            {
                query = query.Include(AddInclude(include));

            }

            return query.Get();
        }

        public override IEnumerable<DeckCard> GetPage(IPager pager, List<Enums.DeckCardEntities> includes = null)
        {
            includes = new List<Enums.DeckCardEntities> { };
            int total = 0;
            IRepository<DeckCard> repository = _unitOfWork.Repository<DeckCard>();
            var query = repository.Query();
            foreach (var include in includes)
            {
                query = query.Include(AddInclude(include));

            }
            var results = query.OrderBy(c => c.OrderBy(p => p.CardId)).GetPage(pager.CurrentPage, pager.NumberOfItemsPerPage, out total);
            pager.NumberOfItems = total;
            return results;
        }

        public override IEnumerable<DeckCard> GetAllForDropdownList()
        {
            return GetAll();
            //            return AddSelectItem(GetAll(), new DeckCard { Id = 0, Name = "Select Deck" });
        }

        private Expression<Func<DeckCard, object>> AddInclude(Enums.DeckCardEntities entity)
        {
            //Expression<Func<Deck, object>> expression;
            //switch (entity)
            //{
            //    case Enums.DeckEntities:
            //        {
            //            expression = e => e.Manufacturer;
            //            return expression;
            //        }
            //}
            throw new NotImplementedException("Enum Type unsupported: " + entity.ToString());
        }

    }
}
