using System;
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
            CollectionAssert.AreEqual(new string[] { "one", "three", "two", "three", "three", "two" }, PutWordsInArray("one three two three three two"));
        }
        [TestMethod]
        public void CountNumberOfAppearances()
        {
            Assert.AreEqual(2, CountNumberOfAppearances("Three", "one, Three two  ?  Three three two"));
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
    }
    
}
