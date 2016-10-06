﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections;

namespace BitOperation
{
    [TestClass]
    public class BitOperationTest
    {
        [TestMethod]
        public void TestBaseConvert()
        {
            Assert.AreEqual("10001110", CalculateNumberInBase(142, 2));
        }
        [TestMethod]
        public void TestNotOperation()
        {
            Assert.AreEqual("11001110", CalculateNotOperation(49, 2));
        }
        [TestMethod]
        public void TestOrOperation()
        {
            Assert.AreEqual("11111110", CalculateOrOperation(0, 254, 2));
        }
        [TestMethod]
        public void TestAndOperation()
        {
            Assert.AreEqual("00000001", CalculateAndOperation(5, 3, 2));
        }
        [TestMethod]
        public void TestXOrOperation()
        {
            Assert.AreEqual("00000110", CalculateXOrOperation(5, 3, 2));
        }
        [TestMethod]
        public void TestRightHandShift()
        {
            Assert.AreEqual("00001100", CalculateRightHandShiftOperation(50, 2, 2));
        }
        [TestMethod]
        public void TestLeftHandShift()
        {
            Assert.AreEqual("00111000", CalculateLeftHandShiftOperation(142, 2, 2));
        }
        [TestMethod]
        public void TestLessThan()
        {
            Assert.AreEqual(true, CalculateIfLessThan(4, 5,2));
        }
        [TestMethod]
        public void TestSum()
        {
            Assert.AreEqual("10001110", CalculateSum(127, 15, 2));
        }      
        string CalculateNumberInBase(int number, int wantedBase)
        {

            byte[] biteArray = new byte[0];
            string binaryNumber = string.Empty;
            CalculateBinaryNumberInArray(ref number, wantedBase, ref biteArray);
            biteArray = ConvertToByte(biteArray);
            binaryNumber = InvertArray(biteArray, binaryNumber);
            return binaryNumber;
        }

        string CalculateNotOperation(int number, int wantedBase)
        {

            byte[] biteArray = new byte[0];
            string binaryNumberNot = string.Empty;
            CalculateBinaryNumberInArray(ref number, wantedBase, ref biteArray);
            biteArray = ConvertToByte(biteArray);
            CalculateNot(biteArray);
            binaryNumberNot = InvertArray(biteArray, binaryNumberNot);
            return binaryNumberNot;
        }

        string CalculateOrOperation(int numberOne, int numberTwo, int wantedBase)
        {
            byte[] biteArrayOne = new byte[0];
            byte[] biteArrayTwo = new byte[0];
            string binaryNumberOr = string.Empty;
            CalculateBinaryNumberInArray(ref numberOne, wantedBase, ref biteArrayOne);
            CalculateBinaryNumberInArray(ref numberTwo, wantedBase, ref biteArrayTwo);
            biteArrayOne = ConvertToByte(biteArrayOne);
            biteArrayTwo = ConvertToByte(biteArrayTwo);
            byte[] biteArrayOr = new byte[biteArrayOne.Length];
            CalculateOrArray(biteArrayOne, biteArrayTwo, biteArrayOr);
            binaryNumberOr = InvertArray(biteArrayOr, binaryNumberOr);
            return binaryNumberOr;
        }

        string CalculateAndOperation(int numberOne, int numberTwo, int wantedBase)
        {
            byte[] biteArrayOne = new byte[0];
            byte[] biteArrayTwo = new byte[0];
            string binaryNumberAnd = string.Empty;
            CalculateBinaryNumberInArray(ref numberOne, wantedBase, ref biteArrayOne);
            CalculateBinaryNumberInArray(ref numberTwo, wantedBase, ref biteArrayTwo);
            biteArrayOne = ConvertToByte(biteArrayOne);
            biteArrayTwo = ConvertToByte(biteArrayTwo);
            byte[] biteArrayAnd = new byte[biteArrayOne.Length];
            CalculateAndArray(biteArrayOne, biteArrayTwo, biteArrayAnd);
            binaryNumberAnd = InvertArray(biteArrayAnd, binaryNumberAnd);
            return binaryNumberAnd;
        }

