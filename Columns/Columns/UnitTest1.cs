using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Columns
{
    [TestClass]
    public class ColumsTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual("AZ", ConvertNumber(52));        
        }
   
        string ConvertNumber(int number)
        {
            string convertedNumber = string.Empty;
            while (number > 0)
            {
                int change = (number - 1) % 26;
                convertedNumber = Convert.ToChar('A'+change).ToString()+convertedNumber;                               
                number = (number - change) / 26;

            }
            return convertedNumber;
        }
    }
}
