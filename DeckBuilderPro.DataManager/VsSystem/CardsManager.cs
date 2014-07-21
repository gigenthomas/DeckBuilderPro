using DeckBuilderPro.DataManager.Interfaces.VsSystem;
using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VsSystemEntity = DeckBuilderPro.Entity.VsSystem;

namespace DeckBuilderPro.DataManager.VsSystem
{
    public class CardsManager : ICardsManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public CardsManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public VsSystemEntity.VsSystemCard LookupCard(string cardIdentifier)
        {
            var repository = _unitOfWork.Repository<VsSystemEntity.VsSystemCard>();
            var query = repository.Query();
            
            query = query.Filter(c => c.CardIdentifier.ToUpper() == cardIdentifier.ToUpper());
            var card = query.Get().FirstOrDefault();
            
            //var cardRepository = new DeckBuilderPro.DataManager.VsSystem_CardsDataManager(new Repository.UnitOfWork());
            //var card = cardRepository.GetAll(new List<Enums.VsSystem_CardEnities> { }).Where(c => c.CardIdentifier.ToUpper() == cardIdentifier.ToUpper() && c.GameId == gameId).FirstOrDefault();
            if (card == null)
            {
                throw new Exception("Invalid Card");
            }
            return card;
        }

        public ICollection<VsSystemEntity.VsSystemCard> TypeAheadByName(string name)
        {
            int total = 0;
            var repository = _unitOfWork.Repository<VsSystemEntity.VsSystemCard>();
            var query = repository.Query().Filter(c => c.Name.StartsWith(name)).OrderBy(c => c.OrderBy(p => p.Name)).Include(c => c.TeamAffiliations);
            return query.GetPage(1, 10, out total).ToList();        
        }

    }
}
