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
            CollectionAssert.AreEqual(new string[] { "one", "Three", "two", "Three", "three", "two" }, PutWordsInArray(" ?one, Three two  ?  Three     three two  "));
        }
        [TestMethod]
        public void CountNumberOfAppearancesTest()
        {
            Assert.AreEqual(3, CountNumberOfAppearances("Three", new string[] { "three", "Three", "two", "Three", "?>", "Three", "two", "one" }));
        }
        [TestMethod]
        public void SwapWordsTest()
        {
            string wordOne = "one";
            string wordTwo = "two";
            SwapWordsInArray(ref wordOne, ref wordTwo);
            Assert.AreEqual(wordOne, "two");
        }
        [TestMethod]
        public void ArrangeWordsInOrderOfAppearancesTest()
        {
            Assert.AreEqual("Three Three Three two two One", ArrangeWordsInOrderOfAppearances("Three One Three two Three two"));
        }
        [TestMethod]
        public void SymbolsStringTest()
        {
            Assert.AreEqual(" !\"#$%&'()*+,-.:;<=>?@[\\]^_`{|}~", ConcatAllSymbols());
        }
        [TestMethod]
        public void WordsInOrderOfAppearances()
        {
            Assert.AreEqual("Three Two One", WordsInOrderOfAppearances("Three One Three Two Three Two"));
        }

        string ArrangeWordsInOrderOfAppearances(string givenText)
        {
            var arrayOfWords = PutWordsInArray(givenText);
            ArrangeWordsInNumberOfAppearancesUsingInsertion(ref arrayOfWords, givenText);
            string newString = string.Empty;          
            newString = BuildNewString(ref newString, arrayOfWords, 0,1);
            return newString.Substring(0, newString.Length - 1);
        }

        string WordsInOrderOfAppearances(string givenText)
        {
            var arrayOfWords = PutWordsInArray(givenText);
            string[] ArrayWithWordsInOrderOfAppearances = ArrangeWordsInNumberOfAppearancesUsingInsertion(ref arrayOfWords,givenText);
            string wordsInOrderOfAppearances = string.Empty;
            int i = 0;
            wordsInOrderOfAppearances = BuildNewString(ref wordsInOrderOfAppearances, ArrayWithWordsInOrderOfAppearances, i, CountNumberOfAppearances(ArrayWithWordsInOrderOfAppearances[i], ArrayWithWordsInOrderOfAppearances));
            return wordsInOrderOfAppearances.Substring(0,wordsInOrderOfAppearances.Length-1);
        }

        string BuildNewString(ref string newString,string [] arrayOfWords,int i,int increment)
        {
            if (i >= arrayOfWords.Length)
                return newString;
            newString += arrayOfWords[i];
            newString += " ";
            i = i + increment;
            increment = (increment > 1) ? increment - 1 : increment;
            return BuildNewString(ref newString, arrayOfWords, i, increment);
        }

        string [] PutWordsInArray(string givenText)
        {
            int j = -1;
            int countSymbolsAndSpaces = 0;
            string[] arrayOfWords = new string[0];
            for (int i = 0; i < givenText.Length; i++)
            {
                string alphabet = string.Concat(BuildAlphabetOrSymbolsString((int)'a',26), BuildAlphabetOrSymbolsString((int)'A',26));

                if (alphabet.Contains(givenText[i]) && i == 0)
                {
                    Array.Resize(ref arrayOfWords, arrayOfWords.Length + 1);
                    j++;
                }

                if (alphabet.Contains(givenText[i]))
                {
                    arrayOfWords[j] += givenText[i];
                    countSymbolsAndSpaces = 0;
                }

                if (ConcatAllSymbols().Contains(givenText[i]))                
                    countSymbolsAndSpaces++;

                if (countSymbolsAndSpaces > 0 && i < (givenText.Length - 1) && alphabet.Contains(givenText[i + 1]))  
                {
                    Array.Resize(ref arrayOfWords, arrayOfWords.Length + 1);
                    j++;
                }
            }
            return arrayOfWords;
        }
       
        string ConcatAllSymbols()
        {
            string symbols = string.Empty;
            symbols += BuildAlphabetOrSymbolsString(32, 15);
            symbols += BuildAlphabetOrSymbolsString(58, 7);
            symbols += BuildAlphabetOrSymbolsString(91, 6);
            symbols += BuildAlphabetOrSymbolsString(123, 4);
            return symbols;
        }

        string BuildAlphabetOrSymbolsString(int asciiIndexOne,int asciiIndexTwo)
        {
            string symbolsOrAlphabet = string.Empty;
            for (int i = 0; i <asciiIndexTwo; i++)          
                symbolsOrAlphabet += (char)(asciiIndexOne + i);          
            return symbolsOrAlphabet;
        }
        int CountNumberOfAppearances (string word,string[]arrayOfWords)
        {
            int count = 0;
            for(int i = 0; i < arrayOfWords.Length; i++)
            {
                count = (word == arrayOfWords[i]) ? count + 1 : count; 
            }
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
            if (CountNumberOfAppearances(arrayOfWords[i], arrayOfWords) < CountNumberOfAppearances(arrayOfWords[i + 1], arrayOfWords))
            {
                inOrder = false;
                SwapWordsInArray(ref arrayOfWords[i], ref arrayOfWords[i + 1]);
            }
            return inOrder;
        }
    }
    
}
