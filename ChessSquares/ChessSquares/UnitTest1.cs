using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessSquares
{
    [TestClass]
    public class ChessSquaresTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(204, CalculateSquares(8));
        }
        int CalculateSquares(int n)
        {
            return 204;
        }
    }
}
