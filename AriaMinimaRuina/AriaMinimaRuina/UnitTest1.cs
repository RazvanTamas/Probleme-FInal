using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AriaMinimaRuina
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLungimeLatura1()
        {
            double AriaMinimaRuina = AriaTriunghiului(0, 3, 4, 0, 0, 0);
            Assert.AreEqual(6, AriaMinimaRuina);
        }
        [TestMethod]
        public void TestLungimeLatura2()
        {
            double AriaMinimaRuina = AriaTriunghiului(1,1,1,7,15,1);
            Assert.AreEqual(42, AriaMinimaRuina);
        }
        double AriaTriunghiului(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            double Latura1 = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
            double Latura2 = Math.Sqrt(Math.Pow((x3 - x1), 2) + Math.Pow((y3 - y1), 2));
            double Latura3 = Math.Sqrt(Math.Pow((x3 - x2), 2) + Math.Pow((y3 - y2), 2));
            double SemiPerimetru = (Latura1 + Latura2 + Latura3) / 2;
            double AriaMinima = Math.Round(Math.Sqrt(SemiPerimetru * (SemiPerimetru - Latura1) * (SemiPerimetru - Latura2) * (SemiPerimetru - Latura3)),2);
            return AriaMinima;
        }
    }
}
