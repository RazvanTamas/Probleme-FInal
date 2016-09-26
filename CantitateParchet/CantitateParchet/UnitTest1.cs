using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CantitateParchet
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestBucatiParchet1()
        {
            double NrBucatiParchet = parchet(200, 150, 10, 20);
            Assert.AreEqual(187, NrBucatiParchet);
        }
        [TestMethod]
        public void TestBucatiParchet2()
        {
            double NrBucatiParchet = parchet(40, 60, 3, 3);
            Assert.AreEqual(330, NrBucatiParchet);
        }
        double parchet(double M,double N,double A,double B)
        {
            double AParchetcuPierderi = A * B * 0.85;
            //Am calculat pierderea de 15% la aria bucatii de parchet, nu la laturile sale;
            double raport = A / B;
            double BdupaPierderi =Math.Sqrt(AParchetcuPierderi /raport);
            double AdupaPierderi = raport * BdupaPierderi;
            //Am aflat latura si lungimea bucatii de parchet dupa pierderi;
            double NrBucLatime = Math.Ceiling(M / AdupaPierderi);
            double NrBucLungime = Math.Ceiling(N / BdupaPierderi);          
            double NrBucLatime2 = Math.Ceiling(M / BdupaPierderi);
            double NrBucLungime2 = Math.Ceiling(N / AdupaPierderi);           
            double NrBuc1 = NrBucLatime * NrBucLungime;
            double NrBuc2 = NrBucLatime2 * NrBucLungime2;
            //Am calculat bucatile minime de parchet de care am nevoie pt ambele cazuri in care pun parchetul;
            if (NrBuc1 <= NrBuc2) return NrBuc1;
            else return NrBuc2;
        }
    }
}
