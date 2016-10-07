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
            CollectionAssert.AreEqual(new byte[] {0,0,0,0,1,0,1,0},ToBinary(10, 2));
        }
        [TestMethod]
        public void TestNotOperation()
        {
            CollectionAssert.AreEqual(ToBinary(206,2),CalculateNotOperation(49, 2));
        }
        [TestMethod]
        public void TestOrOperation()
        {
            CollectionAssert.AreEqual(ToBinary(7,2), CalculateOrOperation(3, 5, 2));
        }
        [TestMethod]
        public void TestAndOperation()
        {
            CollectionAssert.AreEqual(ToBinary(1,2), CalculateAndOperation(5, 3, 2));
        }
        [TestMethod]
        public void TestXOrOperation()
        {
            CollectionAssert.AreEqual(ToBinary(6,2), CalculateXOrOperation(5, 3, 2));
        }
        [TestMethod]
        public void TestRightHandShift()
        {
           CollectionAssert.AreEqual(ToBinary(12,2), CalculateRightHandShiftOperation(50, 2, 2));
        }
        [TestMethod]
        public void TestLeftHandShift()
        {
           CollectionAssert.AreEqual(ToBinary(20,2), CalculateLeftHandShiftOperation(5, 2, 2));
        }
        [TestMethod]
        public void TestLessThan()
        {
            Assert.AreEqual(true, CalculateIfLessThan(4, 5, 2));
        }
        [TestMethod]
        public void TestSum()
        {
            CollectionAssert.AreEqual(ToBinary(142,2), CalculateSum(127, 15, 2));
        }      
        [TestMethod]
        public void TestSubstraction()
        {
            CollectionAssert.AreEqual(ToBinary(29,2), CalculateSubstraction(142, 113, 2));
        }
        byte[] ToBinary(int number, int wantedBase)
        {

            byte[] biteArray = new byte[0];
            CalculateBinaryNumberInArray(ref number, wantedBase, ref biteArray);
            biteArray = ConvertToByte(biteArray);
            byte[] binaryNumber = new byte[biteArray.Length];
            binaryNumber = InvertArray(biteArray, binaryNumber);
            return binaryNumber;
        }

        byte[] CalculateNotOperation(int number, int wantedBase)
        {

            byte[] biteArray = new byte[0];          
            CalculateBinaryNumberInArray(ref number, wantedBase, ref biteArray);
            biteArray = ConvertToByte(biteArray);
            byte[] binaryNumberNot = new byte[biteArray.Length];
            CalculateNot(biteArray);
            binaryNumberNot = InvertArray(biteArray, binaryNumberNot);
            return binaryNumberNot;
        }

        byte[] CalculateOrOperation(int numberOne, int numberTwo, int wantedBase)
        {
            byte[] biteArrayOne = new byte[0];
            byte[] biteArrayTwo = new byte[0];           
            CalculateBinaryNumberInArray(ref numberOne, wantedBase, ref biteArrayOne);
            CalculateBinaryNumberInArray(ref numberTwo, wantedBase, ref biteArrayTwo);
            biteArrayOne = ConvertToByte(biteArrayOne);
            biteArrayTwo = ConvertToByte(biteArrayTwo);
            byte[] biteArrayOr = new byte[biteArrayOne.Length];
            byte[] binaryNumberOr = new byte[biteArrayOne.Length];
            CalculateOrArray(biteArrayOne, biteArrayTwo, biteArrayOr);
            binaryNumberOr = InvertArray(biteArrayOr, binaryNumberOr);
            return binaryNumberOr;
        }

        byte[] CalculateAndOperation(int numberOne, int numberTwo, int wantedBase)
        {
            byte[] biteArrayOne = new byte[0];
            byte[] biteArrayTwo = new byte[0];            
            CalculateBinaryNumberInArray(ref numberOne, wantedBase, ref biteArrayOne);
            CalculateBinaryNumberInArray(ref numberTwo, wantedBase, ref biteArrayTwo);
            biteArrayOne = ConvertToByte(biteArrayOne);
            biteArrayTwo = ConvertToByte(biteArrayTwo);
            byte[] biteArrayAnd = new byte[biteArrayOne.Length];
            byte[] binaryNumberAnd = new byte[biteArrayOne.Length];
            CalculateAndArray(biteArrayOne, biteArrayTwo, biteArrayAnd);
            binaryNumberAnd = InvertArray(biteArrayAnd, binaryNumberAnd);
            return binaryNumberAnd;
        }

        byte[] CalculateXOrOperation(int numberOne, int numberTwo, int wantedBase)
        {
            byte[] biteArrayOne = new byte[0];
            byte[] biteArrayTwo = new byte[0];
            CalculateBinaryNumberInArray(ref numberOne, wantedBase, ref biteArrayOne);
            CalculateBinaryNumberInArray(ref numberTwo, wantedBase, ref biteArrayTwo);
            biteArrayOne = ConvertToByte(biteArrayOne);
            biteArrayTwo = ConvertToByte(biteArrayTwo);
            byte[] biteArrayXOr = new byte[biteArrayOne.Length];
            byte[] binaryNumberXOr = new byte[biteArrayOne.Length];
            CalculateXOrArray(biteArrayOne, biteArrayTwo, biteArrayXOr);
            binaryNumberXOr = InvertArray(biteArrayXOr, binaryNumberXOr);
            return binaryNumberXOr;
        }

        byte[] CalculateRightHandShiftOperation(int number, int wantedBase, int shiftRight)
        {
            byte[] biteArray = new byte[0];
            CalculateBinaryNumberInArray(ref number, wantedBase, ref biteArray);
            biteArray = ConvertToByte(biteArray);
            byte[] biteArrayShiftRight = new byte[biteArray.Length];            
            byte[] binaryNumberShiftRight = new byte[biteArray.Length];
            int j = 7;
            binaryNumberShiftRight = InvertArray(biteArray, binaryNumberShiftRight);
            CalculateShiftRightArray(shiftRight, ref binaryNumberShiftRight, biteArrayShiftRight, ref j);            
            return biteArrayShiftRight;
        } 

        byte[] CalculateLeftHandShiftOperation(int number, int wantedBase, int shiftLeft)
        {
            byte[] biteArray = new byte[0];
            CalculateBinaryNumberInArray(ref number, wantedBase, ref biteArray);
            biteArray = ConvertToByte(biteArray);
            byte[] biteArrayShiftLeft = new byte[biteArray.Length];
            byte[] binaryNumberShiftLeft = new byte[biteArray.Length];
            int j = 0;
            binaryNumberShiftLeft = InvertArray(biteArray, binaryNumberShiftLeft);
            CalculateShiftLeftArray(shiftLeft,ref binaryNumberShiftLeft, biteArrayShiftLeft,ref j);
            return biteArrayShiftLeft;
        }
        
        private static bool CalculateIfLessThan(int numberOne,int numberTwo,int wantedBase)
        {
            byte[] biteArrayOne = new byte[0];
            byte[] biteArrayTwo = new byte[0];
            CalculateBinaryNumberInArray(ref numberOne, wantedBase, ref biteArrayOne);
            CalculateBinaryNumberInArray(ref numberTwo, wantedBase, ref biteArrayTwo);
            biteArrayOne = ConvertToByte(biteArrayOne);
            biteArrayTwo = ConvertToByte(biteArrayTwo);
            byte[] binaryNumberOr = new byte[biteArrayOne.Length];
            bool lessThan = false;
            lessThan = IfLessThan(biteArrayOne, biteArrayTwo, lessThan);
            return lessThan;
        }

        byte[] CalculateSum(int numberOne,int numberTwo,int wantedBase)
        {
            byte[] biteArrayOne = new byte[0];
            byte[] biteArrayTwo = new byte[0];
            CalculateBinaryNumberInArray(ref numberOne, wantedBase, ref biteArrayOne);
            CalculateBinaryNumberInArray(ref numberTwo, wantedBase, ref biteArrayTwo);
            biteArrayOne = ConvertToByte(biteArrayOne);
            biteArrayTwo = ConvertToByte(biteArrayTwo);
            byte[] biteArraySum = new byte[biteArrayOne.Length];
            byte[] binaryNumberSum = new byte[biteArrayOne.Length];
            CalculeteSumArray(biteArrayOne, biteArrayTwo, biteArraySum,wantedBase);
            binaryNumberSum = InvertArray(biteArraySum, binaryNumberSum);
            return binaryNumberSum;
        }

        byte[] CalculateSubstraction(int numberOne,int numberTwo,int wantedBase)
        {
            byte[] biteArrayOne = new byte[0];
            byte[] biteArrayTwo = new byte[0];
            CalculateBinaryNumberInArray(ref numberOne, wantedBase, ref biteArrayOne);
            CalculateBinaryNumberInArray(ref numberTwo, wantedBase, ref biteArrayTwo);
            biteArrayOne = ConvertToByte(biteArrayOne);
            biteArrayTwo = ConvertToByte(biteArrayTwo);
            int[] biteArraySub = new int[biteArrayOne.Length];
            int[] intArrayOne = new int[biteArrayOne.Length];
            int[] intArrayTwo = new int[biteArrayOne.Length];
            byte[] binaryNumberSub = new byte[biteArrayOne.Length];
            int j = 0;
            ChangeToInt(biteArrayOne, intArrayOne);
            ChangeToInt(biteArrayTwo, intArrayTwo);
            CalculateSubArray(wantedBase, intArrayOne, intArrayTwo, biteArraySub);
            ChangeOrderAndToByte(biteArraySub, binaryNumberSub, j);
            return binaryNumberSub;
        }

        private static void ChangeOrderAndToByte(int[] biteArraySub, byte[] binaryNumberSub, int j)
        {
            for (int i = biteArraySub.Length-1; i >= 0; i--)
            {
                binaryNumberSub[j] = Convert.ToByte(biteArraySub[i]);
                j++;
            }    
        }
        private static void ChangeToInt(byte[]byteArray,int[]intArray)
        {
            for (int i = byteArray.Length-1; i >= 0; i--)
            {
                intArray[i] = Convert.ToInt32(byteArray[i]);              
            }
        }
        private static void CalculateSubArray(int wantedBase, int[] biteArrayOne, int[] biteArrayTwo, int[] biteArraySub)
        {
            for (int i = 0; i < biteArrayOne.Length; i++)
            {
                if (biteArrayOne[i] - biteArrayTwo[i] == 0)
                {
                    biteArraySub[i] = 0;
                }
                else if (((biteArrayOne[i] - biteArrayTwo[i]) < wantedBase) && ((biteArrayOne[i] - biteArrayTwo[i]) > 0))
                {
                    biteArraySub[i] = biteArrayOne[i] - biteArrayTwo[i];

                }
                else if ((biteArrayOne[i] - biteArrayTwo[i]) < 0 && biteArrayOne[i] - biteArrayTwo[i] > (-1 * wantedBase))
                {
                    biteArraySub[i] = wantedBase+(biteArrayOne[i] - biteArrayTwo[i]);                   
                    biteArrayOne[i + 1] -= 1; 
                }
                else if ((biteArrayOne[i] - biteArrayTwo[i]) == (-1* wantedBase))
                {
                    biteArraySub[i] = 0;
                    biteArrayOne[i + 1] -= 1;
                }                
            }
        }

        private static void CalculeteSumArray(byte[] biteArrayOne, byte[] biteArrayTwo, byte[] biteArraySum,int wantedBase)
        {
            for (int i =0; i <biteArrayOne.Length; i++)
            {
                if (biteArrayOne[i] + biteArrayTwo[i] == wantedBase)
                {
                    biteArraySum[i] = 0;
                    biteArrayOne[i + 1] += 1;                  
                }
                else if ((biteArrayOne[i] + biteArrayTwo[i] < wantedBase) &&(biteArrayOne[i]+biteArrayTwo[i]>0))
                {
                    biteArraySum[i] += biteArrayTwo[i];
                    biteArraySum[i] += biteArrayOne[i];
                }
                else if (biteArrayOne[i] + biteArrayTwo[i] == 0)
                {
                    biteArraySum[i] = 0;
                }
                else if (biteArrayOne[i] + biteArrayTwo[i] > wantedBase)
                {
                    int change= (biteArrayOne[i] + biteArrayTwo[i]) % wantedBase;
                    byte changeInByte = Convert.ToByte(change);
                    biteArraySum[i] += changeInByte;
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

        private static void CalculateShiftRightArray(int shiftRight,ref byte[] binaryNumberShiftRight, byte[] biteArrayShiftRight,ref int j)
        {
            for (int i = (binaryNumberShiftRight.Length-shiftRight-1); i >= 0; i--)
            {
                if (i == 0 && j > 0)
                {
                    biteArrayShiftRight[j] = 0;
                    i++;
                    j--;
                }
                else if (i==0 && j == 0)
                {
                    biteArrayShiftRight[j] = 0;                 
                }
                else
                {
                    biteArrayShiftRight[j] = binaryNumberShiftRight[i];
                    j--;
                }              
            }
           
        }

        private static void CalculateShiftLeftArray(int shiftLeft, ref byte[] binaryNumberShiftLeft, byte[] biteArrayShiftLeft, ref int j)
        {
            for (int i = shiftLeft; i < (8 + shiftLeft); i++)
            {
                if (i >= binaryNumberShiftLeft.Length - 1)
                {
                    Array.Resize(ref binaryNumberShiftLeft, binaryNumberShiftLeft.Length + 1);
                    binaryNumberShiftLeft[i + 1] = 0;
                    biteArrayShiftLeft[j] = binaryNumberShiftLeft[i];
                    j++;
                }
                else
                {
                    biteArrayShiftLeft[j] = binaryNumberShiftLeft[i];
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

        public static byte[]InvertArray(byte[] biteArray, byte[]orderedArray)
        {
            int n = 0;
            for (int i = biteArray.Length - 1; i >= 0; i--)
            {
                orderedArray[n]+= biteArray[i];
                n++;
            }

            return orderedArray;
        }
    }
}
