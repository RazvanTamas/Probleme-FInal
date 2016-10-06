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
            Assert.AreEqual("11001110", CalculateBinaryNumberNot(49, 2));
        }
        string CalculateNumberInBase(int number,int wantedBase)
        {

            byte[] biteArray = new byte[0];          
            string binaryNumber = string.Empty;
            CalculateBinaryNumberInArray(ref number, wantedBase, ref biteArray);
            binaryNumber = InvertArray(biteArray, binaryNumber);                      
            return binaryNumber;
        }
        string CalculateBinaryNumberNot(int number, int wantedBase)
        {

            byte[] biteArray = new byte[0];           
            string binaryNumberNot = string.Empty;
            CalculateBinaryNumberInArray(ref number, wantedBase, ref biteArray);
            biteArray = ConvertToByte(biteArray);
            CalculateNot(biteArray, binaryNumberNot);
            binaryNumberNot = InvertArray(biteArray, binaryNumberNot);
            return binaryNumberNot;
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

        public static void CalculateNot(byte[] biteArray,string binaryNumberNot)
        {
            for (int i = biteArray.Length-1; i >=0; i--)
            {
                if (biteArray[i] == 0)
                {
                    biteArray[i] += 1;
                    binaryNumberNot += biteArray[i];
                }            

                else
                {
                    biteArray[i] -= 1;
                    binaryNumberNot += biteArray[i];
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
