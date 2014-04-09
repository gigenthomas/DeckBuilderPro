using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeckBuilderPro.Entity;
using IRepository;
using System.Linq.Expressions;
using Enums = DeckBuilderPro.Entity.Enums;
using DeckBuilderPro.Pager.Interfaces;

namespace DeckBuilderPro.DataManager
{
    public class VsSystem_CardsDataManager : BaseDataManager<VsSystem_Card, Enums.VsSystem_CardEnities>
    {

        public VsSystem_CardsDataManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override IEnumerable<VsSystem_Card> GetAll(List<Enums.VsSystem_CardEnities> includes)
        {
            int total = 0;
            IRepository<VsSystem_Card> repository = _unitOfWork.Repository<VsSystem_Card>();
            var query = repository.Query();
            foreach(var include in includes)
            {
             query = query.Include(AddInclude(include));
               
            }
            return query.Filter(c => c.Game.Name == "VS System").Get();
            //return _unitOfWork.Repository<VsSystem_Card>().Query().Include(p => p.CardRarity).Include(p => p.CardType).OrderBy(c => c.OrderBy(p => p.Name)).GetPage(1, 25, out total);
        }

        public override IEnumerable<VsSystem_Card> GetPage(IPager pager, List<Enums.VsSystem_CardEnities> includes)
        {
            int total = 0;
            IRepository<VsSystem_Card> repository = _unitOfWork.Repository<VsSystem_Card>();
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


        private Expression<Func<VsSystem_Card, object>> AddInclude(Enums.VsSystem_CardEnities entity)
        {
            Expression<Func<VsSystem_Card, object>> expression;
            switch (entity)
            {
                case Enums.VsSystem_CardEnities.CardType:
                    {
                        expression = p => p.CardType;
                        return expression;
                    }
                case Enums.VsSystem_CardEnities.CardRarity:
                    {
                        expression = p => p.CardRarity;
                        return expression;
                    }
                case Enums.VsSystem_CardEnities.Game:
                    {
                        expression = e => e.Game;
                        return expression;
                    }
                case Enums.VsSystem_CardEnities.GameSet:
                    {
                        expression = e => e.GameSets;
                        return expression;
                    }
                case Enums.VsSystem_CardEnities.VsSystem_CardText:
                    {
                        expression = e => e.VsSystem_CardText;
                        return expression;
                    }
                case Enums.VsSystem_CardEnities.VsSystem_TeamAffiliation:
                    {
                        expression = e => e.VsSystem_TeamAffiliations;
                        return expression;
                    }
            }
            throw new NotImplementedException("Enum Type unsupported: " + entity.ToString());
        }
        //public override VsSystem_Card FindById(int id)
        //{
        //    return _unitOfWork.Repository<VsSystem_Card>().FindById(id);
        //}

        public override IEnumerable<VsSystem_Card> GetAllForDropdownList()
        {
            return AddSelectItem(GetAll(new List<Enums.VsSystem_CardEnities> { }), new VsSystem_Card { Id = 0, Name = "Select Card" });
        }
    }
}
