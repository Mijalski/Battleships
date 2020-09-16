using System.Collections.Generic;
using Battleships.Business.Grids;

namespace Battleships.Business.Battleships
{
    public class Battleship
    {
        private readonly Grid _grid;
        private readonly List<GridSquare> _gridSquares;
        private bool _isDestroyed;

        public Battleship(Grid grid, List<GridSquare> gridSquares)
        {
            _grid = grid;
            _gridSquares = gridSquares;
            _isDestroyed = false;
        }
    }
}