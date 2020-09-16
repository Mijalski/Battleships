using System.Collections.Generic;
using Battleships.Business.Battleships;
using Battleships.Helpers;

namespace Battleships.Business.Grids
{
    public class GridSquare
    {
        public readonly string Id;

        public GridSquare(int x, int y)
        {
            Id = $"{x.GetColumnName()}{y.GetRowName()}";
        }
    }
}