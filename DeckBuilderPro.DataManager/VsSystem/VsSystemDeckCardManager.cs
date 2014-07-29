using DeckBuilderPro.DataManager.Interfaces.VsSystem;
using DeckBuilderPro.Entity.VsSystem;
using DeckBuilderPro.Pager.Interfaces;
using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Enums = DeckBuilderPro.Entity.Enums;

namespace DeckBuilderPro.DataManager.VsSystem
{
    public class VsSystemDeckCardManager : BaseDataManager<VsSystemDeckCard, Enums.VsSystemDeckCardEntities>, IVsSystemDeckCardsManager
    {
        public VsSystemDeckCardManager(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        
        }

        public override VsSystemDeckCard FindById(int id)
        {
            IRepository<VsSystemDeckCard> repository = _unitOfWork.Repository<VsSystemDeckCard>();
            var query = repository.Query();
            query = query.Include(dc => dc.Card.CardType);
            query.Filter(dc => dc.Id == id);
            return query.Get().FirstOrDefault();
        }

        public IEnumerable<VsSystemDeckCard> GetAll()
        {
            var repository = _unitOfWork.Repository<VsSystemDeckCard>();
            return repository.Query().Get();
        }

        public override IEnumerable<VsSystemDeckCard> GetAll(List<Enums.VsSystemDeckCardEntities> includes = null)
        {
            includes = new List<Enums.VsSystemDeckCardEntities> { };
            IRepository<VsSystemDeckCard> repository = _unitOfWork.Repository<VsSystemDeckCard>();
            var query = repository.Query();
            foreach (var include in includes)
            {
                query = query.Include(AddInclude(include));

            }

            return query.Get();
        }

        public override IEnumerable<VsSystemDeckCard> GetPage(IPager pager, List<Enums.VsSystemDeckCardEntities> includes = null)
        {
            includes = new List<Enums.VsSystemDeckCardEntities> { };
            int total = 0;
            IRepository<VsSystemDeckCard> repository = _unitOfWork.Repository<VsSystemDeckCard>();
            var query = repository.Query();
            foreach (var include in includes)
            {
                query = query.Include(AddInclude(include));

            }
            var results = query.OrderBy(c => c.OrderBy(p => p.CardId)).GetPage(pager.CurrentPage, pager.NumberOfItemsPerPage, out total);
            pager.NumberOfItems = total;
            return results;
        }

        public override IEnumerable<VsSystemDeckCard> GetAllForDropdownList()
        {
            return GetAll();
        }

        private Expression<Func<VsSystemDeckCard, object>> AddInclude(Enums.VsSystemDeckCardEntities entity)
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
