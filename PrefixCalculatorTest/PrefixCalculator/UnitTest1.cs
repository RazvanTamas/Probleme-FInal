using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrefixCalculator
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCalculateExpression()
        {
            Assert.AreEqual(5, CalculateExpression("* + 1 1 2.5 "));
        }
        [TestMethod]
        public void TestSum()
        {
            Assert.AreEqual(34, CalculateExpression("+ + + 10 3 13 8 "));
        }
        [TestMethod]
        public void TestMultiplication()
        {
            Assert.AreEqual(24, CalculateExpression("* * 2 3 4 "));
        }
        [TestMethod]
        public void TestSubstraction()
        {
            Assert.AreEqual(9, CalculateExpression("+ - 5 4 8 "));
        }    
        [TestMethod]
        public void TestDivision()
        {
            Assert.AreEqual(8, CalculateExpression("+ / - 6 2 2 6 "));
        }
        decimal CalculateExpression(string givenExpression)
        {          
            int i = 0;
            return DoOperationsOnGivenExpression(givenExpression,ref i);              
        }  

        decimal DoOperationsOnGivenExpression(string givenExpression,ref int i)
        {
            decimal numberInDecimal = 0;
            string numberInString = string.Empty;
            if (i < givenExpression.Length)
            {
                switch (givenExpression[i])
                {
                    case ' ':
                        i++;
                        return DoOperationsOnGivenExpression(givenExpression, ref i);
                    case '+':
                        i++;
                        return DoOperationsOnGivenExpression(givenExpression, ref i) + DoOperationsOnGivenExpression(givenExpression, ref i);
                    case '-':
                        i++;
                        return DoOperationsOnGivenExpression(givenExpression, ref i) - DoOperationsOnGivenExpression(givenExpression, ref i);
                    case '*':
                        i++;
                        return DoOperationsOnGivenExpression(givenExpression, ref i) * DoOperationsOnGivenExpression(givenExpression, ref i);
                    case '/':
                        i++;
                        return DoOperationsOnGivenExpression(givenExpression, ref i) / DoOperationsOnGivenExpression(givenExpression, ref i);
                }
                BuildNumber(givenExpression, ref i, ref numberInString);
                numberInDecimal = ConvertToDecimal(numberInString);
                return numberInDecimal;
            }
            return numberInDecimal;                     
        }

        string BuildNumber(string givenExpression, ref int i, ref string number)
        {
            while ((givenExpression[i] >= '0' && givenExpression[i] <= '9') || givenExpression[i]=='.')
            {
                number += givenExpression[i++];
            }
            return number;
        }
        decimal ConvertToDecimal(string number)
        {
            decimal result;
            if (decimal.TryParse(number, out result))
                return result;
            else return 0;
        }
    }
}
