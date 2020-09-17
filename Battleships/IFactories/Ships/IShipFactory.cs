using Battleships.Business.Battleships;

namespace Battleships.IFactories.Ships
{
    public interface IShipFactory
    {
        Ship CreateBattleship();
        Ship CreateDestroyer();
    }
}