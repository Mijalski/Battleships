using System;
using Battleships.Business.Grids;
using Battleships.Factories.Ships;
using Battleships.IFactories.Grids;
using Battleships.IFactories.Ships;
using Battleships.IServices.Grids;

namespace Battleships.Factories.Grids
{
    public class GridFactory : IGridFactory
    {
        public const int DefaultGridSize = 10;
        public const int DefaultBattleshipsCount = 1;
        public const int DefaultDestroyersCount = 2;

        private readonly IShipFactory _shipFactory;
        private readonly IGridPlaceShipService _gridPlaceShipService;

        public GridFactory(IShipFactory shipFactory, 
            IGridPlaceShipService gridPlaceShipService)
        {
            _shipFactory = shipFactory;
            _gridPlaceShipService = gridPlaceShipService;
        }

        public Grid CreateGrid(int? gridSize = null, int? battleShipCount = null, int? destroyerCount = null)
        {
            var grid = new Grid(gridSize ?? DefaultGridSize);

            battleShipCount ??= DefaultBattleshipsCount;
            destroyerCount ??= DefaultDestroyersCount;

            var squaresTakenUpByShips = (battleShipCount * ShipFactory.DefaultBattleShipSize) + 
                                        (destroyerCount * ShipFactory.DefaultDestroyerSize);
            if (grid.GridSquares.Count <= squaresTakenUpByShips)
                throw new InvalidOperationException("Grid is too small to host specified ship amount");

            for (var i = 0; i < battleShipCount; i++)
            {
                var battleship = _shipFactory.CreateBattleship();
                _gridPlaceShipService.PlaceShip(grid, battleship);
            }

            for (var i = 0; i < destroyerCount; i++)
            {
                var destroyer = _shipFactory.CreateDestroyer();
                _gridPlaceShipService.PlaceShip(grid, destroyer);
            }

            return grid;
        }
    }
}