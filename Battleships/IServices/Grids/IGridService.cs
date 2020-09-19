using Battleships.Business.Grids;

namespace Battleships.IServices.Grids
{
    public interface IGridService
    {
        bool CheckIfGameIsFinished(Grid grid);
    }
}