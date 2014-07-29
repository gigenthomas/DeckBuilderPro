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
    public class VsSystemCollectionCardsManager : BaseDataManager<VsSystemCollectionCard, Enums.VsSystemCollectionCardEntities>, IVsSystemCollectionCardsManager
    {
        public VsSystemCollectionCardsManager(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public override IEnumerable<VsSystemCollectionCard> GetAll(List<Enums.VsSystemCollectionCardEntities> includes = null)
        {
            includes = new List<Enums.VsSystemCollectionCardEntities> { };
            IRepository<VsSystemCollectionCard> repository = _unitOfWork.Repository<VsSystemCollectionCard>();
            var query = repository.Query();
            foreach (var include in includes)
            {
                query = query.Include(AddInclude(include));

            }



            return query.Get();
        }

        public override IEnumerable<VsSystemCollectionCard> GetPage(IPager pager, List<Enums.VsSystemCollectionCardEntities> includes = null)
        {
            includes = new List<Enums.VsSystemCollectionCardEntities> { };
            int total = 0;
            IRepository<VsSystemCollectionCard> repository = _unitOfWork.Repository<VsSystemCollectionCard>();
            var query = repository.Query();
            foreach (var include in includes)
            {
                query = query.Include(AddInclude(include));

            }
            var results = query.OrderBy(c => c.OrderBy(p => p.CardId)).GetPage(pager.CurrentPage, pager.NumberOfItemsPerPage, out total);
            pager.NumberOfItems = total;
            return results;
        }


        public override IEnumerable<VsSystemCollectionCard> GetAllForDropdownList()
        {
            return GetAll();
//            return AddSelectItem(GetAll(), new CollectionCard { Id = 0, Name = "Select Collection" });
        }

        private Expression<Func<VsSystemCollectionCard, object>> AddInclude(Enums.VsSystemCollectionCardEntities entity)
        {
            throw new NotImplementedException("Enum Type unsupported: " + entity.ToString());
        }
    }
}
