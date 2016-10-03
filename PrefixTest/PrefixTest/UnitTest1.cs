using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrefixTest
{
    [TestClass]
    public class PrefixTest
    {
        [TestMethod]
        public void PrefixTest1()
        {
            Assert.AreEqual("Ana",CalculatePrefix("AnaAre", "AnaAreMere"));
        }
        string CalculatePrefix(string firstWord, string secondWord)
        {
            int i = 0;
            int minLength = 1;
            string prefix = null;
            minLength = Lengths(firstWord, secondWord);

            while (firstWord[i] == secondWord[i] && i <= minLength)
            {
                prefix += firstWord[i];
                i++;
            }
            return prefix;

            // char[] prefixArray = PutPrefixInArray(firstWord, i);
            //  string prefix = new string(prefixArray, 0, i);
            //  return prefix;
        }

        private static int Lengths(string firstWord, string secondWord)
        {
            int minLength;
            if (firstWord.Length <= secondWord.Length)
                minLength = firstWord.Length;
            else minLength = secondWord.Length;
            return minLength;
        }

        // private static char[] PutPrefixInArray(string firstWord, int i)
        //  {
        //     char[] prefixArray = new char[i + 1];
        //   for (int j = 0; j <= i; j++)
        //    {
        //        prefixArray[j] = firstWord[j];
        //    }

        //   return prefixArray;
        // }
    }
}
