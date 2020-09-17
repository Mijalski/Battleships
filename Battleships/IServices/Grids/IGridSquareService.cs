using Battleships.Business.Grids;

namespace Battleships.IServices.Grids
{
    public interface IGridSquareService
    {
        GridSquare GetGridSquareById(Grid grid, string id);
    }
}