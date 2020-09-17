using System;
using Battleships.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Battleships.Tests.Helpers
{
    [TestClass]
    public class StringHelper_UnitTests
    {

        [DataTestMethod]
        [DataRow("A", 0)]
        [DataRow("B", 1)]
        [DataRow("Z", 25)]
        [DataRow("AA", 26)]
        [DataRow("AB", 27)]
        public void GetColumnName_Test(string columnName, int columnIndex)
        {
            Assert.AreEqual(columnName, columnIndex.GetColumnName());
        }

        [TestMethod]
        public void GetColumnName_Test_ArgumentException()
        {
            var index = -1;
            Assert.ThrowsException<ArgumentException>(() => index.GetColumnName());
        }

        [DataTestMethod]
        [DataRow("1", 0)]
        [DataRow("2", 1)]
        public void GetRowName_Test(string rowName, int rowIndex)
        {
            Assert.AreEqual(rowName, rowIndex.GetRowName());
        }

        [TestMethod]
        public void GetRowName_Test_ArgumentException()
        {
            var index = -1;
            Assert.ThrowsException<ArgumentException>(() => index.GetRowName());
        }
    }
}