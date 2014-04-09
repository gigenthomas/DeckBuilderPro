using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeckBuilderPro.ViewModels.Interfaces;
using DeckBuilderPro.DataManager.Interfaces;
using DeckBuilderPro.Entity;
using IMapping;
using Enums = DeckBuilderPro.Entity.Enums;

namespace DeckBuilderPro.ViewModels.ViewModelsBuilders
{
    public class GameModelBuilder : IModelBuilder<Game, GameViewModel>
    {
        private readonly IDataManager<Manufacturer, Enums.ManufactuerEnities> _manufacturersManager;
        private readonly IMapper<Game, GameViewModel> _mapper;

        public GameModelBuilder(IDataManager<Manufacturer, Enums.ManufactuerEnities> manufacturersManager, IMapper<Game, GameViewModel> mapper)
        {
            _manufacturersManager = manufacturersManager;
            _mapper = mapper;
        }

        public GameViewModel CreateFrom(Game game)
        {
            GameViewModel viewModel = _mapper.Map(game);
            viewModel.Manufacturers = _manufacturersManager.GetAllForDropdownList();
            return viewModel;
        }

        public GameViewModel CreateFrom(Game game, int UserId)
        {
            GameViewModel viewModel = _mapper.Map(game);
            viewModel.Manufacturers = _manufacturersManager.GetAllForDropdownList();
            return viewModel;
        }

        public GameViewModel Rebuild(GameViewModel viewModel)
        {
            viewModel.Manufacturers = _manufacturersManager.GetAllForDropdownList();
            return viewModel;
        }

        public GameViewModel Rebuild(GameViewModel viewModel, int UserId)
        {
            viewModel.Manufacturers = _manufacturersManager.GetAllForDropdownList();
            return viewModel;
        }

        public IEnumerable<GameViewModel> CreateFrom(IEnumerable<Game> games)
        {
            return _mapper.Map(games);
        }

        public IEnumerable<GameViewModel> CreateFrom(IEnumerable<Game> games, int UserId)
        {
            return _mapper.Map(games);
        }
    }
}
