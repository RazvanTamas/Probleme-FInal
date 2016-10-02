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
            int i = 1;
            int k = 0;
            while (k != n)
            {
                FindNumbers(ref i, ref k);
            }
            return i-1;
        }

        private static void FindNumbers(ref int i, ref int k)
        {
            if ((i * i * i) % 1000 == 888)
            {
                k = k + 1;
                i++;
            }
            else i++;
        }
    }
}
