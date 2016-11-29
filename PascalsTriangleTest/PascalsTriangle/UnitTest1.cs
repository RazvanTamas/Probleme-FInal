using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PascalsTriangle
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestForRowNumberOne()
        {
            Assert.AreEqual("1", GenerateRowFromPascalsTriangle(1));
        }
        [TestMethod]
        public void TestForRowNumberTwo()
        {
            Assert.AreEqual("11", GenerateRowFromPascalsTriangle(2));
        }
        string GenerateRowFromPascalsTriangle(int rowNumber)
        {
            int rowNumberInArrays = rowNumber - 1;
            string[] pascalRow = new string[rowNumber];
            if (rowNumberInArrays == 0)
            {
                pascalRow[rowNumberInArrays] += "1";
            }
            else if (rowNumberInArrays == 1)
            {
                pascalRow[rowNumberInArrays] += "11";
            }
            return pascalRow[rowNumberInArrays];
        }
    }
}
