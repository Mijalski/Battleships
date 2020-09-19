using System;
using System.Linq;
using Battleships.Business.Battleships;
using Battleships.Business.Grids;
using Battleships.Helpers;
using Battleships.IServices.Grids;
using Battleships.Services.Grids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Battleships.Tests.Services.Grids
{
    [TestClass]
    public class GridPlaceShipService_UnitTests
    {
        private readonly IGridPlaceShipService _gridPlaceShipService;
        public GridPlaceShipService_UnitTests()
        {
            _gridPlaceShipService = new GridPlaceShipService();
        }

        [DataTestMethod]
        [DataRow(10, 10, 5)]
        [DataRow(3, 6, 5)]
        [DataRow(6, 3, 5)]
        public void GetLastPossibleIndexForAxis_Test_PlaceShip(int rowCount, int columnCount, int shipSize)
        {
            var grid = new Grid(rowCount, columnCount);
            var ship = new Ship(shipSize);
            _gridPlaceShipService.PlaceShip(grid, ship);
            Assert.IsTrue(grid.Ships.Any());
        }

        [TestMethod]
        [DataRow(3, 3, 5)]
        public void GetLastPossibleIndexForAxis_Test_PlaceShipException(int rowCount, int columnCount, int shipSize)
        {
            var grid = new Grid(rowCount, columnCount);
            var ship = new Ship(shipSize);
            Assert.ThrowsException<ArgumentException>(() => _gridPlaceShipService.PlaceShip(grid, ship));
        }

        [TestMethod]
        public void GetLastPossibleIndexForAxis_Test_Rows()
        {
            var grid = new Grid(10, 20);
            var ship = new Ship(5);
            Assert.AreEqual(5, GridPlaceShipService.GetLastPossibleIndexForAxis(grid.RowCount, ship.Size));
        }

        [TestMethod]
        public void GetLastPossibleIndexForAxis_Test_Columns()
        {
            var grid = new Grid(10, 20);
            var ship = new Ship(5);
            Assert.AreEqual(15, GridPlaceShipService.GetLastPossibleIndexForAxis(grid.ColumnCount, ship.Size));
        }

        [TestMethod]
        public void GetLastPossibleIndexForAxis_Test_ArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => new Grid(0));
        }

        [TestMethod]
        public void GetGridSquaresToPlaceShipVertically_Test_Count()
        {
            var grid = new Grid(10);
            var ship = new Ship(5);
            var squaresToPlaceShipOn = GridPlaceShipService.GetGridSquaresToPlaceShipVertically(grid, ship, 0, 0);
            Assert.AreEqual(5, squaresToPlaceShipOn.Count());
        }

        [TestMethod]
        public void GetGridSquaresToPlaceShipVertically_Test_Position()
        {
            var grid = new Grid(10);
            var ship = new Ship(5);
            var squaresToPlaceShipOn = GridPlaceShipService.GetGridSquaresToPlaceShipVertically(grid, ship, 0, 0);
            var centerSquare = squaresToPlaceShipOn.All(_ => _.X == 0);
            Assert.AreEqual(true, centerSquare);
        }

        [TestMethod]
        public void GetGridSquaresToPlaceShipVertically_Test_TooLongShip()
        {
            var grid = new Grid(10);
            var ship = new Ship(11);
            Assert.ThrowsException<ArgumentException>(() =>
                GridPlaceShipService.GetGridSquaresToPlaceShipVertically(grid, ship, 0, 0));
        }

        [TestMethod]
        public void GetGridSquaresToPlaceShipVertically_Test_IncorrectColumn()
        {
            var grid = new Grid(10);
            var ship = new Ship(5);
            Assert.ThrowsException<ArgumentException>(() =>
                GridPlaceShipService.GetGridSquaresToPlaceShipVertically(grid, ship, 10, 0));
        }

        [TestMethod]
        public void GetGridSquaresToPlaceShipVertically_Test_IncorrectRow()
        {
            var grid = new Grid(10);
            var ship = new Ship(5);
            Assert.ThrowsException<ArgumentException>(() =>
                GridPlaceShipService.GetGridSquaresToPlaceShipVertically(grid, ship, 0, 5));
        }


        [TestMethod]
        public void GetGridSquaresToPlaceShipHorizontally_Test_Count()
        {
            var grid = new Grid(10);
            var ship = new Ship(5);
            var squaresToPlaceShipOn = GridPlaceShipService.GetGridSquaresToPlaceShipHorizontally(grid, ship, 0, 0);
            Assert.AreEqual(5, squaresToPlaceShipOn.Count());
        }

        [TestMethod]
        public void GetGridSquaresToPlaceShipHorizontally_Test_Position()
        {
            var grid = new Grid(10);
            var ship = new Ship(5);
            var squaresToPlaceShipOn = GridPlaceShipService.GetGridSquaresToPlaceShipHorizontally(grid, ship, 0, 0);
            var centerSquare = squaresToPlaceShipOn.All(_ => _.Y == 0);
            Assert.AreEqual(true, centerSquare);
        }

        [TestMethod]
        public void GetGridSquaresToPlaceShipHorizontally_Test_TooLongShip()
        {
            var grid = new Grid(10);
            var ship = new Ship(11);
            Assert.ThrowsException<ArgumentException>(() =>
                GridPlaceShipService.GetGridSquaresToPlaceShipHorizontally(grid, ship, 0, 0));
        }

        [TestMethod]
        public void GetGridSquaresToPlaceShipHorizontally_Test_IncorrectColumn()
        {
            var grid = new Grid(10);
            var ship = new Ship(5);
            Assert.ThrowsException<ArgumentException>(() =>
                GridPlaceShipService.GetGridSquaresToPlaceShipHorizontally(grid, ship, 0, 10));
        }

        [TestMethod]
        public void GetGridSquaresToPlaceShipHorizontally_Test_IncorrectRow()
        {
            var grid = new Grid(10);
            var ship = new Ship(5);
            Assert.ThrowsException<ArgumentException>(() =>
                GridPlaceShipService.GetGridSquaresToPlaceShipHorizontally(grid, ship, 5, 0));
        }

    }
}