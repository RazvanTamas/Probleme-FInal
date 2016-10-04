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
            CalculateLetterRepetitions(word, repeatCounter);
            int numberOfTotalRepeats = 1;
            int numberOfTotalAnagrams = 1;
            return CorrectNumberOfAnagrams(repeatCounter,word);
            
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

       int CorrectNumberOfAnagrams(int[] repeatCounter, string word)
        {

            return (Factorial(word) / FactorialForRepeats(word, repeatCounter));
        }

        int Factorial(string word)
        {
            int fact = 1;
            for (int i = 1; i <= word.Length; i++)
            {
                 fact = fact * i;
            }
            return fact;
           // numberOfTotalRepeats = numberOfTotalRepeats * repeatCounter[i];
        }
        int FactorialForRepeats(string word,int[]repeatCounter)
        {
            int fact = 1;
            for(int i = 0; i < word.Length; i++)
            {
                fact = fact * repeatCounter[i];
            }
            return fact;                      
        }
    }
}
