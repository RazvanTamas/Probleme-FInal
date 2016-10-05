using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections;

namespace BitOperation
{
    [TestClass]
    public class BitOperationTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual("10001110",CalculateNumberInBase(142,2));
        }
        string CalculateNumberInBase(int number,int wantedBase)
        {

            byte[] biteArray = new byte[0];
            string numberInBits = string.Empty;
            while (number != 0)
            {
                Array.Resize(ref biteArray, biteArray.Length + 1);
                biteArray[biteArray.Length - 1] = (byte)(number % wantedBase);
                number = number / wantedBase;

            }
            numberInBits = InvertArray(biteArray, numberInBits);

            return numberInBits;
        }

        private static string InvertArray(byte[] biteArray, string numberInBits)
        {
            for (int i = biteArray.Length - 1; i >= 0; i--)
            {
                numberInBits += biteArray[i];
            }

            return numberInBits;
        }
    }
}
