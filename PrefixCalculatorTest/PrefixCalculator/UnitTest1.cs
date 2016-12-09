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
            Assert.AreEqual(5, CalculateExpression("* + 1 1 2.5"));
        }
        [TestMethod]
        public void TestSum()
        {
            Assert.AreEqual(34, CalculateExpression("+ + + 10 3 13 8"));
        }
        [TestMethod]
        public void TestMultiplication()
        {
            Assert.AreEqual(24, CalculateExpression("* * 2 3 4"));
        }
        [TestMethod]
        public void TestSubstraction()
        {
            Assert.AreEqual(9, CalculateExpression("+ - 5 4 8"));
        }       
        [TestMethod]       
        public void TestDivision()
        {
            Assert.AreEqual(8, CalculateExpression("+ / - 6 2 2 6"));
        }

        public static string number;
        public static int i;

        decimal CalculateExpression(string givenExpression)
        {
            i = 0;    
            return DoOperationsOnGivenExpression(givenExpression);              
        }  

        decimal DoOperationsOnGivenExpression(string givenExpression)
        {
            decimal numberInDecimal = 0;
            string numberInString = string.Empty;
            if (i < givenExpression.Length)
            {
                switch (givenExpression[i])
                {                   
                    case ' ':
                        i++;               
                        return DoOperationsOnGivenExpression(givenExpression);
                    case '+':
                        i++;                       
                        return DoOperationsOnGivenExpression(givenExpression) + DoOperationsOnGivenExpression(givenExpression);
                    case '-':
                        i++;
                        return DoOperationsOnGivenExpression(givenExpression) - DoOperationsOnGivenExpression(givenExpression);
                    case '*':
                        i++;        
                        return DoOperationsOnGivenExpression(givenExpression) * DoOperationsOnGivenExpression(givenExpression);
                    case '/':
                        i++;                       
                        return DoOperationsOnGivenExpression(givenExpression) / DoOperationsOnGivenExpression(givenExpression);
                }
                numberInString = GoThroughTheStringToBuildNumber(givenExpression);
                number = string.Empty;
                numberInDecimal = ConvertToDecimal(numberInString);
                return numberInDecimal;
            }
            return numberInDecimal;                     
        }

        string GoThroughTheStringToBuildNumber(string givenExpression)
        {           
            if (i < givenExpression.Length)
            {
                number = BuildNumber(givenExpression);               
            }
            return number;
        }

        string BuildNumber(string givenExpression)
        {
            if ((givenExpression[i] >= '0' && givenExpression[i] <= '9') || givenExpression[i] == '.')
            {
                number += givenExpression[i++];
                return GoThroughTheStringToBuildNumber(givenExpression);
            }
            return number;
        }

        decimal ConvertToDecimal(string number)
        {
            decimal result;
            decimal.TryParse(number, out result);
                return result;            
        }
    }
}
