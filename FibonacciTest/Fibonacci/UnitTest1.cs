using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fibonacci
{
    [TestClass]
    public class FibonacciTest
    {
        [TestMethod]
        public void FibonacciTestForZeroNumbers()
        {
            Assert.AreEqual(0, CalculateFibonacci(0));
        }
        [TestMethod]
        public void FibonacciTestForOneNumber()
        {
            Assert.AreEqual(0, CalculateFibonacci(1));
        }
        [TestMethod]
        public void FibonacciTestForSecondNumber()
        {
            Assert.AreEqual(1, CalculateFibonacci(2));
        }
        [TestMethod]
        public void FibonacciTestForTheRestOfTheNumbers()
        {
            Assert.AreEqual(2, CalculateFibonacci(4));
        }
        int i;
        int CalculateFibonacci(int k)
        {
            int firstNumber = 0;
            int secondNumber = 1;           
            if (k ==2) return (secondNumber);
            if (k > 3)
            {
                i = k - 2;
                return SumOfLastTwoNumbersOFFibonacci(firstNumber, secondNumber);
            }         
            return firstNumber;
        }
        int SumOfLastTwoNumbersOFFibonacci(int firstNumber,int secondNumber)
        {
            if (i > 0)
            {
                int aux = secondNumber;
                secondNumber += firstNumber;
                firstNumber = aux;
                i--;
                return SumOfLastTwoNumbersOFFibonacci(firstNumber, secondNumber);
            }
            return secondNumber;
        }
    }   
}
