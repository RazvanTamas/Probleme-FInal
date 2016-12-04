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
            Assert.AreEqual(4, CalculateExpression("* + 1 1 2 "));
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
            decimal number = 0;
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
                BuildNumber(givenExpression, ref i, ref number);
                return number;
            }
            return number;                     
        }

        private static void BuildNumber(string givenExpression, ref int i, ref decimal number)
        {
            while (givenExpression[i] >= '0' && givenExpression[i] <= '9')
            {
                number = 10 * number + (int)char.GetNumericValue(givenExpression[i++]);
            }
        }
    }
}
