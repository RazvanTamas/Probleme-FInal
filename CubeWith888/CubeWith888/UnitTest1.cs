using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CubeWith888
{
    [TestClass]
    public class CubeWith888Test
    {
        [TestMethod]
        public void TestFirstNumber()
        {
            Assert.AreEqual(192, CalculateNumber(1));
        }
        int CalculateNumber(int n)
        {
            return 192;
        }
    }
}
