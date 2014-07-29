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
    public class VsSystemCollectionsManager : BaseDataManager<VsSystemCollection, Enums.VsSystemCollectionEntities>, IVsSystemCollectionsManager
    {
        private readonly IVsSystemCardsManager _cardManager;
        private readonly IVsSystemCollectionCardsManager _collectionCardsManager;

        public VsSystemCollectionsManager(IUnitOfWork unitOfWork, IVsSystemCardsManager cardManager, IVsSystemCollectionCardsManager collectionCardsManager)
            : base(unitOfWork)
        {
            _cardManager = cardManager;
            _collectionCardsManager = collectionCardsManager;
        }

        public int CheckCardsOutOfColection(int collectionId, int quantity, string cardIdentifier)
        {
            int cardsCheckedOut = 0;
            try
            {
                var collection = FindById(collectionId);
                var card = _cardManager.LookupCard(cardIdentifier);

                if (card == null)
                {
                    throw new Exception("Invalid Card");
                }

                VsSystemCollectionCard myCard = _collectionCardsManager.GetAll(new List<Enums.VsSystemCollectionCardEntities> { }).Where(c => c.CardId == card.Id && c.CollectionId == collectionId).FirstOrDefault();
                if ((myCard.CardCount - myCard.CardsInDecks) >= quantity)
                {
                    myCard.CardsInDecks += quantity;
                    cardsCheckedOut = quantity;
                }
                else
                {
                    cardsCheckedOut = (myCard.CardCount - myCard.CardsInDecks);
                    myCard.CardsInDecks += cardsCheckedOut;
                }
                _collectionCardsManager.Update(myCard);
                return cardsCheckedOut;

            }
            catch (Exception e)
            {
                return cardsCheckedOut;
            }
        }

        public bool AddCardsToCollection(int collectionId, int quantity, string cardIdentifier)
        {
            try
            {
                var collection = FindById(collectionId);
                var card = _cardManager.LookupCard(cardIdentifier);

                if (card == null)
                {
                    throw new Exception("Invalid Card");
                }

                VsSystemCollectionCard myCard = _collectionCardsManager.GetAll(new List<Enums.VsSystemCollectionCardEntities> { }).Where(c => c.CardId == card.Id && c.CollectionId == collectionId).FirstOrDefault();
                if (myCard == null)
                {
                    myCard = new VsSystemCollectionCard();
                    myCard.CardId = card.Id;
                    myCard.CollectionId = collectionId;
                    myCard.CardCount = quantity;
                    myCard.CardsInDecks = 0;
                    _collectionCardsManager.Create(myCard);

                }
                else
                {
                    myCard.CardCount = myCard.CardCount + quantity;
                    _collectionCardsManager.Update(myCard);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public override VsSystemCollection FindById(int id)
        {
            IRepository<VsSystemCollection> repository = _unitOfWork.Repository<VsSystemCollection>();
            var query = repository.Query();
            query = query.Include(e => e.CardsInCollection.Select(c => c.Card).Select(s => s.CardType));

            query = query.Filter(e => e.Id == id);
            return query.Get().FirstOrDefault();
            //            return _unitOfWork.Repository<Deck>().FindById(id);
        }

        public override IEnumerable<VsSystemCollection> GetAll(List<Enums.VsSystemCollectionEntities> includes = null)
        {
            includes = new List<Enums.VsSystemCollectionEntities> { };
            IRepository<VsSystemCollection> repository = _unitOfWork.Repository<VsSystemCollection>();
            var query = repository.Query();
            foreach (var include in includes)
            {
                query = query.Include(AddInclude(include));

            }

            Expression<Func<VsSystemCollection, bool>> expression;
            expression = e => e.UserId == 7;
            query = query.Filter(expression);

            return query.Get();
        }

        public override IEnumerable<VsSystemCollection> GetPage(IPager pager, List<Enums.VsSystemCollectionEntities> includes = null)
        {
            includes = new List<Enums.VsSystemCollectionEntities> { };
            int total = 0;
            IRepository<VsSystemCollection> repository = _unitOfWork.Repository<VsSystemCollection>();
            var query = repository.Query();
            foreach (var include in includes)
            {
                query = query.Include(AddInclude(include));

            }
            var results = query.OrderBy(c => c.OrderBy(p => p.Name)).GetPage(pager.CurrentPage, pager.NumberOfItemsPerPage, out total);
            pager.NumberOfItems = total;
            return results;
        }


        public override IEnumerable<VsSystemCollection> GetAllForDropdownList()
        {
            return AddSelectItem(GetAll(), new VsSystemCollection { Id = 0, Name = "Select Collection" });
        }

        public IEnumerable<VsSystemCollection> GetMyCollections(int id)
        {
            var repository = _unitOfWork.Repository<VsSystemCollection>();
            var query = repository.Query();
            query.Filter(c => c.UserId == id);
            var result = query.OrderBy(c => c.OrderBy(p => p.Name)).Get();
            return result;
        }

        private Expression<Func<VsSystemCollection, object>> AddInclude(Enums.VsSystemCollectionEntities entity)
        {
            throw new NotImplementedException("Enum Type unsupported: " + entity.ToString());
        }
    }
}

