using System.Linq;
using Battleships.Business.Grids;
using Battleships.IServices.Grids;

namespace Battleships.Services.Grids
{
    public class GridSquareService : IGridSquareService
    {
        public GridSquare GetGridSquareToBeShot(Grid grid, string id)
        {
            return grid.GridSquares.FirstOrDefault(_ => _.Id == id && !_.WasShot);
        }
    }
}