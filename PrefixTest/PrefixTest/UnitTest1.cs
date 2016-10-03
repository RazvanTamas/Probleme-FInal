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
            Assert.AreEqual("Ana",CalculatePrefix("AnaAreMere", "AnaNuAreMere"));
        }
        string CalculatePrefix(string firstWord, string secondWord)
        {           
            int i = 0;
            string prefix = null;           
            while (firstWord[i] == secondWord[i])
            {
                prefix += firstWord[i];
                i++;               
            }
            return prefix;
            
           // char[] prefixArray = PutPrefixInArray(firstWord, i);
          //  string prefix = new string(prefixArray, 0, i);
          //  return prefix;
        }

       // private static char[] PutPrefixInArray(string firstWord, int i)
      //  {
       //     char[] prefixArray = new char[i + 1];
         //   for (int j = 0; j <= i; j++)
        //    {
        //        prefixArray[j] = firstWord[j];
        //    }

         //   return prefixArray;
       // }
    }
}
