using System;
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
            Assert.AreEqual("10001110",CalculateNumberInBase(142,2));
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
        string CalculateNumberInBase(int number,int wantedBase)
        {

            byte[] biteArray = new byte[0];          
            string binaryNumber = string.Empty;
            CalculateBinaryNumberInArray(ref number, wantedBase, ref biteArray);
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
        string CalculateOrOperation(int numberOne,int numberTwo,int wantedBase)
        {
            byte[] biteArrayOne = new byte[0];
            byte[] biteArrayTwo = new byte[0];
            string binaryNumberOr = string.Empty;
            CalculateBinaryNumberInArray(ref numberOne, wantedBase, ref biteArrayOne);
            CalculateBinaryNumberInArray(ref numberTwo, wantedBase, ref biteArrayTwo);            
            biteArrayOne = ConvertToByte(biteArrayOne);
            biteArrayTwo = ConvertToByte(biteArrayTwo);
            byte[] biteArrayOr = new byte[biteArrayOne.Length];
            CalculateOrArray(biteArrayOne, biteArrayTwo,biteArrayOr);
            binaryNumberOr = InvertArray(biteArrayOr, binaryNumberOr);
            return binaryNumberOr;
        }
        string CalculateAndOperation(int numberOne,int numberTwo,int wantedBase)
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