        string CalculateXOrOperation(int numberOne, int numberTwo, int wantedBase)
        {
            string binaryNumberXOr = string.Empty;
            byte[] biteArrayOne = new byte[0];
            byte[] biteArrayTwo = new byte[0];
            CalculateBinaryNumberInArray(ref numberOne, wantedBase, ref biteArrayOne);
            CalculateBinaryNumberInArray(ref numberTwo, wantedBase, ref biteArrayTwo);
            biteArrayOne = ConvertToByte(biteArrayOne);
            biteArrayTwo = ConvertToByte(biteArrayTwo);
            byte[] biteArrayXOr = new byte[biteArrayOne.Length];
            CalculateXOrArray(biteArrayOne, biteArrayTwo, biteArrayXOr);
            binaryNumberXOr = InvertArray(biteArrayXOr, binaryNumberXOr);
            return binaryNumberXOr;
        }

        string CalculateRightHandShiftOperation(int number, int wantedBase, int shiftRight)
        {
            byte[] biteArray = new byte[0];
            string binaryNumberShiftRight = string.Empty;
            CalculateBinaryNumberInArray(ref number, wantedBase, ref biteArray);
            biteArray = ConvertToByte(biteArray);
            byte[] biteArrayShiftRight = new byte[biteArray.Length];
            int j = 0;
            CalculateShiftRightArray(shiftRight, ref biteArray, biteArrayShiftRight, ref j);
            binaryNumberShiftRight = InvertArray(biteArrayShiftRight, binaryNumberShiftRight);
            return binaryNumberShiftRight;
        } 

        string CalculateLeftHandShiftOperation(int number, int wantedBase, int shiftLeft)
        {
            byte[] biteArray = new byte[0];
            string binaryNumberShiftLeft = string.Empty;
            CalculateBinaryNumberInArray(ref number, wantedBase, ref biteArray);
            biteArray = ConvertToByte(biteArray);
            byte[] biteArrayShiftLeft = new byte[biteArray.Length];
            int j = 7;
            CalculateShiftLeftArray(shiftLeft, biteArray, biteArrayShiftLeft, j);
            binaryNumberShiftLeft = InvertArray(biteArrayShiftLeft, binaryNumberShiftLeft);
            return binaryNumberShiftLeft;
        }
        
        private static bool CalculateIfLessThan(int numberOne,int numberTwo,int wantedBase)
        {
            byte[] biteArrayOne = new byte[0];
            byte[] biteArrayTwo = new byte[0];
            string binaryNumberOr = string.Empty;
            CalculateBinaryNumberInArray(ref numberOne, wantedBase, ref biteArrayOne);
            CalculateBinaryNumberInArray(ref numberTwo, wantedBase, ref biteArrayTwo);
            biteArrayOne = ConvertToByte(biteArrayOne);
            biteArrayTwo = ConvertToByte(biteArrayTwo);
            bool lessThan = false;
            lessThan = IfLessThan(biteArrayOne, biteArrayTwo, lessThan);
            return lessThan;
        }

        string CalculateSum(int numberOne,int numberTwo,int wantedBase)
        {
            byte[] biteArrayOne = new byte[0];
            byte[] biteArrayTwo = new byte[0];
            string binaryNumberSum = string.Empty;
            CalculateBinaryNumberInArray(ref numberOne, wantedBase, ref biteArrayOne);
            CalculateBinaryNumberInArray(ref numberTwo, wantedBase, ref biteArrayTwo);
            biteArrayOne = ConvertToByte(biteArrayOne);
            biteArrayTwo = ConvertToByte(biteArrayTwo);
            byte[] biteArraySum = new byte[biteArrayOne.Length];
            CalculeteSumArray(biteArrayOne, biteArrayTwo, biteArraySum);
            binaryNumberSum = InvertArray(biteArraySum, binaryNumberSum);
            return binaryNumberSum;
        }

        private static void CalculeteSumArray(byte[] biteArrayOne, byte[] biteArrayTwo, byte[] biteArraySum)
        {
            for (int i =0; i <biteArrayOne.Length; i++)
            {
                if (biteArrayOne[i] + biteArrayTwo[i] == 2)
                {
                    biteArraySum[i] = 0;
                    biteArrayOne[i + 1] += 1;                  
                }
                else if (biteArrayOne[i] + biteArrayTwo[i] == 1)
                {
                    biteArraySum[i] = 1;
                }
                else if (biteArrayOne[i] + biteArrayTwo[i] == 0)
                {
                    biteArraySum[i] = 0;
                }
                else if (biteArrayOne[i] + biteArrayTwo[i] > 2)
                {
                    biteArraySum[i] = 1;
                    biteArrayOne[i + 1] += 1;
                }

            }
        }

