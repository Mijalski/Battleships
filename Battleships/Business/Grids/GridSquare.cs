using System.Collections.Generic;
using Battleships.Business.Battleships;
using Battleships.Helpers;

namespace Battleships.Business.Grids
{
    public class GridSquare
    {
        public readonly string Id;
        public readonly int X;
        public readonly int Y;
        public Ship Ship { get; set; }

        public GridSquare(int x, int y)
        {
            X = x;
            Y = y;
            Id = $"{x.GetColumnName()}{y.GetRowName()}";
        }
    }
}