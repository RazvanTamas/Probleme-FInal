using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrefixCalculator
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual("+", PutNumbersAndSymbolsInDifferentStrings("+ 12 44"));
        }
            
        string PutNumbersAndSymbolsInDifferentStrings(string givenExpression)
        {
            string numbers = string.Empty;
            string operations = string.Empty;
            FindNumbersAndSymbols(0, givenExpression,ref numbers,ref operations);
            return operations;                 
        } 
        public static void FindNumbersAndSymbols(int i,string givenExpression,ref string numbers,ref string operations)
        {
            string operationsCollection = "+-*/";
            if (i < givenExpression.Length)
            {            
                if (operationsCollection.Contains(givenExpression[i]))
                    operations += givenExpression[i];
                else
                    numbers += givenExpression[i];
                FindNumbersAndSymbols(i + 1, givenExpression,ref numbers,ref operations);
            }          
        }        
    }
}
