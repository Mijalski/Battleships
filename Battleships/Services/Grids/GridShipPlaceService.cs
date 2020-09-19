using System;
using System.Collections.Generic;
using System.Linq;
using Battleships.Business.Battleships;
using Battleships.Business.Grids;
using Battleships.Helpers;
using Battleships.IServices.Grids;

namespace Battleships.Services.Grids
{
    public class GridPlaceShipService : IGridPlaceShipService
    {
        public void PlaceShip(Grid grid, Ship ship)
        {
            var foundNonCollidingGridSquares = false;
            IEnumerable<GridSquare> gridSquaresToPlaceShipOn = null;

            while (!foundNonCollidingGridSquares)
            {
                var isDirectionVertical = RandomizeHelper.GetRandomBool();
                var canShipBePlacedVertically = grid.RowCount >= ship.Size;
                var canShipBePlacedHorizontally = grid.ColumnCount >= ship.Size;

                gridSquaresToPlaceShipOn = isDirectionVertical && canShipBePlacedVertically
                    ? PlaceShipVertically(grid, ship)
                    : canShipBePlacedHorizontally 
                        ? PlaceShipHorizontally(grid, ship) 
                        : throw new ArgumentException("Ship is too large to be placed on the grid");

                foundNonCollidingGridSquares = gridSquaresToPlaceShipOn.All(g => g.Ship == null);
            }

            ship.PlaceOnSquares(gridSquaresToPlaceShipOn.ToList());
            grid.Ships.Add(ship);
        }

        public static IEnumerable<GridSquare> PlaceShipVertically(Grid grid, Ship ship)
        {
            var lastPossibleRowIndex = GetLastPossibleIndexForAxis(grid.RowCount, ship.Size);
            var randomRowIndex = RandomizeHelper.GetRandomInt(lastPossibleRowIndex);
            var randomColumnIndex = RandomizeHelper.GetRandomInt(grid.ColumnCount);

            return GetGridSquaresToPlaceShipVertically(grid, ship, randomColumnIndex, randomRowIndex);
        }

        public static IEnumerable<GridSquare> PlaceShipHorizontally(Grid grid, Ship ship)
        {
            var lastPossibleColumnIndex = GetLastPossibleIndexForAxis(grid.ColumnCount, ship.Size);
            var randomColumnIndex = RandomizeHelper.GetRandomInt(lastPossibleColumnIndex);
            var randomRowIndex = RandomizeHelper.GetRandomInt(grid.RowCount);

            return GetGridSquaresToPlaceShipHorizontally(grid, ship, randomColumnIndex, randomRowIndex);
        }

        public static IEnumerable<GridSquare> GetGridSquaresToPlaceShipVertically(Grid grid, Ship ship, int randomColumnIndex, int randomRowIndex)
        {
            if(grid.ColumnCount <= randomColumnIndex)
                throw new ArgumentException("Grid column with specified index does not exist");
            if(grid.RowCount <= ship.Size + randomRowIndex)
                throw new ArgumentException("Grid row with specified index does not exist");

            return grid.GridSquares
                .Where(_ => _.X == randomColumnIndex
                            && _.Y >= randomRowIndex
                            && _.Y < randomRowIndex + ship.Size)
                .ToList();
        }

        public static IEnumerable<GridSquare> GetGridSquaresToPlaceShipHorizontally(Grid grid, Ship ship, int randomColumnIndex, int randomRowIndex)
        {
            if (grid.ColumnCount <= ship.Size + randomColumnIndex)
                throw new ArgumentException("Grid column with specified index does not exist");
            if (grid.RowCount <= randomRowIndex)
                throw new ArgumentException("Grid row with specified index does not exist");

            return grid.GridSquares
                .Where(_ => _.Y == randomRowIndex
                            && _.X >= randomColumnIndex
                            && _.X < randomColumnIndex + ship.Size)
                .ToList();
        }

        public static int GetLastPossibleIndexForAxis(int gridLengthOnAxis, int shipSize) => gridLengthOnAxis - shipSize;
    }
}