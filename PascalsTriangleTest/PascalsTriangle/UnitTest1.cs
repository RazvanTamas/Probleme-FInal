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
            CollectionAssert.AreEqual(new int[] { 1 }, GenerateRowFromPascalsTriangle(1));
        }
        [TestMethod]
        public void TestForRowNumberTwo()
        {
            CollectionAssert.AreEqual(new int[] { 1, 1 }, GenerateRowFromPascalsTriangle(2));
        }
        [TestMethod]
        public void TestForRowNumberThree()
        {
            CollectionAssert.AreEqual(new int[] { 1, 2, 1 }, GenerateRowFromPascalsTriangle(3));
        }
        [TestMethod]
        public void TestForRowNumberEight()
        {
            CollectionAssert.AreEqual(new int[] { 1, 7, 21, 35, 35, 21, 7, 1 }, GenerateRowFromPascalsTriangle(8));
        }
        int[] GenerateRowFromPascalsTriangle(int rowNumber)
        {
            int rowNumberInArrays = rowNumber - 1;
            int i = 0;
            int[][] pascalRows = new int[rowNumber][];
            return GenerateRow(pascalRows, rowNumberInArrays, i);
        }
        int[] GenerateRow(int[][]pascalRows,int rowNumberInArrays,int i)
        {
            if (i <= rowNumberInArrays)
            {
                pascalRows[i] = new int[i + 1];
                CheckLengthOfRowAndAddMiddleNumbersIfNeeded(pascalRows, i);
                pascalRows[i][0] = 1;
                pascalRows[i][pascalRows[i].Length - 1] = 1;
                return GenerateRow(pascalRows, rowNumberInArrays, i + 1);
            }
            else return pascalRows[i-1];
        }

        private void CheckLengthOfRowAndAddMiddleNumbersIfNeeded(int[][] pascalRows, int i)
        {
            if (pascalRows[i].Length > 2)
            {
                int j = 1;
                pascalRows[i] = GenerateMiddleNumbers(pascalRows, i, j);
            }
        }

        int[] GenerateMiddleNumbers(int[][]row,int i,int j)
        {
            if (j < row[i].Length - 1)
            {
                row[i][j] = row[i - 1][j - 1] + row[i - 1][j];
                return GenerateMiddleNumbers(row, i, j + 1);
            }
            else return row[i];
        }

        
    }
}
