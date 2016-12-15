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
            Assert.AreEqual(9.5m, CalculateExpression("+ * + 1 1 2.5 - 7 2.5"));
        }
        [TestMethod]
        public void TestSum()
        {
            Assert.AreEqual(41, CalculateExpression("+ + + + 10 3 13 8 + 5 2"));
        }
        [TestMethod]
        public void TestMultiplication()
        {
            Assert.AreEqual(24, CalculateExpression("* * 2 3 4"));
        }
        [TestMethod]
        public void TestSubstraction()
        {
            Assert.AreEqual(1, CalculateExpression("- 5 4"));
        }       
        [TestMethod]       
        public void TestDivision()
        {
            Assert.AreEqual(8, CalculateExpression("+ / - 6 2 2 6"));
        }


        decimal CalculateExpression(string givenExpression)
        {
            int i = 0;    
            return DoOperationsOnGivenExpression(givenExpression,ref i);              
        }

        decimal DoOperationsOnGivenExpression(string givenExpression,ref int i)
        {        
            if (i == givenExpression.Length)
                return 0;

            decimal numberInDecimal = 0;
            string numberInString = string.Empty;
            if (" ".Contains(givenExpression[i]))
            {
                i++;
                return DoOperationsOnGivenExpression(givenExpression, ref i);
            }
            if ("+-*/".Contains(givenExpression[i]))
            {
                char sign = givenExpression[i];
                i++;          
                return Operation(DoOperationsOnGivenExpression(givenExpression, ref i), DoOperationsOnGivenExpression(givenExpression, ref i), sign);
            }
            numberInString = GoThroughTheStringToBuildNumber(givenExpression, numberInString, ref i);           
            numberInDecimal = ConvertToDecimal(numberInString);
            return numberInDecimal;
        }

        decimal Operation(decimal numberOne,decimal numberTwo,char operationSign)
        {
            switch (operationSign)
            {              
                case '+':
                    return numberOne + numberTwo;
                case '-':
                    return numberOne - numberTwo;
                case '*':
                    return numberOne * numberTwo;
                case '/':
                    return numberOne / numberTwo;
            }
            return 0.3m;
        }

        string BuildNumber(string givenExpression, string numberInString, ref int i)
        {
            if ((givenExpression[i] >= '0' && givenExpression[i] <= '9') || givenExpression[i] == '.')
            {
                numberInString += givenExpression[i++];
                return GoThroughTheStringToBuildNumber(givenExpression, numberInString, ref i);
            }
            return numberInString;
        }

        string GoThroughTheStringToBuildNumber(string givenExpression, string numberInString, ref int i)
        {           
            if (i < givenExpression.Length)
            {
                numberInString = BuildNumber(givenExpression, numberInString, ref i);              
            }
            return numberInString;
        }

        decimal ConvertToDecimal(string number)
        {
            decimal result;
            decimal.TryParse(number, out result);
                return result;            
        }
    }
}
