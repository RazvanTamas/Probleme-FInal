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
            Assert.AreEqual("AnaAre",CalculatePrefix("AnaAre", "AnaAreMere"));
        }
        string CalculatePrefix(string firstWord, string secondWord)
        {
            int i = 0;
            string prefix = null;
            do
            {
                if (firstWord[i] == secondWord[i])
                {
                    prefix += firstWord[i];
                    i++;
                }
                else break;  
            }
            while (i < firstWord.Length);
            return prefix;          
        }
    }
}
