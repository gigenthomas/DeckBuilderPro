using DeckBuilderPro.Entity;
using DeckBuilderPro.Mapper;
using DeckBuilderPro.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MappingConfiguration
{
    public class DeckConfiguration : ViewModelMapper<Deck, DeckViewModel>
    {
        static override ViewModelMapper()
        {

        }
    }
}
