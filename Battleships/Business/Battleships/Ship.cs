using System;
using System.Collections.Generic;
using System.Linq;
using Battleships.Business.Grids;

namespace Battleships.Business.Battleships
{
    public class Ship
    {
        private readonly Grid _grid;
        public List<GridSquare> GridSquares { get; private set; }
        private bool _isDestroyed;
        public readonly int Size;

        public Ship(int size)
        {
            Size = size;
            _isDestroyed = false;
            GridSquares = new List<GridSquare>();
        }

        public void PlaceOnSquares(List<GridSquare> gridSquaresToPlaceOn)
        {
            if(GridSquares.Any())
                throw new InvalidOperationException("Ship already has grid squares assigned");

            if(gridSquaresToPlaceOn.Count != Size)
                throw new ArgumentException("Grid squares count has to be equal to the size of the ship");

            GridSquares = gridSquaresToPlaceOn;
        }
    }
}