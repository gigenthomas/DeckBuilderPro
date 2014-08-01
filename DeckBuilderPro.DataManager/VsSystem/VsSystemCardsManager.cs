using DeckBuilderPro.DataManager.Interfaces.VsSystem;
using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VsSystemEntity = DeckBuilderPro.Entity.VsSystem;

namespace DeckBuilderPro.DataManager.VsSystem
{
    public class VsSystemCardsManager : IVsSystemCardsManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public VsSystemCardsManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public VsSystemEntity.VsSystemCard LookupCard(string cardIdentifier)
        {
            var repository = _unitOfWork.Repository<VsSystemEntity.VsSystemCard>();
            var query = repository.Query();
            
            query = query.Filter(c => c.CardIdentifier.ToUpper() == cardIdentifier.ToUpper()).Include(c => c.CardText);
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
            var query = repository.Query().Filter(c => c.Name.StartsWith(name)).OrderBy(c => c.OrderBy(p => p.Name)).Include(c => c.TeamAffiliations).Include(c => c.CardType)
                .Include(c=> c.CardRarity).Include(c => c.CardText);
            return query.GetPage(1, 10, out total).ToList();        
        }

    }
}
