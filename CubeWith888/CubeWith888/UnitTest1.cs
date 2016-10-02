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
            Assert.AreEqual(442, CalculateNumber(2));
        }
        int CalculateNumber(int n)
        {
            int i = 1;
            int k = 0;
            while (k != n)
            {
                if ((i*i*i)%1000 == 888)
                {
                    k = k + 1;
                    i++;
                }
                else i++;
            }
            return i-1;
        }
    }
}
