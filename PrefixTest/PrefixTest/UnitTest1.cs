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
            Assert.AreEqual("AnaAre",CalculatePrefix("AnaAreBanane", "AnaAreMere"));
        }
        string CalculatePrefix(string firstWord, string secondWord)
        {
            
            string prefix = null;
            for (int i = 0; i < firstWord.Length; i++)
            {
                if (firstWord[i] != secondWord[i])
                    break;
                prefix += firstWord[i];
            }
          return prefix;          
        }
    }
}
