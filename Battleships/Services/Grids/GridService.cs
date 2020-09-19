using System.Linq;
using Battleships.Business.Grids;
using Battleships.IServices.Grids;

namespace Battleships.Services.Grids
{
    public class GridService : IGridService
    {
        public bool CheckIfGameIsFinished(Grid grid)
        {
            return grid.Ships.All(_ => _.IsDestroyed);
        }
    }
}