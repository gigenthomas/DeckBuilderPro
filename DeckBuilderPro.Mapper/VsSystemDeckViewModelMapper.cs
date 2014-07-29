using DeckBuilderPro.Entity.VsSystem;
using DeckBuilderPro.ViewModels.VsSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckBuilderPro.Mapper
{
    public class VsSystemDeckViewModelMapper : BaseViewModelMapper<VsSystemDeck, VsSystemDeckViewModel>
    {

        static VsSystemDeckViewModelMapper()
        {
            AutoMapper.Mapper.CreateMap<VsSystemDeckViewModel, VsSystemDeck>();
            AutoMapper.Mapper.CreateMap<VsSystemCard, VsSystemCardViewModel>();
            AutoMapper.Mapper.CreateMap<VsSystemDeckCard, VsSystemDeckCardViewModel>()
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.CardCount))
                .ForMember(dest => dest.QuantityFromCollection, opt => opt.MapFrom(src => src.CardsFromCollection));
            AutoMapper.Mapper.CreateMap<VsSystemDeck, VsSystemDeckViewModel>();
            AutoMapper.Mapper.CreateMap<VsSystemCardType, VsSystemCardTypeViewModel>();

        }
    }
}
