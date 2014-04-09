using AutoMapper;
using DeckBuilderPro.Entity;
using DeckBuilderPro.ViewModels;
using IMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeckBuilderPro.Mapper
{
    public class DeckViewModelMapper : BaseViewModelMapper<Deck, DeckViewModel>
    {

        static DeckViewModelMapper()
        {
            AutoMapper.Mapper.CreateMap<VsSystem_Card, CardViewModel>();
            AutoMapper.Mapper.CreateMap<DeckCard, DeckCardViewModel>()
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.CardCount))
                .ForMember(dest => dest.QuantityFromCollection, opt => opt.MapFrom(src => src.CardsFromCollection));
            AutoMapper.Mapper.CreateMap<Deck, DeckViewModel>();
            AutoMapper.Mapper.CreateMap<CardType, CardTypeViewModel>();

            AutoMapper.Mapper.CreateMap<DeckViewModel, Deck>();        
        }
    }
}
