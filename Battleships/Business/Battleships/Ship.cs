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
        public bool IsDestroyed { get; private set; }
        public readonly int Size;

        public Ship(int size)
        {
            Size = size;
            IsDestroyed = false;
            GridSquares = new List<GridSquare>();
        }

        public void PlaceOnSquares(List<GridSquare> gridSquaresToPlaceOn)
        {
            if(GridSquares.Any())
                throw new InvalidOperationException("Ship already has grid squares assigned");

            foreach (var gridSquare in gridSquaresToPlaceOn)
            {
                gridSquare.PlaceShip(this);
            }

            GridSquares = gridSquaresToPlaceOn;
        }

        public void GetShot()
        {
            if (GridSquares.All(_ => _.WasShot))
            {
                IsDestroyed = true;
            }
        }
    }
}