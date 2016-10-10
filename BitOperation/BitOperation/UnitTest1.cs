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
            CollectionAssert.AreEqual(ToBinary(350,2), CalculateSum(300, 50, 2));
        }      
        [TestMethod]
        public void TestSubstraction()
        {
            CollectionAssert.AreEqual(ToBinary(29,2), CalculateSubstraction(142, 113, 2));
        }
        [TestMethod]
        public void TestMultiplication()
        {
            CollectionAssert.AreEqual(ToBinary(240,2),CalculateMultiplication(30,8,2));
        }
        byte[] ToBinary(int number, int wantedBase)
        {
            byte[] biteArray = CalculateBinaryNumberInArray(number, wantedBase);
            biteArray = ConvertToByte(biteArray);          
            biteArray = InvertArray(biteArray);
            return biteArray;
        }

        byte[] CalculateNotOperation(int number, int wantedBase)
        {
            byte[] biteArray =CalculateBinaryNumberInArray(number, wantedBase);
            biteArray = ConvertToByte(biteArray);        
            CalculateNot(biteArray);
            biteArray = InvertArray(biteArray);
            return biteArray;
        }

        byte[] CalculateOrOperation(int numberOne, int numberTwo, int wantedBase)
        {
            byte[] biteArrayOne = CalculateBinaryNumberInArray(numberOne, wantedBase);
            byte[] biteArrayTwo = CalculateBinaryNumberInArray(numberTwo, wantedBase);   
            biteArrayOne = ConvertToByte(biteArrayOne);
            biteArrayTwo = ConvertToByte(biteArrayTwo);
            byte[] biteArrayOr = new byte[biteArrayOne.Length];      
            CalculateOrArray(biteArrayOne, biteArrayTwo, biteArrayOr);
            biteArrayOr = InvertArray(biteArrayOr);
            return biteArrayOr;
        }

        byte[] CalculateAndOperation(int numberOne, int numberTwo, int wantedBase)
        {
            byte[] biteArrayOne = CalculateBinaryNumberInArray(numberOne, wantedBase);
            byte[] biteArrayTwo = CalculateBinaryNumberInArray(numberTwo, wantedBase);
            biteArrayOne = ConvertToByte(biteArrayOne);
            biteArrayTwo = ConvertToByte(biteArrayTwo);
            byte[] biteArrayAnd = new byte[biteArrayOne.Length];           
            CalculateAndArray(biteArrayOne, biteArrayTwo, biteArrayAnd);
            biteArrayAnd= InvertArray(biteArrayAnd);
            return biteArrayAnd;
        }

        byte[] CalculateXOrOperation(int numberOne, int numberTwo, int wantedBase)
        {
            byte[] biteArrayOne = CalculateBinaryNumberInArray(numberOne, wantedBase);
            byte[] biteArrayTwo = CalculateBinaryNumberInArray(numberTwo, wantedBase);
            biteArrayOne = ConvertToByte(biteArrayOne);
            biteArrayTwo = ConvertToByte(biteArrayTwo);
            byte[] biteArrayXOr = new byte[biteArrayOne.Length];           
            CalculateXOrArray(biteArrayOne, biteArrayTwo, biteArrayXOr);
            biteArrayXOr = InvertArray(biteArrayXOr);
            return biteArrayXOr;
        }

        byte[] CalculateRightHandShiftOperation(int number, int wantedBase, int shiftRight)
        {
            byte[] biteArray = CalculateBinaryNumberInArray(number, wantedBase);   
            biteArray = ConvertToByte(biteArray);
            byte[] biteArrayShiftRight = new byte[biteArray.Length];            
            byte[] binaryNumberShiftRight = new byte[biteArray.Length];
            int j = biteArray.Length - 1;
            biteArrayShiftRight = InvertArray(biteArray);
            biteArrayShiftRight=CalculateShiftRightArray(shiftRight,biteArrayShiftRight,j);            
            return biteArrayShiftRight;
        } 

        byte[] CalculateLeftHandShiftOperation(int number, int wantedBase, int shiftLeft)
        {
            byte[] biteArray = CalculateBinaryNumberInArray(number, wantedBase);
            biteArray = ConvertToByte(biteArray);
            byte[] biteArrayShiftLeft = new byte[biteArray.Length];
            byte[] binaryNumberShiftLeft = new byte[biteArray.Length];
            int j = 0;
            biteArrayShiftLeft = InvertArray(biteArray);
            biteArrayShiftLeft=CalculateShiftLeftArray(shiftLeft,biteArrayShiftLeft,j);
            biteArrayShiftLeft = InvertArray(biteArrayShiftLeft);
            biteArrayShiftLeft = TrimToByte(biteArrayShiftLeft);
            biteArrayShiftLeft = ConvertToByte(biteArrayShiftLeft);
            biteArrayShiftLeft = InvertArray(biteArrayShiftLeft);
            return biteArrayShiftLeft;
        }
        
        bool CalculateIfLessThan(int numberOne,int numberTwo,int wantedBase)
        {
            byte[] biteArrayOne = CalculateBinaryNumberInArray(numberOne, wantedBase);
            byte[] biteArrayTwo = CalculateBinaryNumberInArray(numberTwo, wantedBase);
            biteArrayOne = ConvertToByte(biteArrayOne);
            biteArrayTwo = ConvertToByte(biteArrayTwo);
            bool lessThan = false;
            lessThan = IfLessThan(biteArrayOne, biteArrayTwo, lessThan);
            return lessThan;
        }

        byte[] CalculateSum(int numberOne,int numberTwo,int wantedBase)
        {
            byte[] biteArrayOne = CalculateBinaryNumberInArray(numberOne, wantedBase);
            byte[] biteArrayTwo = CalculateBinaryNumberInArray(numberTwo, wantedBase); 
            biteArrayOne = ConvertToByte(biteArrayOne);
            biteArrayTwo = ConvertToByte(biteArrayTwo);
            byte[] biteArraySum = new byte[biteArrayOne.Length];                  
            biteArraySum=CalculateSumArray(biteArrayOne, biteArrayTwo,wantedBase);
            biteArraySum = TrimToByte(biteArraySum);
            biteArraySum = ConvertToByte(biteArraySum);    
            biteArraySum = InvertArray(biteArraySum);         
            return biteArraySum;
        }

        byte[] CalculateSubstraction(int numberOne,int numberTwo,int wantedBase)
        {
            byte[] biteArrayOne = CalculateBinaryNumberInArray(numberOne, wantedBase);
            byte[] biteArrayTwo = CalculateBinaryNumberInArray(numberTwo, wantedBase);
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

        byte[] CalculateMultiplication(int numberOne,int numberTwo,int wantedBase)
        {
            byte[] biteArrayOne = CalculateBinaryNumberInArray(numberOne, wantedBase);
            byte[] biteArrayTwo = CalculateBinaryNumberInArray(numberTwo, wantedBase);
            biteArrayOne = ConvertToByte(biteArrayOne);
            biteArrayTwo = ConvertToByte(biteArrayTwo);
            byte[] biteArrayMult = new byte[biteArrayOne.Length];
            int minLength = MinimLength(biteArrayOne, biteArrayTwo);
            for(int i=minLength-1; i>=0; i--)
            {
                if (biteArrayTwo[i] != 0)
                {
                    biteArrayMult = Shift(biteArrayMult);
                    int j = 0;
                    biteArrayOne = CalculateShiftLeftArray(1, biteArrayOne, j);
                    biteArrayMult = CalculateSumArray(biteArrayOne, biteArrayMult, wantedBase);                                              
                }
                else
                {
                    biteArrayMult = Shift(biteArrayMult);
                    int j = 0;
                    biteArrayOne = CalculateShiftLeftArray(1, biteArrayOne, j);
                }
            }
            biteArrayMult = TrimToByte(biteArrayMult);
            biteArrayMult = ConvertToByte(biteArrayMult);
            biteArrayMult = InvertArray(biteArrayMult);
            return biteArrayMult;
        }
        byte[] Shift(byte[] biteArray)
        {
            Array.Resize(ref biteArray, biteArray.Length + 1);
            int k = biteArray.Length;
            for (k = biteArray.Length - 1; k > 0; k--)
            {
                biteArray[k] = biteArray[k - 1];
            }
            return biteArray;
        }
        byte[] TrimToByte(byte[] biteArray)
        {
            for (int i = biteArray.Length - 1; i >= 0; i--)
            {
                if (biteArray[i] == 0)
                {
                    Array.Resize(ref biteArray, biteArray.Length - 1);
                }
                else break;
            }

            return biteArray;
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

        byte[] CalculateSumArray(byte[] biteArrayOne, byte[] biteArrayTwo,int wantedBase)
        {
            biteArrayOne = EqualizeLength(biteArrayOne,biteArrayOne,biteArrayTwo);
            biteArrayTwo = EqualizeLength(biteArrayTwo,biteArrayOne, biteArrayTwo);
            byte[] biteArraySum = new byte[biteArrayOne.Length];

            for (int i = 0; i < biteArrayOne.Length; i++)
            {
                if (biteArrayOne[i] + biteArrayTwo[i] == wantedBase)
                {
                    biteArraySum[i] = 0;
                    if (i == biteArrayOne.Length)
                    {
                        Array.Resize(ref biteArrayOne, biteArrayOne.Length + 1);
                        Array.Resize(ref biteArrayTwo, biteArrayTwo.Length + 1);
                        Array.Resize(ref biteArraySum, biteArraySum.Length + 1);
                    }
                    biteArrayOne[i + 1] += 1;
                }
                else if ((biteArrayOne[i] + biteArrayTwo[i] < wantedBase) && (biteArrayOne[i] + biteArrayTwo[i] >= 0))
                {
                    biteArraySum[i] += biteArrayTwo[i];
                    biteArraySum[i] += biteArrayOne[i];
                }
                else if (biteArrayOne[i] + biteArrayTwo[i] > wantedBase)
                {
                    int change = (biteArrayOne[i] + biteArrayTwo[i]) % wantedBase;
                    byte changeInByte = Convert.ToByte(change);
                    biteArraySum[i] += changeInByte;
                    if (i == biteArrayOne.Length)
                    {
                        Array.Resize(ref biteArrayOne, biteArrayOne.Length + 1);
                        Array.Resize(ref biteArrayTwo, biteArrayTwo.Length + 1);
                        Array.Resize(ref biteArraySum, biteArraySum.Length + 1);
                    }
                    biteArrayOne[i + 1] += 1;
                }

            }
            return biteArraySum;
        }

        byte[] EqualizeLength(byte[] biteArray,byte[]biteArrayOne,byte[]biteArrayTwo)
        {

            int maxLength = MaximLength(biteArrayOne, biteArrayTwo);
            int minLength = MinimLength(biteArrayOne, biteArrayTwo);
            if (biteArray.Length == minLength)
            {
                for (int i = minLength; i < maxLength; i++)
                {
                    Array.Resize(ref biteArray, biteArray.Length + 1);
                    biteArray[i] = 0;
                }
            }          
            return biteArray;
        }

        int MinimLength(byte[] biteArrayOne, byte[] biteArrayTwo)
        {
            int minlength = 0;
            if (biteArrayOne.Length <= biteArrayTwo.Length)
                minlength = biteArrayOne.Length;
            else minlength = biteArrayTwo.Length;
            return minlength;                
        }
        int MaximLength(byte[] biteArrayOne, byte[] biteArrayTwo)
        {
            int maxlength = 0;
            if (biteArrayOne.Length >= biteArrayTwo.Length)
                maxlength = biteArrayOne.Length;
            else maxlength = biteArrayTwo.Length;
            return maxlength;
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

        byte[] CalculateShiftRightArray(int shiftRight,byte[] binaryNumberShiftRight,int j)
        {
            byte[] biteArrayShiftRight = new byte[binaryNumberShiftRight.Length];
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
            return biteArrayShiftRight;          
        }

        byte[] CalculateShiftLeftArray(int shiftLeft, byte[] binaryNumberShiftLeft,int j)
        {
            byte[] biteArrayShiftLeft = new byte[binaryNumberShiftLeft.Length];
            int length = binaryNumberShiftLeft.Length + shiftLeft;
            for (int i = 0; i < length; i++)
            {
                if (i >= (length-shiftLeft- 1)&& i<(length-1))
                {
                    Array.Resize(ref binaryNumberShiftLeft, binaryNumberShiftLeft.Length + 1);
                    Array.Resize(ref biteArrayShiftLeft, biteArrayShiftLeft.Length + 1);
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
            return biteArrayShiftLeft;
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

        byte[] ConvertToByte(byte[] biteArray)
        {
            decimal length = biteArray.Length;
            for (int i = biteArray.Length; i < (Math.Ceiling(length/8))*8; i++)
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

        byte[] CalculateBinaryNumberInArray(int number, int wantedBase)
        {
            byte[] biteArray =new byte[0];
            while (number != 0)
            {
                Array.Resize(ref biteArray, biteArray.Length + 1);
                biteArray[biteArray.Length - 1] = (byte)(number % wantedBase);
                number = number / wantedBase;               
            }
            return biteArray;
        }

        byte[]InvertArray(byte[] biteArray)
        {
            int n = 0;
            byte[] newBiteArray = new byte[biteArray.Length];
            for (int i = biteArray.Length - 1; i >= 0; i--)
            {
                newBiteArray[n] = biteArray[i];
                n++;
            }

            return newBiteArray;
        }
    }
}
