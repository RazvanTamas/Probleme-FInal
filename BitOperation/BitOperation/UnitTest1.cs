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
            CollectionAssert.AreEqual(new byte[] { 0, 0, 0, 0, 0, 0, 1, 0}, ToBase(2, 2));
        }
        [TestMethod]
        public void TestNotOperation()
        {
            CollectionAssert.AreEqual(ToBase(206, 2), CalculateNotOperation(CalculateBinaryNumberInArray(49, 2), 2));
        }
        [TestMethod]
        public void TestOrOperation()
        {
            CollectionAssert.AreEqual(ToBase(7, 2), CalculateOrOperation(CalculateBinaryNumberInArray(3, 2), CalculateBinaryNumberInArray(5, 2), 2));
        }
        [TestMethod]
        public void TestAndOperation()
        {
            CollectionAssert.AreEqual(ToBase(1, 2), CalculateAndOperation(CalculateBinaryNumberInArray(5, 2), CalculateBinaryNumberInArray(3, 2), 2));
        }
        [TestMethod]
        public void TestXOrOperation()
        {
            CollectionAssert.AreEqual(ToBase(6, 2), CalculateXOrOperation(CalculateBinaryNumberInArray(5, 2), CalculateBinaryNumberInArray(3, 2), 2));
        }
        [TestMethod]
        public void TestRightHandShift()
        {
            CollectionAssert.AreEqual(ToBase(12, 2), CalculateRightHandShiftOperation(CalculateBinaryNumberInArray(50, 2), 2, 2));
        }
        [TestMethod]
        public void TestLeftHandShift()
        {
            CollectionAssert.AreEqual(ToBase(20, 2), CalculateLeftHandShiftOperation(CalculateBinaryNumberInArray(5, 2), 2, 2));
        }
        [TestMethod]
        public void TestLessThan()
        {
            Assert.AreEqual(true, CalculateIfLessThan(CalculateBinaryNumberInArray(4, 2), CalculateBinaryNumberInArray(5, 2), 2));
        }
        [TestMethod]
        public void TestSum()
        {
            CollectionAssert.AreEqual(ToBase(77,2), CalculateSum(CalculateBinaryNumberInArray(55,2),CalculateBinaryNumberInArray(22,2), 2));
        }      
        [TestMethod]
        public void TestSubstraction()
        {
            CollectionAssert.AreEqual(ToBase(29, 2), CalculateSubstraction(CalculateBinaryNumberInArray(142, 2), CalculateBinaryNumberInArray(113, 2),2));
        }
        [TestMethod]
        public void TestMultiplication()
        {
            CollectionAssert.AreEqual(ToBase(225,2),CalculateMultiplication(CalculateBinaryNumberInArray(45,2),CalculateBinaryNumberInArray(5,2),2));
        }
        [TestMethod]
        public void TestDivision()
        {
            CollectionAssert.AreEqual(ToBase(3, 2), CalculateDivision(CalculateBinaryNumberInArray(15,2), CalculateBinaryNumberInArray(5, 2),2));
        }
        byte[] ToBase(int number, int wantedBase)
        {
            byte[] biteArray = new byte[0];
            biteArray = CalculateBinaryNumberInArray(number, wantedBase);
            biteArray = ConvertToByte(biteArray);          
            biteArray = InvertArray(biteArray);
            return biteArray;
        }

        byte[] CalculateNotOperation(byte[]biteArray, int wantedBase)
        {
            biteArray = ConvertToByte(biteArray);          
            CalculateNot(biteArray);
            biteArray = InvertArray(biteArray);
            return biteArray;
        }

        byte[] CalculateOrOperation(byte[] biteArrayOne, byte[] biteArrayTwo, int wantedBase)
        { 
            biteArrayOne = ConvertToByte(biteArrayOne);
            biteArrayTwo = ConvertToByte(biteArrayTwo);
            byte[] biteArrayOr = new byte[biteArrayOne.Length];      
            CalculateOrArray(biteArrayOne, biteArrayTwo, biteArrayOr);
            biteArrayOr = InvertArray(biteArrayOr);
            return biteArrayOr;
        }

        byte[] CalculateAndOperation(byte[] biteArrayOne, byte[] biteArrayTwo, int wantedBase)
        {
            biteArrayOne = ConvertToByte(biteArrayOne);
            biteArrayTwo = ConvertToByte(biteArrayTwo);
            byte[] biteArrayAnd = new byte[biteArrayOne.Length];                   
            CalculateAndArray(biteArrayOne, biteArrayTwo, biteArrayAnd);
            biteArrayAnd= InvertArray(biteArrayAnd);
            return biteArrayAnd;
        }

        byte[] CalculateXOrOperation(byte[] biteArrayOne, byte[] biteArrayTwo, int wantedBase)
        {
            biteArrayOne = ConvertToByte(biteArrayOne);
            biteArrayTwo = ConvertToByte(biteArrayTwo);
            byte[] biteArrayXOr = new byte[biteArrayOne.Length];           
            CalculateXOrArray(biteArrayOne, biteArrayTwo, biteArrayXOr);
            biteArrayXOr = InvertArray(biteArrayXOr);
            return biteArrayXOr;
        }

        byte[] CalculateRightHandShiftOperation(byte[] biteArray, int wantedBase, int shiftRight)
        {                 
            byte[] biteArrayShiftRight = new byte[biteArray.Length];            
            byte[] binaryNumberShiftRight = new byte[biteArray.Length];          
            biteArrayShiftRight = InvertArray(biteArray);
            biteArrayShiftRight=CalculateShiftRightArray(shiftRight,biteArrayShiftRight);
            Array.Reverse(biteArrayShiftRight);
            biteArrayShiftRight = ConvertToByte(biteArrayShiftRight);
            Array.Reverse(biteArrayShiftRight);                      
            return biteArrayShiftRight;
        } 

        byte[] CalculateLeftHandShiftOperation(byte[]biteArray, int wantedBase, int shiftLeft)
        {                    
            byte[] biteArrayShiftLeft = new byte[biteArray.Length];
            byte[] binaryNumberShiftLeft = new byte[biteArray.Length];          
            biteArrayShiftLeft = InvertArray(biteArray);
            biteArrayShiftLeft=CalculateShiftLeftArray(shiftLeft,biteArrayShiftLeft);
            Array.Reverse(biteArrayShiftLeft);            
            biteArrayShiftLeft = ConvertToByte(biteArrayShiftLeft);
            Array.Reverse(biteArrayShiftLeft);
            return biteArrayShiftLeft;
        }
        
        bool CalculateIfLessThan(byte[] biteArrayOne, byte[] biteArrayTwo, int wantedBase)
        {
            biteArrayOne = InvertArray(biteArrayOne);
            biteArrayTwo = InvertArray(biteArrayTwo);
            bool lessThan = IfLessThan(biteArrayOne, biteArrayTwo);         
            return lessThan;
        }

        byte[] CalculateSum(byte[]biteArrayOne,byte[]biteArrayTwo,int wantedBase)
        {
            biteArrayOne = InvertArray(biteArrayOne);
            biteArrayTwo = InvertArray(biteArrayTwo);
            EqualizeLengths(ref biteArrayOne,ref biteArrayTwo);
            byte[] biteArraySum=CalculateSumOfEqualLengths(biteArrayOne,biteArrayTwo,wantedBase);        
            biteArraySum= InvertArray(biteArraySum);
            biteArraySum = ConvertToByte(biteArraySum);
            biteArraySum = InvertArray(biteArraySum);           
            return biteArraySum;
        }
        byte[] CalculateSumForArray(byte[]biteArrayOne,byte[]biteArrayTwo,int wantedBase)
        {
            EqualizeLengths(ref biteArrayOne, ref biteArrayTwo);
            byte[] biteArraySum = CalculateSumOfEqualLengths(biteArrayOne, biteArrayTwo, wantedBase);
            return biteArraySum;
        }

        byte[] CalculateSubstraction(byte[] biteArrayOne, byte[] biteArrayTwo, int wantedBase)
        {
            biteArrayOne = InvertArray(biteArrayOne);
            biteArrayTwo = InvertArray(biteArrayTwo);
            EqualizeLengths(ref biteArrayOne, ref biteArrayTwo);
            var biteArraySubInt = CalculateSubArrayForEqualLenghts(wantedBase, biteArrayOne, biteArrayTwo);
            byte[] biteArraySub = ChangeToByte(biteArraySubInt);
            Array.Reverse(biteArraySub);
            biteArraySub = ConvertToByte(biteArraySub);
            Array.Reverse(biteArraySub);
            return biteArraySub; 
        }

        private static void EqualizeLengths(ref byte[] biteArrayOne, ref byte[] biteArrayTwo)
        {
            if (biteArrayOne.Length <= biteArrayTwo.Length)
            {
                biteArrayOne = AddToBeginning(biteArrayOne, (biteArrayTwo.Length - biteArrayOne.Length));
            }
            else
            {
                biteArrayTwo = AddToBeginning(biteArrayTwo, (biteArrayOne.Length - biteArrayTwo.Length));
            }
        }

        byte[] CalculateMultiplication(byte[] biteArrayOne, byte[] biteArrayTwo,int wantedBase)
        {
            biteArrayOne = InvertArray(biteArrayOne);
            biteArrayTwo = InvertArray(biteArrayTwo);
            byte[] biteArrayMult = new byte[biteArrayOne.Length];
            int minLength = MinimLength(biteArrayOne, biteArrayTwo);
            int shift = 0;
            CalculateMultArray(wantedBase, ref biteArrayOne, biteArrayTwo, ref biteArrayMult, ref shift);
            biteArrayMult=InvertArray(biteArrayMult);
            biteArrayMult=ConvertToByte(biteArrayMult);
            biteArrayMult=InvertArray(biteArrayMult);
            return biteArrayMult;
        }

        byte[] CalculateDivision(byte[]biteArrayOne,byte[]biteArrayTwo,int wantedBase)
        {
            biteArrayOne = InvertArray(biteArrayOne);
            biteArrayTwo = InvertArray(biteArrayTwo);
            byte[] biteArrayDiv = new byte[0];
            byte[] divident = new byte[0];
            biteArrayDiv=CalculateDivisionArray(biteArrayOne,biteArrayTwo, wantedBase,biteArrayDiv, divident);
            biteArrayDiv = InvertArray(biteArrayDiv);
            biteArrayDiv = ConvertToByte(biteArrayDiv);
            biteArrayDiv = InvertArray(biteArrayDiv);
            return biteArrayDiv;
        }

        byte[] CalculateDivisionArray(byte[] biteArrayOne,byte[] biteArrayTwo, int wantedBase,byte[] biteArrayDiv, byte[] divident)
        {
            int j = 0;

            for (int i = 0; i < biteArrayOne.Length; i++)
            {
                Array.Resize(ref divident, divident.Length + 1);
                j = divident.Length - 1;
                divident[j] = biteArrayOne[i];
                EqualizeLengths(ref biteArrayTwo, ref divident);
                Array.Resize(ref biteArrayDiv, biteArrayDiv.Length + 1);
                if (Equals(biteArrayTwo, divident) || IfLessThan(biteArrayTwo, divident))
                {

                    while (Equals(biteArrayTwo, divident) || IfLessThan(biteArrayTwo, divident))
                    {

                        EqualizeLengths(ref biteArrayTwo, ref divident);
                        divident = ChangeToByte(CalculateSubArrayForEqualLenghts(wantedBase, divident, biteArrayTwo));
                        biteArrayDiv[i] += 1;
                    }
                }
                else
                {
                    biteArrayDiv[i] = 0;
                }
            }
            return biteArrayDiv;
        }

        private void CalculateMultArray(int wantedBase, ref byte[] biteArrayOne, byte[] biteArrayTwo, ref byte[] biteArrayMult, ref int shift)
        {
            for (int i = biteArrayTwo.Length - 1; i >= 0; i--)
            {
                if (biteArrayTwo[i] != 0)
                {
                    int j = 0;
                    biteArrayOne = CalculateShiftLeftArray(shift, biteArrayOne);
                    shift = 0;
                    shift++;
                    byte[] biteTemp = new byte[biteArrayOne.Length];
                    byte counter = 0;
                    for (int k = biteTemp.Length - 1; k >= 0; k--)
                    {

                        biteTemp[k] = (byte)((biteArrayTwo[i] * biteArrayOne[k]) + counter);                        
                        if (biteTemp[k] == wantedBase)
                        {
                            biteTemp[k] = 0;
                            counter = 1;
                            if (k == 0)
                            {
                                biteTemp = Shift(biteTemp);
                                i++;
                            }

                        }
                        else if (biteTemp[k] > wantedBase)
                        {
                            biteTemp[k] = (byte)(biteTemp[k] % wantedBase);
                            counter = (byte)(biteTemp[k] / wantedBase);
                            if (k == 0)
                            {
                                biteTemp = Shift(biteTemp);
                                i++;
                            }
                        }
                        else counter = 0;
                    }
                    biteArrayMult = CalculateSumForArray(biteArrayMult,biteTemp ,wantedBase);
                }
                else shift++;
            }
        }

        byte[] Shift(byte[] biteArray)
        {
            Array.Resize(ref biteArray, biteArray.Length + 1);
            int k = biteArray.Length;
            for (k = biteArray.Length - 1; k > 0; k--)
            {
                biteArray[k] = biteArray[k - 1];
            }
            biteArray[0] = 0;
            return biteArray;
        }
       
        byte[] ChangeToByte(int[] biteArrayInt)
        {
            byte[] biteArrayByte = new byte[biteArrayInt.Length];
            for (int i =0; i< biteArrayInt.Length; i++)
            {
                biteArrayByte[i] = Convert.ToByte(biteArrayInt[i]);             
            }
            return biteArrayByte;
        }

        private static void ChangeToInt(byte[]byteArray,int[]intArray)
        {
            for (int i = byteArray.Length-1; i >= 0; i--)
            {
                intArray[i] = Convert.ToInt32(byteArray[i]);              
            }
        }

        int[] CalculateSubArrayForEqualLenghts(int wantedBase, byte[] biteArrayOne, byte[] biteArrayTwo)
        {
            var biteArraySub = new int[biteArrayOne.Length];
            for (int i =biteArrayTwo.Length-1; i >=0 ; i--)
            {               
                biteArraySub[i] = biteArrayOne[i]-biteArraySub[i] - biteArrayTwo[i];

                if (biteArraySub[i] < 0)
                {
                    biteArraySub[i] =biteArraySub[i] + wantedBase;
                    if (i == 0)
                    {
                        biteArrayOne = Shift(biteArrayOne);
                        biteArrayTwo = Shift(biteArrayTwo);
                        Array.Reverse(biteArraySub);
                        Array.Resize(ref biteArraySub, biteArraySub.Length + 1);
                        Array.Reverse(biteArraySub);
                        i++;
                    }
                    biteArraySub[i - 1] = 1;
                }
                else biteArraySub[i] = Math.Abs(biteArraySub[i]);
            }
            return biteArraySub;
        }

        byte[] CalculateSumOfEqualLengths(byte[] biteArrayOne,byte[] biteArrayTwo,int wantedBase)
        {
           
            byte[] biteArrayS = new byte[biteArrayTwo.Length];
            for (int i = biteArrayOne.Length-1; i >=0; i--) 
           {
                biteArrayS[i]=(byte)(biteArrayS[i]+biteArrayTwo[i]+biteArrayOne[i]);
                if (biteArrayS[i] == wantedBase)
                {
                    biteArrayS[i] = 0;
                    if (i == 0)
                    {
                        biteArrayOne=Shift(biteArrayOne);
                        biteArrayTwo=Shift(biteArrayTwo);
                        biteArrayS=Shift(biteArrayS);
                        i++;
                    }
                    biteArrayS[i - 1] += 1;
                }                             
                else if (biteArrayS[i] > wantedBase) 
                    {                
                    biteArrayS[i] =(byte)(biteArrayS[i]%wantedBase);
                    if (i == 0) 
                    {
                        biteArrayOne = Shift(biteArrayOne);
                        biteArrayTwo = Shift(biteArrayTwo);
                        biteArrayS = Shift(biteArrayS);
                        i++;
                    }
                    biteArrayS[i - 1] += 1;
                    }
            }
            return biteArrayS;
            
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

        private static bool Equals(byte[]biteArrayOne,byte[]biteArrayTwo)
        {
            EqualizeLengths(ref biteArrayOne,ref biteArrayTwo);
            for (int i = 0; i < biteArrayOne.Length; i++)
            {
                if (biteArrayOne[i] != biteArrayTwo[i])
                {
                    return false;                  
                }              
            }
            return true;
        }

        private static bool IfLessThan(byte[] biteArrayOne, byte[] biteArrayTwo)
        {
            EqualizeLengths(ref biteArrayOne, ref biteArrayTwo);
            for (int i = 0; i < biteArrayOne.Length;i++)
            {
                if (biteArrayTwo[i] > biteArrayOne[i])
                {
                    return true;   
                }  
                else if (biteArrayTwo[i] < biteArrayOne[i])
                {
                    return false;
                }                    
            }
            return false; 
        }

        private static byte[] AddToBeginning(byte[] biteArrayOne,int count)
        {
            Array.Reverse(biteArrayOne);
            Array.Resize(ref biteArrayOne, biteArrayOne.Length + count);
            Array.Reverse(biteArrayOne);
            return biteArrayOne;
        }

        byte[] CalculateShiftRightArray(int shiftRight,byte[] biteArray)
        {        
            Array.Resize(ref biteArray, biteArray.Length - shiftRight);                
            return biteArray;          
        }

        byte[] CalculateShiftLeftArray(int shiftLeft, byte[] biteArray)
        {       
        Array.Resize(ref biteArray, biteArray.Length + shiftLeft);   
            return biteArray;          
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
