using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//Un fermier are un teren patrat.Pentru a-si extinge suprafata a mai cumparat o parcela alaturata.
//Noua parcela are aceeasi lungime si are o latime de 230m.Acum fermierul are 770 000mp.
//Ce dimensiune avea initial terenul?
namespace FarmersField
{
    [TestClass]
    public class FarmersFieldTests
    {
        [TestMethod]
        public void FarmersFieldInitialSurfaceTest()
        {
            Assert.AreEqual(592900, CalculateInitialSurface(770000, 230));
        }
        double CalculateInitialSurface(double totalSurface, double lengthOfNewField)
        {
            double initialWidth = (-lengthOfNewField + (Math.Sqrt(Math.Pow(lengthOfNewField, 2) + 4 * totalSurface))) / 2;
            return Math.Pow(initialWidth, 2);
        }
    }
}
