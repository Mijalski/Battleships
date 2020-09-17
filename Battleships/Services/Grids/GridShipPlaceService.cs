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
            var isDirectionVertical = RandomizeHelper.GetRandomBool();

            if (isDirectionVertical)
            {
                PlaceShipVertically(grid, ship);
            }
            else
            {
                PlaceShipHorizontally(grid, ship);
            }

            grid.Ships.Add(ship);
        }

        public static void PlaceShipVertically(Grid grid, Ship ship)
        {
            var lastPossibleRowIndex = GetLastPossibleIndexForAxis(grid.RowCount, ship.Size);
            var randomRowIndex = RandomizeHelper.GetRandomInt(lastPossibleRowIndex);
            var randomColumnIndex = RandomizeHelper.GetRandomInt(grid.ColumnCount);

            var gridSquaresToPlaceShipOn = GetGridSquaresToPlaceShipVertically(grid, ship, randomColumnIndex, randomRowIndex)
                .ToList();
            ship.PlaceOnSquares(gridSquaresToPlaceShipOn);
        }

        public static void PlaceShipHorizontally(Grid grid, Ship ship)
        {
            var lastPossibleColumnIndex = GetLastPossibleIndexForAxis(grid.RowCount, ship.Size);
            var randomColumnIndex = RandomizeHelper.GetRandomInt(lastPossibleColumnIndex);
            var randomRowIndex = RandomizeHelper.GetRandomInt(grid.ColumnCount);

            var gridSquaresToPlaceShipOn = GetGridSquaresToPlaceShipHorizontally(grid, ship, randomColumnIndex, randomRowIndex)
                .ToList();
            ship.PlaceOnSquares(gridSquaresToPlaceShipOn);
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