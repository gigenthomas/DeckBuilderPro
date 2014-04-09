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
    public class CardsDataManager : BaseDataManager<Card, Enums.CardEntities>
    {
        public CardsDataManager(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override IEnumerable<Card> GetAll(List<Enums.CardEntities> includes)
        {
            int total = 0;
            IRepository<Card> repository = _unitOfWork.Repository<Card>();
            var query = repository.Query();
            foreach(var include in includes)
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
            //Expression<Func<Card, object>> expression;
            //switch (entity)
            //{
            //    case Enums.CardEnities.CardType:
            //        {
            //            expression = p => p.CardType;
            //            return expression;
            //        }
            //    case Enums.CardEnities.CardRarity:
            //        {
            //            expression = p => p.CardRarity;
            //            return expression;
            //        }
            //    case Enums.CardEnities.Game:
            //        {
            //            expression = e => e.Game;
            //            return expression;
            //        }
            //    case Enums.CardEnities.GameSet:
            //        {
            //            expression = e => e.GameSets;
            //            return expression;
            //        }
            //    case Enums.CardEnities.CardText:
            //        {
            //            expression = e => e.CardText;
            //            return expression;
            //        }
            //    case Enums.CardEnities.TeamAffiliation:
            //        {
            //            expression = e => e.TeamAffiliations;
            //            return expression;
            //        }
            //}
            throw new NotImplementedException("Enum Type unsupported: " + entity.ToString());
        }

        public override IEnumerable<Card> GetAllForDropdownList()
        {
            return AddSelectItem(GetAll(new List<Enums.CardEntities> { }), new Card { Id = 0, Name = "Select Card" });
        }
    }
}
