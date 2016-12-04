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
            
        decimal CalculateExpression(string givenExpression)
        {          
            int i = 0;
            return CalculateSumOfIntegers(givenExpression,ref i);              
        } 
  
        decimal CalculateSumOfIntegers(string givenExpression,ref int i)
        {
            decimal number = 0;
            if (i < givenExpression.Length)
            {
                if (givenExpression[i]==' ')
                {
                    i++;
                    return CalculateSumOfIntegers(givenExpression,ref  i);
                }          
                if (givenExpression[i] == '+')
                {
                    i++;
                    return CalculateSumOfIntegers(givenExpression,ref  i) + CalculateSumOfIntegers(givenExpression, ref i);
                }
                if (givenExpression[i] == '*')
                {
                    i++;
                    return CalculateSumOfIntegers(givenExpression, ref i) * CalculateSumOfIntegers(givenExpression, ref i);
                }
                while (givenExpression[i] >= '0' && givenExpression[i] <= '9')
                {
                    number = 10 * number + (int)char.GetNumericValue(givenExpression[i++]);                        
                }
                return number;                                
            }
            return number;                     
        }
    }
}
