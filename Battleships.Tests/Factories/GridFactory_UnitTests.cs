using System;
using Battleships.Factories.Grids;
using Battleships.Factories.Ships;
using Battleships.IFactories.Grids;
using Battleships.Services.Grids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Battleships.Tests.Factories
{
    [TestClass]
    public class GridFactory_UnitTests
    {
        private readonly IGridFactory _gridFactory;

        public GridFactory_UnitTests()
        {
            _gridFactory = new GridFactory(new ShipFactory(), new GridPlaceShipService());
        }

        [DataTestMethod]
        [DataRow(10, 5, 4, 9)]
        public void GridCtor_Test_ShipsCount(int gridSize, int battleShipCount, int destroyerCount, int overallShipCount)
        {
            var grid = _gridFactory.CreateGrid(gridSize, battleShipCount, destroyerCount);
            Assert.AreEqual(overallShipCount, grid.Ships.Count);
        }

        [DataTestMethod]
        [DataRow(4, 5, 5)]
        public void GridCtor_Test_ThrowException(int gridSize, int battleShipCount, int destroyerCount)
        {
            Assert.ThrowsException<InvalidOperationException>(() => _gridFactory.CreateGrid(gridSize, battleShipCount, destroyerCount));
        }
    }
}