using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sportiv
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestNrRepetitii1()
        {
            double NrRepetitii = RepetitiiSportiv(10);
            Assert.AreEqual(100, NrRepetitii);
        }
        [TestMethod]
        public void TestNrRepetitii2()
        {
            double NrRepetitii = RepetitiiSportiv(7);
            Assert.AreEqual(49, NrRepetitii);
        }

        double RepetitiiSportiv(double n)
        {
            Double repetitii = Math.Pow(n, 2);
            // (n(n+1)/2)*2 -n => n(n+1)-n => n*n;          
            return repetitii;
        }
    }
}
