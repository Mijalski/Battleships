using Battleships.Business.Grids;

namespace Battleships.IFactories.Grids
{
    public interface IGridFactory
    {
        Grid CreateGrid(int? gridSize = null, int? battleShipCount = null, int? destroyerCount = null);
    }
}