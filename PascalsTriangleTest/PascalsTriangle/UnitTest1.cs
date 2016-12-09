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
        int[] GenerateRowFromPascalsTriangle(int neededRowNumber)
        {                      
            int currentRowNumber = 1;
            int[] pascalRow = new int[0];        
            return GenerateRow( pascalRow,neededRowNumber, currentRowNumber);
        }
        int[] GenerateRow(int[]pascalRow,int neededRowNumber,int currentRowNumber)
        {
            if (currentRowNumber > neededRowNumber)            
              return pascalRow;
            CheckLengthOfRowAndAddMiddleNumbersIfNeeded(ref pascalRow, currentRowNumber);
            GenerateTheOnesAtTheEdges(ref pascalRow);
            return GenerateRow(pascalRow, neededRowNumber, currentRowNumber + 1);
        }    
      
        private static void GenerateTheOnesAtTheEdges(ref int[]pascalRow)
        {
            pascalRow[0] = 1;
            pascalRow[pascalRow.Length - 1] = 1;       
        }

        private void CheckLengthOfRowAndAddMiddleNumbersIfNeeded(ref int[] row,int currentRowNumber)
        {           
            int[] nextRow = new int[row.Length+1];
            if (currentRowNumber > 2)                           
                row = GenerateMiddleNumbers(ref row, nextRow, 1);            
            else
                Array.Resize(ref row, row.Length + 1);                      
        }

        int[] GenerateMiddleNumbers(ref int[]row,int[] nextRow,int i)
        {           
            if (i == nextRow.Length - 1)
                return nextRow;
            nextRow[i] = row[i - 1] + row[i];
            return GenerateMiddleNumbers(ref row, nextRow, i + 1);           
        }

        
    }
}
