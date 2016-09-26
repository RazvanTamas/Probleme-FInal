using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RataBancara
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDobandaLuna1()         
        {
            double RataLuna1 = RataBanca(40000, 7.57, 240, 1);
            Assert.AreEqual(419.00, RataLuna1);
        }
        [TestMethod]
        public void TestDobandaLuna2()
        {
            double RataLuna2 = RataBanca(40000, 7.57, 240, 2);
            Assert.AreEqual(417.95, RataLuna2);
        }
        [TestMethod]
        public void TestDobandaLunaMartieAnul4()
        {
            double RataLunaMartieAn4 = RataBanca(40000, 7.57, 240, 39);
            Assert.AreEqual(379.05, RataLunaMartieAn4);
        }
        double RataBanca(double Suma,double ProcentDob,int NrLuni,int LunaCurenta)
        {
            double RataLunaraFaraDobanda = Suma / NrLuni;
            double SumaRamasa = Suma - (LunaCurenta - 1)*RataLunaraFaraDobanda;
            double ProcentDobandaPeLuna = (ProcentDob / 12)/100;
            double RataLunara = RataLunaraFaraDobanda + SumaRamasa * ProcentDobandaPeLuna;
            return Math.Round(RataLunara,2);
        }
        
    }
}
