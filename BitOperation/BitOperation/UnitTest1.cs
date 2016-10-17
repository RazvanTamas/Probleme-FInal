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
            return biteArray;
        }

        byte[] CalculateNotOperation(byte[]biteArray, int wantedBase)
        {
            biteArray = ConvertToByte(biteArray);          
            CalculateNot(biteArray);         
            return biteArray;
        }

        byte[] CalculateOrOperation(byte[] biteArrayOne, byte[] biteArrayTwo, int wantedBase)
        { 
            biteArrayOne = ConvertToByte(biteArrayOne);
            biteArrayTwo = ConvertToByte(biteArrayTwo);
            byte[] biteArrayOr= CalculateOrArray(biteArrayOne, biteArrayTwo);
            return biteArrayOr;
        }

        byte[] CalculateAndOperation(byte[] biteArrayOne, byte[] biteArrayTwo, int wantedBase)
        {
            biteArrayOne = ConvertToByte(biteArrayOne);
            biteArrayTwo = ConvertToByte(biteArrayTwo);
            byte[] biteArrayAnd = CalculateAndArray(biteArrayOne, biteArrayTwo);
            return biteArrayAnd;
        }

        byte[] CalculateXOrOperation(byte[] biteArrayOne, byte[] biteArrayTwo, int wantedBase)
        {
            biteArrayOne = ConvertToByte(biteArrayOne);
            biteArrayTwo = ConvertToByte(biteArrayTwo);
            byte[] biteArrayXOr = CalculateXOrArray(biteArrayOne, biteArrayTwo);
            return biteArrayXOr;
        }

        byte[] CalculateRightHandShiftOperation(byte[] biteArray, int wantedBase, int shiftRight)
        {                                        
            byte[] binaryNumberShiftRight = new byte[biteArray.Length];                     
            biteArray=CalculateShiftRightArray(shiftRight,biteArray);          
            biteArray = ConvertToByte(biteArray);                             
            return biteArray;
        } 

        byte[] CalculateLeftHandShiftOperation(byte[]biteArray, int wantedBase, int shiftLeft)
        {                    
                                    
            biteArray=CalculateShiftLeftArray(shiftLeft,biteArray);                       
            biteArray= ConvertToByte(biteArray);            
            return biteArray;
        }
        
        bool CalculateIfLessThan(byte[] biteArrayOne, byte[] biteArrayTwo, int wantedBase)
        {           
            bool lessThan = IfLessThan(biteArrayOne, biteArrayTwo);         
            return lessThan;
        }

        byte[] CalculateSum(byte[]biteArrayOne,byte[]biteArrayTwo,int wantedBase)
        {        
            byte[] biteArraySum=CalculateSumArray(biteArrayOne,biteArrayTwo,wantedBase);                              
            biteArraySum = ConvertToByte(biteArraySum);             
            return biteArraySum;
        }

        byte[] CalculateSumForArray(byte[]biteArrayOne,byte[]biteArrayTwo,int wantedBase)
        {           
            byte[] biteArraySum = CalculateSumArray(biteArrayOne, biteArrayTwo, wantedBase);
            return biteArraySum;
        }

        byte[] CalculateSubstraction(byte[] biteArrayOne, byte[] biteArrayTwo, int wantedBase)
        {                     
            var biteArraySubInt = CalculateSubArray(wantedBase, biteArrayOne, biteArrayTwo);
            byte[] biteArraySub = ChangeToByte(biteArraySubInt);         
            biteArraySub = ConvertToByte(biteArraySub);          
            return biteArraySub; 
        }
 
        byte[] CalculateMultiplication(byte[] biteArrayOne, byte[] biteArrayTwo,int wantedBase)
        {        
            byte[] biteArrayMult = new byte[biteArrayOne.Length];         
            int shift = 0;
            CalculateMultArray(wantedBase, ref biteArrayOne, biteArrayTwo, ref biteArrayMult, ref shift);         
            biteArrayMult=ConvertToByte(biteArrayMult);      
            return biteArrayMult;
        }

        byte[] CalculateDivision(byte[]biteArrayOne,byte[]biteArrayTwo,int wantedBase)
        {       
            byte[] biteArrayDiv = new byte[0];
            byte[] divident = new byte[0];
            biteArrayDiv=CalculateDivisionArray(biteArrayOne,biteArrayTwo, wantedBase,biteArrayDiv, divident);           
            biteArrayDiv = ConvertToByte(biteArrayDiv);        
            return biteArrayDiv;
        }

        byte[] CalculateDivisionArray(byte[] biteArrayOne,byte[] biteArrayTwo, int wantedBase,byte[] biteArrayDiv, byte[] divident)
        {                         
            for (int i = 0; i < biteArrayOne.Length; i++)
            {
                Array.Resize(ref divident, divident.Length + 1);             
                divident[divident.Length - 1] = biteArrayOne[i];             
                Array.Resize(ref biteArrayDiv, biteArrayDiv.Length + 1);
                if (Equals(biteArrayTwo, divident) || IfLessThan(biteArrayTwo, divident))
                {

                    while (Equals(biteArrayTwo, divident) || IfLessThan(biteArrayTwo, divident))
                    {                   
                        divident = ChangeToByte(CalculateSubArray(wantedBase, divident, biteArrayTwo));
                        biteArrayDiv[i] += 1;
                        divident = TrimArray(divident);
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
                    biteArrayOne = CalculateShiftLeftArray(shift, biteArrayOne);
                    shift = 0;
                    shift++;
                    byte[] biteTemp = new byte[biteArrayOne.Length];                
                    for (int k = biteTemp.Length - 1; k >= 0; k--)
                    {
                        MultiplicationTemp(wantedBase, biteArrayOne, biteArrayTwo, ref i, ref biteTemp, k);
                    }
                    biteArrayMult = CalculateSumForArray(biteArrayMult,biteTemp ,wantedBase);
                }
                else shift++;
            }
        }

        private void MultiplicationTemp(int wantedBase, byte[] biteArrayOne, byte[] biteArrayTwo, ref int i, ref byte[] biteTemp, int k)
        {
            biteTemp[k] = (byte)((biteArrayTwo[i] * biteArrayOne[k]) + biteTemp[k]);
            if (biteTemp[k] == wantedBase)
            {
                biteTemp[k] = 0;
                if (k == 0)
                {
                    biteTemp = Shift(biteTemp);
                    biteTemp[k] += 1;
                }
                else biteTemp[k - 1] += 1; 

            }
            else if (biteTemp[k] > wantedBase)
            {
                biteTemp[k] = (byte)(biteTemp[k] % wantedBase);
                if (k == 0)
                {
                    biteTemp = Shift(biteTemp);
                    biteTemp[k] = (byte)(biteTemp[k] / wantedBase);
                }
                else biteTemp[k-1]= (byte)(biteTemp[k] / wantedBase);
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

        int[] CalculateSubArray(int wantedBase, byte[] biteArrayOne, byte[] biteArrayTwo)
        {
            Array.Reverse(biteArrayOne); Array.Reverse(biteArrayTwo);
            int maxLength = Math.Max(biteArrayOne.Length, biteArrayTwo.Length);
            var biteArraySub = new int[maxLength];
            for (int i = 0; i < maxLength; i++) 
            {
                if (i < biteArrayOne.Length) biteArraySub[i] = biteArrayOne[i]-biteArraySub[i];
                if (i < biteArrayTwo.Length) biteArraySub[i] -=biteArrayTwo[i];
                if (biteArraySub[i] < 0)
                {
                    biteArraySub[i] =biteArraySub[i] + wantedBase;
                    if (i == biteArraySub.Length-1)  Array.Resize(ref biteArraySub, biteArraySub.Length + 1);                       
                    biteArraySub[i + 1] =1;
                }             
            }
            Array.Reverse(biteArraySub);
            return biteArraySub;
        }

        byte[] CalculateSumArray(byte[] biteArrayOne, byte[] biteArrayTwo, int wantedBase)
        {
            Array.Reverse(biteArrayOne);Array.Reverse(biteArrayTwo);
            int maxLength = Math.Max(biteArrayOne.Length, biteArrayTwo.Length);
            byte[] biteArrayS = new byte[maxLength];
            for (int i = 0; i < maxLength; i++)
            {               
                if (i < biteArrayOne.Length) biteArrayS[i] += biteArrayOne[i];
                if (i < biteArrayTwo.Length) biteArrayS[i] += biteArrayTwo[i];
                if (biteArrayS[i] == wantedBase)
                {
                    biteArrayS[i] = 0;
                    if (i == biteArrayS.Length-1) Array.Resize(ref biteArrayS, biteArrayS.Length + 1);
                    biteArrayS[i + 1] += 1;
                }
                else if (biteArrayS[i] > wantedBase)
                {
                    biteArrayS[i] = (byte)(biteArrayS[i] % wantedBase);
                    if (i == biteArrayS.Length-1) Array.Resize(ref biteArrayS, biteArrayS.Length + 1);
                    biteArrayS[i + 1] += 1;
                }
            }
            Array.Reverse(biteArrayS);      
            return biteArrayS;         
        }
       
        private static bool Equals(byte[]biteArrayOne,byte[]biteArrayTwo)
        {
           if (biteArrayOne.Length == biteArrayTwo.Length)
            { 
                for (int i = 0; i < biteArrayOne.Length; i++)
                    if (biteArrayOne[i] != biteArrayTwo[i]) return false;               
                return true;
            }
            return false;
        }  

        private static bool IfLessThan(byte[] biteArrayOne, byte[] biteArrayTwo)
        {                     
            int maxLength = Math.Max(biteArrayOne.Length, biteArrayTwo.Length);
            int minLength = Math.Min(biteArrayOne.Length, biteArrayTwo.Length);
            if (biteArrayOne.Length < maxLength) return true;
            else if (biteArrayOne.Length > minLength) return false;
            for (int i = 0; i < minLength; i++)
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

        private static byte[] AddOrRemoveFromTheBeginning(byte[] biteArrayOne,int count)
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

        byte[] CalculateXOrArray(byte[] biteArrayOne, byte[] biteArrayTwo)
        {
            byte[] biteArrayXOr = new byte[biteArrayOne.Length];
            for (int i = 0; i < biteArrayOne.Length; i++)
            {
                if (biteArrayOne[i] == biteArrayTwo[i])
                {
                    biteArrayXOr[i] = 0;
                }
                else biteArrayXOr[i] = 1;
            }
            return biteArrayXOr;
        }

        byte[] CalculateAndArray(byte[] biteArrayOne, byte[] biteArrayTwo)
        {
            byte[] biteArrayAnd = new byte[biteArrayOne.Length];
            for (int i = 0; i < biteArrayOne.Length; i++)
            {
                if (biteArrayOne[i] == 1 && biteArrayTwo[i] == 1)
                {
                    biteArrayAnd[i] = 1;
                }
                else biteArrayAnd[i] = 0;
            }
            return biteArrayAnd;
        }

        byte[] CalculateOrArray(byte[] biteArrayOne, byte[] biteArrayTwo)
        {
            byte[] biteArrayOr = new byte[biteArrayOne.Length];
            for (int i = 0; i < biteArrayOne.Length; i++)
            {
                if (biteArrayOne[i] == 0 && biteArrayTwo[i] == 0)
                {
                    biteArrayOr[i] = 0;                 
                }
                else biteArrayOr[i] = 1;
            }
            return biteArrayOr;
        }

        byte[] ConvertToByte(byte[] biteArray)
        {
            Array.Reverse(biteArray);
            decimal length = biteArray.Length;
            for (int i = biteArray.Length; i < (Math.Ceiling(length/8))*8; i++)
            {
                Array.Resize(ref biteArray, biteArray.Length + 1);
                biteArray[i] = 0;
            }
            Array.Reverse(biteArray);
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
            Array.Reverse(biteArray);
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
        byte[] TrimArray(byte[] biteArray)
        {
            for(int i = 0; i < biteArray.Length; i++)
            {
                if (biteArray[i] == 0)
                {
                    biteArray=AddOrRemoveFromTheBeginning(biteArray, -1);
                    i--;
                }                
                else break;
            }
            return biteArray;
        }
    }
}
