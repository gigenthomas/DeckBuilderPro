
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeckBuilderPro.Entity;
using IRepository;
using Enums = DeckBuilderPro.Entity.Enums;
using System.Linq.Expressions;
using DeckBuilderPro.Pager.Interfaces;

namespace DeckBuilderPro.DataManager
{
    public class GamesDataManager : BaseDataManager<Game, Enums.GameEnities>
    {
        
        public GamesDataManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public override IEnumerable<Game> GetAll(List<Enums.GameEnities> includes = null)
        {
            includes = new List<Enums.GameEnities> { };
            IRepository<Game> repository = _unitOfWork.Repository<Game>();
            var query = repository.Query();
            foreach (var include in includes)
            {
                query = query.Include(AddInclude(include));

            }
            return query.Get();
        }

        private Expression<Func<Game, object>> AddInclude(Enums.GameEnities entity)
        {
            Expression<Func<Game, object>> expression;
            switch (entity)
            {
                case Enums.GameEnities.Manufacturer:
                    {
                        expression = e => e.Manufacturer;
                        return expression;
                    }
            }
            throw new NotImplementedException("Enum Type unsupported: " + entity.ToString());
        }

        public override IEnumerable<Game> GetPage(IPager pager, List<Enums.GameEnities> includes)
        {
            int total = 0;
            IRepository<Game> repository = _unitOfWork.Repository<Game>();
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

        public override IEnumerable<Game> GetAllForDropdownList()
        {
            return AddSelectItem(GetAll(), new Game { Id = 0, Name = "Select Game" });
        }
    }
}