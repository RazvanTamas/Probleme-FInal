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

        int[] pascalRow = new int[0];

        int[] GenerateRowFromPascalsTriangle(int neededRowNumber)
        {                      
            int currentRowNumber = 1;                
            return GenerateRow(neededRowNumber, currentRowNumber);
        }
        int[] GenerateRow(int neededRowNumber,int currentRowNumber)
        {
            if (currentRowNumber > neededRowNumber)            
              return pascalRow;
            CheckLengthOfRowAndAddMiddleNumbersIfNeeded( currentRowNumber);
            GenerateTheOnesAtTheEdges(pascalRow);
            return GenerateRow( neededRowNumber, currentRowNumber + 1);
        }    
      
        private static void GenerateTheOnesAtTheEdges(int[]pascalRow)
        {
            pascalRow[0] = 1;
            pascalRow[pascalRow.Length - 1] = 1;       
        }

        private void CheckLengthOfRowAndAddMiddleNumbersIfNeeded(int currentRowNumber)
        {           
            int[] nextRow = new int[pascalRow.Length+1];
            if (currentRowNumber > 2)                           
                pascalRow = GenerateMiddleNumbers(nextRow, 1);            
            else
                Array.Resize(ref pascalRow, pascalRow.Length + 1);                      
        }

        int[] GenerateMiddleNumbers(int[] nextRow,int i)
        {           
            if (i == nextRow.Length - 1)
                return nextRow;
            nextRow[i] = pascalRow[i - 1] + pascalRow[i];
            return GenerateMiddleNumbers(nextRow, i + 1);           
        }

        
    }
}
