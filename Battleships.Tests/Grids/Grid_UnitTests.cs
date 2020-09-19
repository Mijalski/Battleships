using System;
using System.Linq;
using Battleships.Business.Battleships;
using Battleships.Business.Grids;
using Battleships.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Battleships.Tests.Grids
{
    [TestClass]
    public class Grid_UnitTests
    {
        [DataTestMethod]
        [DataRow(10)]
        [DataRow(2)]
        public void GridCtor_Test_GridSize(int gridSize)
        {
            var grid = new Grid(gridSize);
            Assert.AreEqual(gridSize, grid.RowCount);
            Assert.AreEqual(gridSize, grid.ColumnCount);
        }

        [TestMethod]
        public void GetColumnName_Test_ArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => new Grid(1));
        }

        [DataTestMethod]
        [DataRow(2, 4)]
        [DataRow(5, 25)]
        [DataRow(10, 100)]
        public void GridCtor_Test_GridSquaresCount(int gridSize, int gridSquaresCount)
        {
            var grid = new Grid(gridSize);
            Assert.AreEqual(gridSquaresCount, grid.GridSquares.Count);
        }

        [DataTestMethod]
        public void GridShootSquare_Test()
        {
            var grid = new Grid(10);
            var squareToShoot = grid.GridSquares.First(_ => _.Id == "A1");
            grid.ShootGridSquare(squareToShoot);
            Assert.IsTrue(squareToShoot.WasShot);
        }

        [DataTestMethod]
        public void GridShootSquare_Test_TestOther()
        {
            var grid = new Grid(10);
            var squareToShoot = grid.GridSquares.First(_ => _.Id == "A1");
            grid.ShootGridSquare(squareToShoot);
            var squareNotShot = grid.GridSquares.First(_ => _.Id == "B1");
            Assert.IsFalse(squareNotShot.WasShot);
        }
    }
}