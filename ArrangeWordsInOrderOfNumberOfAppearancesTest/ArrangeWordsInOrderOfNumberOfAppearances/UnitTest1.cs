using System;
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
        string [] PutWordsInArray(string givenText)
        {
            int j = 0;
            string[] arrayOfWords = new string[1];
            for (int i = 0; i < givenText.Length; i++)
            {
                if (givenText[i] != ' ')
                    arrayOfWords[j] += givenText[i];
                else
                {
                    Array.Resize(ref arrayOfWords, arrayOfWords.Length + 1);
                    j++;
                }
            }
            return arrayOfWords;
        }
    }
    
}
