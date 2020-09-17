using Battleships.Business.Battleships;
using Battleships.Business.Grids;

namespace Battleships.IServices.Grids
{
    public interface IGridPlaceShipService
    {
        void PlaceShip(Grid grid, Ship ship);
    }
}