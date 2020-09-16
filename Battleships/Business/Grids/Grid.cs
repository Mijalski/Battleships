using System.Collections.Generic;

namespace Battleships.Business.Grids
{
    public class Grid
    {
        public readonly int RowCount;
        public readonly int ColumnCount;
        private List<GridSquare> _gridSquares;

        public Grid(int rowCount, int columnCount)
        {
            RowCount = rowCount;
            ColumnCount = columnCount;

            GenerateGridSquares();
        }

        public Grid(int gridSize) : this(gridSize, gridSize)
        {
        }

        private void GenerateGridSquares()
        {
            _gridSquares = new List<GridSquare>();
            for (var x = 0; x < ColumnCount; x++)
            {
                for (var y = 0; y < RowCount; y++)
                {
                    _gridSquares.Add(new GridSquare(x, y));
                }
            }
        }

        public int GetGridSquaresCount()
        {
            return _gridSquares.Count;
        }
    }
}