        private static bool IfLessThan(byte[] biteArrayOne, byte[] biteArrayTwo, bool lessThan)
        {
            for (int i = biteArrayOne.Length-1; i >= 0;i--)
            {
                if (biteArrayOne[i] < biteArrayTwo[i])
                {
                    lessThan = true;
                    break;
                }
                else if (biteArrayTwo[i] < biteArrayOne[i])
                {
                    lessThan = false;
                    break;
                }
            }

            return lessThan;
        }

        private static int CalculateShiftLeftArray(int shiftLeft, byte[] biteArray, byte[] biteArrayShiftLeft, int j)
        {
            for (int i = (8 - 1 - shiftLeft); i >= 0; i--)
            {
                if (i == 0 && j > 0)
                {
                    biteArrayShiftLeft[j] = 0;
                    i++;
                    j--;
                }
                else if (i==0 && j == 0)
                {
                    biteArrayShiftLeft[j] = 0;                 
                }
                else
                {
                    biteArrayShiftLeft[j] = biteArray[i];
                    j--;
                }              
            }

            return j;
        }

        private static void CalculateShiftRightArray(int shiftRight, ref byte[] biteArray, byte[] biteArrayShiftRight, ref int j)
        {
            for (int i = shiftRight; i < (8 + shiftRight); i++)
            {
                if (i >= biteArray.Length - 1)
                {
                    Array.Resize(ref biteArray, biteArray.Length + 1);
                    biteArray[i + 1] = 0;
                    biteArrayShiftRight[j] = biteArray[i];
                    j++;
                }
                else
                {
                    biteArrayShiftRight[j] = biteArray[i];
                    j++;
                }
            }
        }

        private static void CalculateXOrArray(byte[] biteArrayOne, byte[] biteArrayTwo, byte[] biteArrayXOr)
        {
            for (int i = 0; i < biteArrayOne.Length; i++)
            {
                if (biteArrayOne[i] == biteArrayTwo[i])
                {
                    biteArrayXOr[i] = 0;
                }
                else biteArrayXOr[i] = 1;
            }
        }

        private static void CalculateAndArray(byte[] biteArrayOne, byte[] biteArrayTwo, byte[] biteArrayAnd)
        {
            for (int i = 0; i < biteArrayOne.Length; i++)
            {
                if (biteArrayOne[i] == 1 && biteArrayTwo[i] == 1)
                {
                    biteArrayAnd[i] = 1;
                }
                else biteArrayAnd[i] = 0;
            }
        }

        private static void CalculateOrArray(byte[] biteArrayOne, byte[] biteArrayTwo,byte[]biteArrayOr)
        {
            for (int i = 0; i < biteArrayOne.Length; i++)
            {
                if (biteArrayOne[i] == 0 && biteArrayTwo[i] == 0)
                {
                    biteArrayOr[i] = 0;                 
                }
                else biteArrayOr[i] = 1;
            }
        }

        private static byte[] ConvertToByte(byte[] biteArray)
        {
            for (int i = biteArray.Length; i < 8; i++)
            {
                Array.Resize(ref biteArray, biteArray.Length + 1);
                biteArray[i] = 0;
            }

            return biteArray;
        }

        public static void CalculateNot(byte[] biteArray)
        {
            for (int i = biteArray.Length-1; i >=0; i--)
            {
                if (biteArray[i] == 0)
                {
                    biteArray[i] += 1;           
                }            

                else
                {
                    biteArray[i] -= 1;
                }
            }
            
        }

        public static void CalculateBinaryNumberInArray(ref int number, int wantedBase, ref byte[] biteArray)
        {
            while (number != 0)
            {
                Array.Resize(ref biteArray, biteArray.Length + 1);
                biteArray[biteArray.Length - 1] = (byte)(number % wantedBase);
                number = number / wantedBase;               
            }
        }

        public static string InvertArray(byte[] biteArray, string binaryNumber)
        {
            for (int i = biteArray.Length - 1; i >= 0; i--)
            {
                binaryNumber += biteArray[i];
            }

            return binaryNumber;
        }
    }
}
