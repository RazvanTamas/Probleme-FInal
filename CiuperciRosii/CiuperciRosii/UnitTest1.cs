using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CiuperciRosii
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCiuperci1()
        {
           int nrciupercirosii = ciupercirosii(33,10);
            Assert.AreEqual(30, nrciupercirosii);
        }
        [TestMethod]
        public void TestCiuperci2()
        {
            int nrciupercirosii = ciupercirosii(30, 4);
            Assert.AreEqual(24, nrciupercirosii);
        }
        int ciupercirosii(int n,int x)
        {
           int nrciupercialbe = n / (x + 1);
           int nrciupercir = nrciupercialbe * x;
            return nrciupercir;
        }
    }
}
