using Battleships.Business.Grids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Battleships.Tests.Grids
{
    [TestClass]
    public class Grid_UnitTests
    {

        [TestMethod]
        public void GridCtor_Test_GridSize()
        {
            var grid = new Grid(10);
            Assert.AreEqual(grid.RowCount, 10);
            Assert.AreEqual(grid.ColumnCount, 10);
        }

        [TestMethod]
        public void GridCtor_Test_RowAndColumnSize()
        {
            var grid = new Grid(10,9);
            Assert.AreEqual(grid.RowCount, 10);
            Assert.AreEqual(grid.ColumnCount, 9);
        }

        [TestMethod]
        public void GridCtor_Test_GridSquaresCount()
        {
            var grid = new Grid(10);
            Assert.AreEqual(grid.GetGridSquaresCount(), 100);
        }
    }
}