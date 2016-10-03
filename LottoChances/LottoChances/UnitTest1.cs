using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LottoChances
{
    [TestClass]
    public class LottoChancesTest
    {
        [TestMethod]
        public void TestFor6()
        {
            Assert.AreEqual(0.0000184498995124077719558052m, CalculateChances(5,6,49));
        }           
        decimal CalculateChances(decimal numberOfCorrectGuesses,decimal numbersDrawn,decimal allNumbers)
        {
            decimal categoryTwo = (ProbabilityClassic(allNumbers, numbersDrawn)) / (ProbabilityClassic(numbersDrawn, numberOfCorrectGuesses) * ProbabilityClassic((allNumbers - numbersDrawn),(numbersDrawn-numberOfCorrectGuesses)));
            return categoryTwo;
            //from hypergeometric distribution formula       
        }
        private static decimal ProbabilityClassic(decimal allNumbers,decimal numbersDrawn)
        {
            decimal probability = 1;
            for (decimal i = 1; i <= numbersDrawn; i++)
            {
                probability = probability * (i / allNumbers);
                allNumbers -= 1;
            }

            return probability;
        }
    }
}
