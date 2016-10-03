﻿using System;
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
            char[] alphabet = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            int pointer = 0;
            List<char> LettersOfColumnNumber = new List<char>();
            PutLettersInList(ref number, alphabet, ref pointer, LettersOfColumnNumber);
            char[] correctOrder = ExtractLettersFromListInOrder(LettersOfColumnNumber);
            string correctOrderNumber = new string(correctOrder);
            return correctOrderNumber;
        }

        private static char[] ExtractLettersFromListInOrder(List<char> LettersOfColumnNumber)
        {
            string convertedNumber = string.Join("", LettersOfColumnNumber.ToArray());
            char[] correctOrder = new char[convertedNumber.Length];
            int j = 0;
            for (int i = convertedNumber.Length - 1; i >= 0; i--)
            {
                correctOrder[j] = convertedNumber[i];
                j++;
            }

            return correctOrder;
        }

        private static void PutLettersInList(ref int number, char[] alphabet, ref int pointer, List<char> LettersOfColumnNumber)
        {
            while (number > 0)
            {
                pointer = (number - 1) % 26;
                LettersOfColumnNumber.Add(alphabet[pointer]);
                number = (number - pointer) / 26;

            }
        }
    }
}
