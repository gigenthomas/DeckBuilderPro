using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeckBuilderPro.ViewModels.Interfaces;
using DeckBuilderPro.Entity;
using IMapping;

namespace DeckBuilderPro.ViewModels.ViewModelsBuilders
{
    public class ManufacturerModelBuilder : IModelBuilder<Manufacturer, ManufacturerViewModel>
    {
        private readonly IMapper<Manufacturer, ManufacturerViewModel> _mapper;

        public ManufacturerModelBuilder(IMapper<Manufacturer, ManufacturerViewModel> mapper)
        {
            _mapper = mapper;
        }

        public ManufacturerViewModel CreateFrom(Manufacturer manufacturer)
        {
            ManufacturerViewModel viewModel = _mapper.Map(manufacturer);
            return viewModel;
        }

        public ManufacturerViewModel CreateFrom(Manufacturer manufacturer, int UserId)
        {
            ManufacturerViewModel viewModel = _mapper.Map(manufacturer);
            return viewModel;
        }

        public ManufacturerViewModel Rebuild(ManufacturerViewModel viewModel)
        {
            return viewModel;
        }

        public ManufacturerViewModel Rebuild(ManufacturerViewModel viewModel, int UserId)
        {
            return viewModel;
        }

        public IEnumerable<ManufacturerViewModel> CreateFrom(IEnumerable<Manufacturer> manufacturers)
        {
            var manufacturerViewModels = _mapper.Map(manufacturers);
            return manufacturerViewModels;
        }

        public IEnumerable<ManufacturerViewModel> CreateFrom(IEnumerable<Manufacturer> manufacturers, int UserId)
        {
            var manufacturerViewModels = _mapper.Map(manufacturers);
            return manufacturerViewModels;
        }
    }
}
