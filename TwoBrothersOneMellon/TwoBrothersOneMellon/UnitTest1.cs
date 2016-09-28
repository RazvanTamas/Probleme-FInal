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
            Assert.AreEqual("Da", AreTheySatisfied(6,2,4));
        }
        string AreTheySatisfied(int weightOfMelon,int weightGivenToBrother1,int weightGivenToBrother2)
        {
            if (BothWeights(weightOfMelon, weightGivenToBrother1, weightGivenToBrother2))
                        return "Da";

            return "Nu";
        }

        private static bool BothWeights(int weightOfMelon, int weightGivenToBrother1, int weightGivenToBrother2)
        {
            return (weightGivenToBrother1 + weightGivenToBrother2 == weightOfMelon);
        }
    }
}
