using Battleships.Business.Battleships;
using Battleships.IFactories.Ships;

namespace Battleships.Factories.Ships
{
    public class ShipFactory : IShipFactory
    {
        public const int DefaultBattleShipSize = 5;
        public const int DefaultDestroyerSize = 4;

        public Ship CreateBattleship()
        {
            return new Ship(DefaultBattleShipSize);
        }

        public Ship CreateDestroyer()
        {
            return new Ship(DefaultDestroyerSize);
        }
    }
}