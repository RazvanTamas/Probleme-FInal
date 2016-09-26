using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KilogrameManancaCaprele
{
    [TestClass]
    public class TestKgMancare
    {
        [TestMethod]
        public void TestKgManancaCaprele1()
        {
            double kg = Kilograme(10, 5, 200, 5, 2);
            Assert.AreEqual(40, kg);
        }
        [TestMethod]
        public void TestKgManancaCaprele2()
        {
            double kg = Kilograme(5, 10, 100, 8, 12);
            Assert.AreEqual(192, kg);
        }

        double Kilograme(double nrcapre1, double zile1, double kg1, double nrcapre2, double zile2)
        {

            double kg1capra1zi = kg1 / (nrcapre1 * zile1);
            double kg2 = zile2 * nrcapre2 * kg1capra1zi;

            return kg2;

        }

    }
}

