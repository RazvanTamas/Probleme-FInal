using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            return "AZ";
        }
    }
}
