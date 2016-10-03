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
            Assert.AreEqual("AnaAre",CalculatePrefix("AnaAregsds", "AnaAreMeressds"));
        }
        string CalculatePrefix(string firstWord, string secondWord)
        {
            int i = 0;
            int minLength = 1;
            string prefix = null;
            minLength = Lengths(firstWord, secondWord);

            do
            {
                if (firstWord[i] == secondWord[i])
                {
                    prefix += firstWord[i];
                    i++;
                }
                else break;
             
            }
            while (i < minLength);
            return prefix;          
        }

        private static int Lengths(string firstWord, string secondWord)
        {
            int minLength;
            if (firstWord.Length <= secondWord.Length)
                minLength = firstWord.Length;
            else minLength = secondWord.Length;
            return minLength;
        }
    }
}
