﻿using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArrangeWordsInOrderOfNumberOfAppearances
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void WordsInArrayOfStringTest()
        {
            CollectionAssert.AreEqual(new string[] { "one", "Three", "two", "Three", "three", "two" }, PutWordsInArray("one, Three two  ?  Three three two"));
        }
        [TestMethod]
        public void CountNumberOfAppearancesTest()
        {
            Assert.AreEqual(2, CountNumberOfAppearances("Three", "one, Three two  ?  Three three two"));
        }
        [TestMethod]
        public void ArrangeNumbersInOrderOfAppearancesTest()
        {
            Assert.AreEqual("Three Three Three two two One", Main("Three One Three two Three two"));
        }

        string  Main(string givenText)
        {
            var arrayOfWords = PutWordsInArray(givenText);
            ArrangeWordsInNumberOfAppearancesUsingInsertion(ref arrayOfWords, givenText);
            string newString = string.Empty;          
            newString = BuildNewString(ref newString, arrayOfWords, 0);
            return newString.Substring(0, newString.Length - 1);

        }
        string BuildNewString(ref string newString,string [] arrayOfWords,int i)
        {
            if (i == arrayOfWords.Length)
                return newString;
            newString += arrayOfWords[i];
            newString += " ";
            return BuildNewString(ref newString, arrayOfWords, i + 1);
        }

        string [] PutWordsInArray(string givenText)
        {
            int j = 0;
            string[] arrayOfWords = new string[1];
            for (int i = 0; i < givenText.Length; i++)
            {
                string alphabet = string.Concat(BuildAlphabet('a'), BuildAlphabet('A'));
                if (alphabet.Contains(givenText[i]))
                    arrayOfWords[j] += givenText[i];
                else
                {
                    if (!" .,?!;()/+=-*&^%$#@~`><'".Contains(givenText[i - 1]))
                    {
                        Array.Resize(ref arrayOfWords, arrayOfWords.Length + 1);
                        j++;
                    }                 
                }
            }
            return arrayOfWords;
        }
        string BuildAlphabet(char firstChar)
        {
            string alphabet = string.Empty;
            for (int i = 0; i < 27; i++)          
                alphabet += (char)(firstChar + i);          
            return alphabet;
        }
        int CountNumberOfAppearances (string word,string givenText)
        {
            int count = (givenText.Length - givenText.Replace(word, "").Length)/word.Length;
            return count;
        }
        public static void SwapWordsInArray(ref string wordOne,ref string wordTwo)
        {
            string temp = wordOne;
            wordOne = wordTwo;
            wordTwo = temp;
        }

        string[] ArrangeWordsInNumberOfAppearancesUsingInsertion(ref string [] arrayOfWords,string givenText)
        {
            bool inOrder = false;
            while (inOrder == false)
            {
                inOrder = true;
                for (int i = 0; i < arrayOfWords.Length-1; i++)
                {
                    inOrder = CheckNumberOfAppearancesAndSwap(arrayOfWords, givenText, inOrder, i);
                }
            }
            return arrayOfWords;
        }

        private bool CheckNumberOfAppearancesAndSwap(string[] arrayOfWords, string givenText, bool inOrder, int i)
        {
            if (CountNumberOfAppearances(arrayOfWords[i], givenText) < CountNumberOfAppearances(arrayOfWords[i + 1], givenText))
            {
                inOrder = false;
                SwapWordsInArray(ref arrayOfWords[i], ref arrayOfWords[i + 1]);
            }
            return inOrder;
        }
    }
    
}
