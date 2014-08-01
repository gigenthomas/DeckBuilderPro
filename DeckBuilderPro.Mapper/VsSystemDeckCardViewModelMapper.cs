using DeckBuilderPro.Entity.VsSystem;
using DeckBuilderPro.ViewModels.VsSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckBuilderPro.Mapper
{
    public class VsSystemDeckCardViewModelMapper : BaseViewModelMapper<VsSystemDeckCard, VsSystemDeckCardViewModel>
    {

        static VsSystemDeckCardViewModelMapper()
        {
            AutoMapper.Mapper.CreateMap<VsSystemCard, VsSystemCardViewModel>();
            AutoMapper.Mapper.CreateMap<VsSystemDeckCard, VsSystemDeckCardViewModel>();
            AutoMapper.Mapper.CreateMap<VsSystemDeckCardViewModel, VsSystemDeckCard>();
        }

    }
}
