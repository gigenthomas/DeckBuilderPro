using DeckBuilderPro.Entity.VsSystem;
using DeckBuilderPro.ViewModels.VsSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckBuilderPro.Mapper
{
    public class VsSystemCardViewModelMapper : BaseViewModelMapper<VsSystemCard, VsSystemCardViewModel>
    {
        static VsSystemCardViewModelMapper()
        {
            AutoMapper.Mapper.CreateMap<VsSystemCard, VsSystemCardViewModel>();
            AutoMapper.Mapper.CreateMap<VsSystemTeamAffiliation, VsSystemTeamAffiliationViewModel>();
            AutoMapper.Mapper.CreateMap<VsSystemCardType, VsSystemCardTypeViewModel>();
            AutoMapper.Mapper.CreateMap<VsSystemCardRarity, VsSystemCardRarityViewModel>();
            AutoMapper.Mapper.CreateMap<VsSystemCardText, VsSystemCardTextViewModel>();
        }
    }
}
