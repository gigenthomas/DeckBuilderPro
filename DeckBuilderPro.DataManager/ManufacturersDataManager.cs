using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeckBuilderPro.Entity;
using IRepository;
using Enums = DeckBuilderPro.Entity.Enums;
using DeckBuilderPro.Pager.Interfaces;
using System.Linq.Expressions;

namespace DeckBuilderPro.DataManager
{
    public class ManufacturersDataManager : BaseDataManager<Manufacturer, Enums.ManufactuerEnities>
    {
        private List<Enums.ManufactuerEnities> includeList = new List<Enums.ManufactuerEnities> { };

        public ManufacturersDataManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            //_unitOfWork = unitOfWork;
        }

        public override IEnumerable<Manufacturer> GetAll(List<Enums.ManufactuerEnities> include = null)
        {
            return _unitOfWork.Repository<Manufacturer>().Query().Get();
        }

        public override IEnumerable<Manufacturer> GetPage(IPager pager, List<Enums.ManufactuerEnities> includes)
        {
            int total = 0;
            IRepository<Manufacturer> repository = _unitOfWork.Repository<Manufacturer>();
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

        public override IEnumerable<Manufacturer> GetAllForDropdownList()
        {
            return AddSelectItem(GetAll(), new Manufacturer { Id = 0, Name = "Select Manufacturer" });
        }

        private Expression<Func<Manufacturer, object>> AddInclude(Enums.ManufactuerEnities entity)
        {
            Expression<Func<Manufacturer, object>> expression;
            switch (entity)
            {
                //case Enums.ManufactuerEnities.CardRarity:
                //    {
                //        expression = e => e.Manufacturer;
                //        return expression;
                //    }
            }
            throw new NotImplementedException("Enum Type unsupported: " + entity.ToString());
        }
    }
}
