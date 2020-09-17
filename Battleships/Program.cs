using System;
using Battleships.Business.Grids;
using Battleships.Factories.Grids;
using Battleships.Factories.Ships;
using Battleships.IFactories.Grids;
using Battleships.IFactories.Ships;
using Battleships.IServices.Games;
using Battleships.IServices.Grids;
using Battleships.Services.Games;
using Battleships.Services.Grids;
using Microsoft.Extensions.DependencyInjection;

namespace Battleships
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IGridPlaceShipService, GridPlaceShipService>()
                .AddSingleton<IShipFactory, ShipFactory>()
                .AddSingleton<IGridFactory, GridFactory>()
                .AddSingleton<IGameService, GameService>()
                .BuildServiceProvider();

            var gameService = (IGameService)serviceProvider.GetService(typeof(IGameService));
            gameService.PlayGame();
        }
    }
}
