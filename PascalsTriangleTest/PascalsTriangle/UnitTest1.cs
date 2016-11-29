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

        string GenerateRowFromPascalsTriangle(int rowNumber)
        {
            int rowNumberInArrays = rowNumber - 1;
            string[] pascalRow = new string[rowNumber];
            if ((rowNumberInArrays) == 0)
            {
                string currentRow = string.Empty;
                currentRow += '1';
                pascalRow[rowNumberInArrays] = currentRow;
            }
            return pascalRow[rowNumberInArrays];
        }
    }
}
