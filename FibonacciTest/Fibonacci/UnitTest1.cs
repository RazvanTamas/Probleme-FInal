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
        int CalculateFibonacci(int k)
        {
            int firstNumber = 0;
            int secondNumber = 1;
            if (k ==2) return (secondNumber);
            return firstNumber;
        }
    }   
}
