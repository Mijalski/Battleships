using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Battleships.Business.Battleships;
using Battleships.Helpers;

namespace Battleships.Business.Grids
{
    public class Grid
    {
        public readonly int RowCount;
        public readonly int ColumnCount;
        public List<GridSquare> GridSquares { get; private set; }
        public List<Ship> Ships { get; set; }

        public Grid(int rowCount, int columnCount)
        {
            if(rowCount <= 1 || columnCount <= 1) 
                throw new ArgumentException("Both grid dimensions have to be grater than 1");

            RowCount = rowCount;
            ColumnCount = columnCount;

            GridSquares = new List<GridSquare>();
            Ships = new List<Ship>();

            GenerateGridSquares();
        }

        public Grid(int gridSize) : this(gridSize, gridSize)
        {
        }

        private void GenerateGridSquares()
        {
            for (var x = 0; x < ColumnCount; x++)
            {
                for (var y = 0; y < RowCount; y++)
                {
                    GridSquares.Add(new GridSquare(x, y));
                }
            }
        }

        public void ShootGridSquare(GridSquare gridSquare)
        {
            gridSquare.GetShot();
        }

        private bool CheckIfHasAnyShipsLeft()
        {
            return Ships.Any(_ => _.IsDestroyed);
        }
    }
}