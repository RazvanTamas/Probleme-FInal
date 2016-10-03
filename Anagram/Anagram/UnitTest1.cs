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
            Assert.AreEqual(6, CalculateAnagramNr("abc"));
        }
        int CalculateAnagramNr(string word)
        {
            int[] repeatCounter = new int[word.Length];
            repeatCounter[0] = 1;           
            CalculateLetterRepetitions(word, repeatCounter);
            int numberOfTotalRepeats = 1;
            int numberOfTotalAnagrams = 1;
            return CorrectNumberOfAnagrams(repeatCounter,word, numberOfTotalRepeats,  numberOfTotalAnagrams);
            
        }

        private static void CalculateLetterRepetitions(string word, int[] repeatCounter)
        {
            for (int i = 1; i < word.Length; i++)
            {
                repeatCounter[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    if (word[i] == word[j])
                        repeatCounter[i] = repeatCounter[i] + 1;
                }
            }
        }

       int CorrectNumberOfAnagrams(int[] repeatCounter, string word, int numberOfTotalRepeats, int numberOfTotalAnagrams)
        {
            for (int i = 0; i < word.Length; i++)
            {
                Factorial(repeatCounter,ref numberOfTotalRepeats,ref numberOfTotalAnagrams, i);
            }
            return (numberOfTotalAnagrams / numberOfTotalRepeats);
        }

        private static void Factorial(int[] repeatCounter,ref int numberOfTotalRepeats,ref int  numberOfTotalAnagrams, int i)
        {
            numberOfTotalRepeats = numberOfTotalRepeats * repeatCounter[i];
            numberOfTotalAnagrams = numberOfTotalAnagrams * (i + 1);
        }
    }
}
