using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Anagram
{
    [TestClass]
    public class AnagramTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(3, CalculateAnagramNr("abb"));
        }
        int CalculateAnagramNr(string word)
        {
            int[] repeatCounter = new int[word.Length];
            repeatCounter[0] = 1;
            char[] wordArray = word.ToCharArray();
            for(int i = 1; i < word.Length; i++)
            {
                repeatCounter[i] = 1;
                for(int j = 0; j < i; j++)
                {
                    if (wordArray[i] == wordArray[j])
                        repeatCounter[i] = repeatCounter[i]+1;
                }
            }
            int nrOfTotalRepeats = 1;
            int nrOfTotalAnagrams = 1;        
            for(int i=0;i< wordArray.Length; i++)
            {
                nrOfTotalRepeats = nrOfTotalRepeats * repeatCounter[i];
                nrOfTotalAnagrams = nrOfTotalAnagrams * (i + 1);
            }            
            return ( nrOfTotalAnagrams / nrOfTotalRepeats);
        }
    }
}
