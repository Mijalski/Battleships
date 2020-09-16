using Battleships.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Battleships.Tests.Helpers
{
    [TestClass]
    public class StringHelper_UnitTests
    {

        [TestMethod]
        public void GetColumnName_Test_SingleLetterA()
        {
            Assert.AreEqual("A", 0.GetColumnName());
        }

        [TestMethod]
        public void GetColumnName_Test_SingleLetterZ()
        {
            Assert.AreEqual("Z", 25.GetColumnName());
        }

        [TestMethod]
        public void GetColumnName_Test_DoubleLettersAA()
        {
            Assert.AreEqual("AA", 26.GetColumnName());
        }

        [TestMethod]
        public void GetRowName_Test()
        {
            Assert.AreEqual("1", 0.GetRowName());
        }
    }
}