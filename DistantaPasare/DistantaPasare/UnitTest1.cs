using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DistantaPasare
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDistPasare1()
        {
            Double Dist = DistPasare(100, 10);
            Assert.AreEqual(112.5, Dist);
        }
        [TestMethod]
        public void TestDistPasare2()
        {
            Double Dist = DistPasare(187, 25);
            Assert.AreEqual(210.375, Dist);
        }
        double DistPasare(double distInit,double x)
        {
            double distantaPornPasare = distInit * 3 / 4;
            double TimpIntalnireTrenuri = distantaPornPasare / (2 * x);
            double VitPasare = 3 * x;
                        ///Viteza pasarii este de 2*x la ca se adauga si viteza trenului catre care se indreapta;         
            double DistantaFinalaPasare = TimpIntalnireTrenuri * VitPasare;
            return DistantaFinalaPasare;
        }
    
    }
}
