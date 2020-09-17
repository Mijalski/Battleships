using Battleships.IFactories.Grids;
using Battleships.IServices.Games;

namespace Battleships.Services.Games
{
    public class GameService : IGameService
    {
        private readonly IGridFactory _gridFactory;
        public GameService(IGridFactory gridFactory)
        {
            _gridFactory = gridFactory;
        }

        public void PlayGame()
        {
            var grid = _gridFactory.CreateGrid();
        }
    }
}