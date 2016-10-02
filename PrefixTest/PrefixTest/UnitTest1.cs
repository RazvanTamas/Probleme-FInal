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
            Assert.AreEqual("Ana",CalculatePrefix("AnaAreMere", "AnaNuAreMere"));
        }
        string CalculatePrefix(string word1, string word2)
        {
            int i = 0;
            while (word1[i] == word2[i])
            {
                i++;
            }
            char[] prefixArray = PutPrefixInArray(word1, i);
            string prefix = new string(prefixArray, 0, i);
            return prefix;
        }

        private static char[] PutPrefixInArray(string word1, int i)
        {
            char[] prefixArray = new char[i + 1];
            for (int j = 0; j <= i; j++)
            {
                prefixArray[j] = word1[j];
            }

            return prefixArray;
        }
    }
}
