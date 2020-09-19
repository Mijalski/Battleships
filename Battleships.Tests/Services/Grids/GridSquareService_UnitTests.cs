using System.Linq;
using Battleships.Business.Battleships;
using Battleships.Business.Grids;
using Battleships.IServices.Grids;
using Battleships.Services.Grids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Battleships.Tests.Services.Grids
{
    [TestClass]
    public class GridSquareService_UnitTests
    {
        private readonly IGridSquareService _gridSquareService;

        public GridSquareService_UnitTests()
        {
            _gridSquareService = new GridSquareService();
        }

        [DataTestMethod]
        [DataRow("Z10")]
        [DataRow("F1")]
        [DataRow("A6")]
        public void GetSquareToBeShot_Test_NotExisting(string squareInputId)
        {
            var grid = new Grid(5);
            var gridSquare = _gridSquareService.GetGridSquareToBeShot(grid, squareInputId);
            Assert.IsNull(gridSquare);
        }

        [DataTestMethod]
        [DataRow("A1")]
        [DataRow("E5")]
        [DataRow("A5")]
        public void GetSquareToBeShot_Test_Existing(string squareInputId)
        {
            var grid = new Grid(5);
            var gridSquare = _gridSquareService.GetGridSquareToBeShot(grid, squareInputId);
            Assert.IsNotNull(gridSquare);
        }
    }
}