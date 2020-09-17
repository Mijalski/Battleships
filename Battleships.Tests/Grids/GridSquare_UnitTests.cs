using Battleships.Business.Grids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Battleships.Tests.Grids
{
    [TestClass]
    public class GridSquare_UnitTests
    {

        [DataTestMethod]
        [DataRow(0, 0, "A1")]
        [DataRow(1, 1, "B2")]
        [DataRow(2, 2, "C3")]
        [DataRow(26, 9, "AA10")]
        public void GridSquareCtor_Test_IdTest(int x, int y, string expectedId)
        {
            var gridSquare = new GridSquare(x, y);
            Assert.AreEqual(expectedId, gridSquare.Id);
        }

        [TestMethod]
        public void GridSquareCtor_Test_CoordinatesAssign()
        {
            var gridSquare = new GridSquare(1, 2);
            Assert.AreEqual(1, gridSquare.X);
            Assert.AreEqual(2, gridSquare.Y);
        }
    }
}