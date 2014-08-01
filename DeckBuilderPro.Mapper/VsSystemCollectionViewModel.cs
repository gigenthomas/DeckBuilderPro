using DeckBuilderPro.Entity.VsSystem;
using DeckBuilderPro.ViewModels.VsSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckBuilderPro.Mapper
{
    public class VsSystemCollectionViewModelMapper : BaseViewModelMapper<VsSystemCollection, VsSystemCollectionViewModel>
    {

        static VsSystemCollectionViewModelMapper()
        {
            AutoMapper.Mapper.CreateMap<VsSystemCard, VsSystemCardViewModel>();
            AutoMapper.Mapper.CreateMap<VsSystemCollectionCard, VsSystemCollectionCardViewModel>();
            AutoMapper.Mapper.CreateMap<VsSystemCollection, VsSystemCollectionViewModel>();
            AutoMapper.Mapper.CreateMap<VsSystemCardType, VsSystemCardTypeViewModel>();

        }

    }
}
