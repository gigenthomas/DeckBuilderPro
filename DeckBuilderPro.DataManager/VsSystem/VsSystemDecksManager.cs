using DeckBuilderPro.DataManager.Interfaces.VsSystem;
using DeckBuilderPro.Entity.VsSystem;
using DeckBuilderPro.Pager.Interfaces;
using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enums = DeckBuilderPro.Entity.Enums;

namespace DeckBuilderPro.DataManager.VsSystem
{
    public class VsSystemDecksManager : BaseDataManager<VsSystemDeck, Enums.VsSystemDeckEntities>, IVsSystemDecksManager
    {
        private readonly IVsSystemCardsManager _cardManager;

        public VsSystemDecksManager(IUnitOfWork unitOfWork, IVsSystemCardsManager cardManager)
            : base(unitOfWork)
        {
            _cardManager = cardManager;
        }

        public VsSystemDeckCard AddCardsToDeck(string cardIdentifier, int deckId, int quantity, int quantityFromCollection)
        {
            try
            {
                var deckRepository = _unitOfWork.Repository<VsSystemDeck>();
                var deck = deckRepository.FindById(deckId);
                if (deck == null)
                {
                    throw new NullReferenceException("Deck Not Found");
                }

                var card = _cardManager.LookupCard(cardIdentifier);

                var deckCardRepository = _unitOfWork.Repository<VsSystemDeckCard>();
                VsSystemDeckCard myDCard = deckCardRepository.Query().Filter(c => c.CardId == card.Id && c.DeckId == deckId).Get().FirstOrDefault();
                if (myDCard == null)
                {
                    myDCard = new VsSystemDeckCard();
                    myDCard.CardId = card.Id;
                    myDCard.DeckId = deckId;
                    myDCard.CardCount = quantity;
                    myDCard.CardsFromCollection = quantityFromCollection;
                    deckCardRepository.Insert(myDCard);
                    deck.CardCount += quantity;
                    deckRepository.Update(deck);
                    _unitOfWork.Commit();
                    myDCard = deckCardRepository.FindById(myDCard.Id);
                }
                else
                {
                    myDCard.CardCount += quantity;
                    myDCard.CardsFromCollection += quantityFromCollection;
                    deck.CardCount += quantity;
                    deckCardRepository.Update(myDCard);
                    deckRepository.Update(deck);
                    _unitOfWork.Commit();
                }
                return myDCard;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool UpdateCardInDeck(string cardIdentifier, int deckId, int quantity, int quantityFromCollection)
        {
            try
            {
                var deckRepository = _unitOfWork.Repository<VsSystemDeck>();
                var deck = deckRepository.FindById(deckId);
                if (deck == null)
                {
                    throw new NullReferenceException("Deck Not Found");
                }
                var card = _cardManager.LookupCard(cardIdentifier);

                if (card == null)
                {
                    throw new Exception("Invalid Card");
                }

                var deckCardRepository = _unitOfWork.Repository<VsSystemDeckCard>();

                VsSystemDeckCard myDCard = deckCardRepository.Query().Filter(c => c.CardId == card.Id && c.DeckId == deckId).Get().FirstOrDefault();
                if (myDCard == null)
                {
                    throw new NullReferenceException("Card Not Found");
                }
                else
                {

                    deck.CardCount -= myDCard.CardCount;
                    myDCard.CardCount = quantity;
                    deck.CardCount += quantity;
                    myDCard.CardsFromCollection = quantityFromCollection;
                    deckCardRepository.Update(myDCard);
                    deckRepository.Update(deck);
                    _unitOfWork.Commit();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteCardFromDeck(int deckCardId)
        {
            try
            {
                var deckCardRepository = _unitOfWork.Repository<VsSystemDeckCard>();

                VsSystemDeckCard myDCard = deckCardRepository.Query().Filter(c => c.Id == deckCardId).Get().FirstOrDefault();
                if (myDCard == null)
                {
                }
                else
                {
                    var deckRepository = _unitOfWork.Repository<VsSystemDeck>();
                    var deck = deckRepository.FindById(myDCard.DeckId);
                    if (deck == null)
                    {
                        throw new NullReferenceException("Deck Not Found");
                    }
                    deck.CardCount -= myDCard.CardCount;
                    deckCardRepository.Delete(deckCardId);
                    deckRepository.Update(deck);
                    _unitOfWork.Commit();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public int UpdateDeckCount(int deckId)
        {
            var repository = _unitOfWork.Repository<VsSystemDeck>();
            var deck = repository.FindById(deckId);
            deck.CardCount = deck.CardsInDeck.Sum(cid => cid.CardCount);
            repository.Update(deck);
            _unitOfWork.Commit();
            return deck.CardCount;
        }

        public IEnumerable<Entity.VsSystem.VsSystemCard> TypeAhead(string name)
        {
            return _cardManager.TypeAheadByName(name);
        }

        public IEnumerable<VsSystemDeck> GetAll()
        {
            var repository = _unitOfWork.Repository<VsSystemDeck>();
            return repository.Query().Get();
        }


        public override VsSystemDeck FindById(int id)
        {
            IRepository<VsSystemDeck> repository = _unitOfWork.Repository<VsSystemDeck>();
            var query = repository.Query();
            query = query.Include(e => e.CardsInDeck.Select(c => c.Card).Select(s => s.CardType));

            query = query.Filter(e => e.Id == id);
            return query.Get().FirstOrDefault();
            //            return _unitOfWork.Repository<Deck>().FindById(id);
        }

        public override IEnumerable<VsSystemDeck> GetAll(List<Enums.VsSystemDeckEntities> includes)
        {
            IRepository<VsSystemDeck> repository = _unitOfWork.Repository<VsSystemDeck>();
            var query = repository.Query();

            //foreach (var include in includes)
            //{
            //    query = query.Include(AddInclude(include));

            //}
            return query.Get();
        }

        public override IEnumerable<VsSystemDeck> GetPage(IPager pager, List<Enums.VsSystemDeckEntities> includes)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<VsSystemDeck> GetAllForDropdownList()
        {
            return AddSelectItem(GetAll(new List<Enums.VsSystemDeckEntities> { }), new VsSystemDeck { Id = 0, Name = "Select Deck" });
        }




    }
}
