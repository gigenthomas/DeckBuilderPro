using DeckBuilderPro.Entity;
using DeckBuilderPro.ViewModels;
using IMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckBuilderPro.Mapper
{
    public class DeckCardViewModelMapper : BaseViewModelMapper<DeckCard, DeckCardViewModel>
    {

        static DeckCardViewModelMapper()
        {
            AutoMapper.Mapper.CreateMap<VsSystem_Card, Card>();
            AutoMapper.Mapper.CreateMap<DeckCard, DeckCardViewModel>();
            AutoMapper.Mapper.CreateMap<DeckCardViewModel, DeckCard>();
        }

    }

}
