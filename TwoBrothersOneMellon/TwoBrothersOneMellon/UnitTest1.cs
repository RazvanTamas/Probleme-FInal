using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//Doi prieteni au cumparat un pepene de x kg, si doresc sa il imparta.
//Singura lor dorinca e ca fiecare sa primeasca un nr par de kg din pepene.
//E ok si daca nu primesc aceeasi cantitate.
//Scrie un program care raspunde cu DA sau NU(in fct de dorinta);
namespace TwoBrothersOneMellon
{
    [TestClass]
    public class TwoBrothersOneMellonTest
    {
        [TestMethod]
        public void DividibleMellonTest()
        {
            Assert.AreEqual("Nu", AreTheySatisfied(3));
        }
        string AreTheySatisfied(int weightOfMelon)
        {
            for (double i = 1; i < weightOfMelon; i++)
                for (double j = 1; j < weightOfMelon; j++)
                    if ((i + j == weightOfMelon) && i / 2 == Math.Round(i / 2) && j / 2 == Math.Round(j / 2))
                        return "Da";

            return "Nu";


             
           
        }
    }
}
