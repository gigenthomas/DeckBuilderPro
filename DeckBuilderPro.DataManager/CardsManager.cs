using DeckBuilderPro.DataManager.Interfaces;
using DeckBuilderPro.Entity;
using DeckBuilderPro.Pager.Interfaces;
using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Enums = DeckBuilderPro.Entity.Enums;

namespace DeckBuilderPro.DataManager
{
    public class CardsManager : BaseDataManager<Card, Enums.CardEntities>, ICardsManager
    {

        public CardsManager(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }


        public Card LookupCard(string cardIdentifier, int gameId)
        {
            var cardRepository = new DeckBuilderPro.DataManager.VsSystem_CardsDataManager(new Repository.UnitOfWork());
            var card = cardRepository.GetAll(new List<Enums.VsSystem_CardEnities> { }).Where(c => c.CardIdentifier.ToUpper() == cardIdentifier.ToUpper() && c.GameId == gameId).FirstOrDefault();
            if (card == null)
            {
                throw new Exception("Invalid Card");
            }
            return card;
        }

        public List<Card> TypeAheadByName(string name, int gameId)
        {
            int total = 0;
            IRepository<Card> repository = _unitOfWork.Repository<Card>();
            var query = repository.Query().Filter(c => c.GameId == gameId && c.Name.StartsWith(name)).OrderBy(c => c.OrderBy(p => p.Name));
            return query.GetPage(1, 10, out total).ToList();
        }


        public override IEnumerable<Card> GetAll(List<Enums.CardEntities> includes)
        {
            int total = 0;
            IRepository<Card> repository = _unitOfWork.Repository<Card>();
            var query = repository.Query();
            foreach (var include in includes)
            {
                query = query.Include(AddInclude(include));

            }
            return query.Filter(c => c.Game.Name == "VS System").Get();
            //return _unitOfWork.Repository<Card>().Query().Include(p => p.CardRarity).Include(p => p.CardType).OrderBy(c => c.OrderBy(p => p.Name)).GetPage(1, 25, out total);
        }

        public override IEnumerable<Card> GetPage(IPager pager, List<Enums.CardEntities> includes)
        {
            int total = 0;
            IRepository<Card> repository = _unitOfWork.Repository<Card>();
            var query = repository.Query();
            foreach (var include in includes)
            {
                query = query.Include(AddInclude(include));

            }
            //return query.Filter(c => c.Game.Name == "VS System").Get();
            var results = query.OrderBy(c => c.OrderBy(p => p.Name)).GetPage(pager.CurrentPage, pager.NumberOfItemsPerPage, out total);
            pager.NumberOfItems = total;
            return results;
        }


        private Expression<Func<Card, object>> AddInclude(Enums.CardEntities entity)
        {
            throw new NotImplementedException("Enum Type unsupported: " + entity.ToString());
        }

        public override IEnumerable<Card> GetAllForDropdownList()
        {
            return AddSelectItem(GetAll(new List<Enums.CardEntities> { }), new Card { Id = 0, Name = "Select Card" });
        }


    }
}
