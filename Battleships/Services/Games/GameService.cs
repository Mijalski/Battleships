using System.Linq;
using Battleships.Business.Grids;
using Battleships.IFactories.Grids;
using Battleships.IServices.Games;
using Battleships.IServices.Grids;
using Battleships.IServices.Inputs;

namespace Battleships.Services.Games
{
    public class GameService : IGameService
    {
        private readonly IGridFactory _gridFactory;
        private readonly IUIService _uiService;
        private readonly IGridSquareService _gridSquareService;

        public GameService(IGridFactory gridFactory, 
            IUIService uiService, 
            IGridSquareService gridSquareService)
        {
            _gridFactory = gridFactory;
            _uiService = uiService;
            _gridSquareService = gridSquareService;
        }

        public void PlayGame()
        {
            var grid = _gridFactory.CreateGrid();

            while (grid.Ships.Any(_ => !_.IsDestroyed))
            {
                _uiService.RefreshGrid(grid);

                GridSquare gridSquareSelected = null;
                while (gridSquareSelected == null)
                {
                    var gridSquareId = _uiService.GetGridSquareIdInput();
                    gridSquareSelected = _gridSquareService.GetGridSquareToBeShot(grid, gridSquareId);
                }

                grid.ShootGridSquare(gridSquareSelected);

                if (gridSquareSelected.Ship == null)
                    _uiService.NotifyAboutShotMissed();
                else
                    _uiService.NotifyAboutShotOnTarget();
            }
        }
    }
}