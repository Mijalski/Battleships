using Battleships.Business.Grids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Battleships.Tests.Grids
{
    [TestClass]
    public class GridSquare_UnitTests
    {

        [TestMethod]
        public void GridSquareCtor_Test_IdTest()
        {
            var gridSquare = new GridSquare(0,0);
            Assert.AreEqual("A1", gridSquare.Id);
        }

        [TestMethod]
        public void GridSquareCtor_Test_IdTestLong()
        {
            var gridSquare = new GridSquare(26, 9);
            Assert.AreEqual("AA10", gridSquare.Id);
        }
    }
}