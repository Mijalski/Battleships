using Battleships.Business.Grids;

namespace Battleships.IServices.Grids
{
    public interface IGridSquareService
    {
        GridSquare GetGridSquareToBeShot(Grid grid, string id);
    }
}