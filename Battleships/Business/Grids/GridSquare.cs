using System.Linq;
using Battleships.Business.Battleships;
using Battleships.Helpers;

namespace Battleships.Business.Grids
{
    public class GridSquare
    {
        public readonly string Id;
        public readonly int X;
        public readonly int Y;
        public bool WasShot { get; private set; }
        public Ship Ship { get; private set; }

        public GridSquare(int x, int y)
        {
            X = x;
            Y = y;
            Id = $"{x.GetColumnName()}{y.GetRowName()}";
        }

        public void PlaceShip(Ship ship)
        {
            Ship = ship;
        }

        public void GetShot()
        {
            WasShot = true;
            Ship?.GetShot();
        }
    }
}