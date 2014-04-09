using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeckBuilderPro.Entity;
using Enums = DeckBuilderPro.Entity.Enums;
using IRepository;
using DeckBuilderPro.Pager.Interfaces;

namespace DeckBuilderPro.DataManager
{
    public class DecksDataManager : BaseDataManager<Deck, Enums.DeckEntities>
    {
        public DecksDataManager(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public override Deck FindById(int id)
        {
            IRepository<Deck> repository = _unitOfWork.Repository<Deck>();
            var query = repository.Query();
            query = query.Include(e => e.CardsInDeck.Select(c => c.Card).Select(s => s.CardType));

            query = query.Filter(e => e.Id == id);
            return query.Get().FirstOrDefault();
//            return _unitOfWork.Repository<Deck>().FindById(id);
        }

        public override IEnumerable<Deck> GetAll(List<Enums.DeckEntities> includes)
        {
            IRepository<Deck> repository = _unitOfWork.Repository<Deck>();
            var query = repository.Query();

            //foreach (var include in includes)
            //{
            //    query = query.Include(AddInclude(include));

            //}
            return query.Get();
        }

        public override IEnumerable<Deck> GetPage(IPager pager, List<Enums.DeckEntities> includes)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Deck> GetAllForDropdownList()
        {
            return AddSelectItem(GetAll(new List<Enums.DeckEntities> { }), new Deck { Id = 0, Name = "Select Deck" });
        }

    }
}
