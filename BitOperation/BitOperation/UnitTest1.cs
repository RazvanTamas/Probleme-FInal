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

        byte[] CalculateNotOperation(byte[]bitArray, int wantedBase)
        {
            bitArray = ConvertToByte(bitArray);          
            bitArray=CalculateNot(bitArray);         
            return bitArray;
        }

        byte[] CalculateOrOperation(byte[] bitArrayOne, byte[] bitArrayTwo, int wantedBase)
        { 
            bitArrayOne = ConvertToByte(bitArrayOne);
            bitArrayTwo = ConvertToByte(bitArrayTwo);
            byte[] bitArrayOr = new byte[bitArrayOne.Length];
            for (int i = 0; i < bitArrayOne.Length; i++)
                bitArrayOr[i] = CalculateOrArray(bitArrayOne[i], bitArrayTwo[i]);
            return bitArrayOr;
        }

        byte[] CalculateAndOperation(byte[] bitArrayOne, byte[] bitArrayTwo, int wantedBase)
        {
            bitArrayOne = ConvertToByte(bitArrayOne);
            bitArrayTwo = ConvertToByte(bitArrayTwo);
            byte[] bitArrayAnd = new byte[bitArrayOne.Length];
            for (int i = 0; i < bitArrayOne.Length; i++)
                bitArrayAnd[i] = CalculateAndArray(bitArrayOne[i], bitArrayTwo[i]);        
            return bitArrayAnd;
        }

        byte[] CalculateXOrOperation(byte[] bitArrayOne, byte[] bitArrayTwo, int wantedBase)
        {
            bitArrayOne = ConvertToByte(bitArrayOne);
            bitArrayTwo = ConvertToByte(bitArrayTwo);
            byte[] bitArrayXOr = new byte[bitArrayOne.Length];
            for (int i = 0; i < bitArrayOne.Length; i++)
                   bitArrayXOr[i] = CalculateXOrArray(bitArrayOne[i], bitArrayTwo[i]);                
            return bitArrayXOr;
        }

        byte[] CalculateAndOrXorOperation(string operation,byte[] bitArrayOne,byte[]bitArrayTwo,int wantedBase)
        {
            var bitArrayResult = new byte[0];       
            return bitArrayResult;
        }

        byte[] CalculateRightHandShiftOperation(byte[] bitArray, int wantedBase, int shiftRight)
        {                                        
            byte[] binaryNumberShiftRight = new byte[bitArray.Length];                     
            bitArray=CalculateShiftRightArray(shiftRight,bitArray);          
            bitArray = ConvertToByte(bitArray);                             
            return bitArray;
        } 

        byte[] CalculateLeftHandShiftOperation(byte[]bitArray, int wantedBase, int shiftLeft)
        {                    
                                    
            bitArray=CalculateShiftLeftArray(shiftLeft,bitArray);                       
            bitArray= ConvertToByte(bitArray);            
            return bitArray;
        }
        
        bool CalculateIfLessThan(byte[] bitArrayOne, byte[] bitArrayTwo, int wantedBase)
        {           
            bool lessThan = IfLessThan(bitArrayOne, bitArrayTwo);         
            return lessThan;
        }

        byte[] CalculateSum(byte[]bitArrayOne,byte[]bitArrayTwo,int wantedBase)
        {        
            byte[] bitArraySum=CalculateSumArray(bitArrayOne,bitArrayTwo,wantedBase);                              
            bitArraySum = ConvertToByte(bitArraySum);             
            return bitArraySum;
        }

        byte[] CalculateSumForArray(byte[]bitArrayOne,byte[]bitArrayTwo,int wantedBase)
        {           
            byte[] bitArraySum = CalculateSumArray(bitArrayOne, bitArrayTwo, wantedBase);
            return bitArraySum;
        }

        byte[] CalculateSubstraction(byte[] bitArrayOne, byte[] bitArrayTwo, int wantedBase)
        {                     
            var bitArraySubInt = CalculateSubArray(wantedBase, bitArrayOne, bitArrayTwo);
            byte[] bitArraySub = ChangeToByte(bitArraySubInt);         
            bitArraySub = ConvertToByte(bitArraySub);          
            return bitArraySub; 
        }
 
        byte[] CalculateMultiplication(byte[] bitArrayOne, byte[] bitArrayTwo,int wantedBase)
        {        
            byte[] bitArrayMult = new byte[bitArrayOne.Length];         
            int shift = 0;
            CalculateMultArray(wantedBase, ref bitArrayOne, bitArrayTwo, ref bitArrayMult, ref shift);         
            bitArrayMult=ConvertToByte(bitArrayMult);      
            return bitArrayMult;
        }

        byte[] CalculateDivision(byte[]bitArrayOne,byte[]bitArrayTwo,int wantedBase)
        {       
            byte[] bitArrayDiv = new byte[0];
            byte[] divident = new byte[0];
            bitArrayDiv=CalculateDivisionArray(bitArrayOne,bitArrayTwo, wantedBase,bitArrayDiv, divident);           
            bitArrayDiv = ConvertToByte(bitArrayDiv);        
            return bitArrayDiv;
        }

        byte[] CalculateDivisionArray(byte[] bitArrayOne,byte[] bitArrayTwo, int wantedBase,byte[] bitArrayDiv, byte[] divident)
        {                         
            for (int i = 0; i < bitArrayOne.Length; i++)
            {
                Array.Resize(ref divident, divident.Length + 1);             
                divident[divident.Length - 1] = bitArrayOne[i];             
                Array.Resize(ref bitArrayDiv, bitArrayDiv.Length + 1);
                if (Equals(bitArrayTwo, divident) || IfLessThan(bitArrayTwo, divident))
                {

                    while (Equals(bitArrayTwo, divident) || IfLessThan(bitArrayTwo, divident))
                    {                   
                        divident = ChangeToByte(CalculateSubArray(wantedBase, divident, bitArrayTwo));
                        bitArrayDiv[i] += 1;
                        divident = TrimArray(divident);
                    }
                }
                else
                {
                    bitArrayDiv[i] = 0;
                }
            }           
            return bitArrayDiv;
        }

        private void CalculateMultArray(int wantedBase, ref byte[] bitArrayOne, byte[] bitArrayTwo, ref byte[] bitArrayMult, ref int shift)
        {
            for (int i = bitArrayTwo.Length - 1; i >= 0; i--)
            {
                if (bitArrayTwo[i] != 0)
                {                  
                    bitArrayOne = CalculateShiftLeftArray(shift, bitArrayOne);
                    shift = 0;
                    shift++;
                    byte[] biteTemp = new byte[bitArrayOne.Length];                
                    for (int k = biteTemp.Length - 1; k >= 0; k--)
                    {
                        MultiplicationTemp(wantedBase, bitArrayOne, bitArrayTwo, ref i, ref biteTemp, k);
                    }
                    bitArrayMult = CalculateSumForArray(bitArrayMult,biteTemp ,wantedBase);
                }
                else shift++;
            }
        }

        private void MultiplicationTemp(int wantedBase, byte[] bitArrayOne, byte[] bitArrayTwo, ref int i, ref byte[] bitTemp, int k)
        {
            bitTemp[k] = (byte)((bitArrayTwo[i] * bitArrayOne[k]) + bitTemp[k]);
            if (bitTemp[k] == wantedBase)
            {
                bitTemp[k] = 0;
                if (k == 0)
                {
                    bitTemp = Shift(bitTemp);
                    bitTemp[k] += 1;
                }
                else bitTemp[k - 1] += 1; 

            }
            else if (bitTemp[k] > wantedBase)
            {
                bitTemp[k] = (byte)(bitTemp[k] % wantedBase);
                if (k == 0)
                {
                    bitTemp = Shift(bitTemp);
                    bitTemp[k] = (byte)(bitTemp[k] / wantedBase);
                }
                else bitTemp[k-1]= (byte)(bitTemp[k] / wantedBase);
            }          
        }

        byte[] Shift(byte[] bitArray)
        {
            Array.Resize(ref bitArray, bitArray.Length + 1);
            int k = bitArray.Length;
            for (k = bitArray.Length - 1; k > 0; k--)
            {
                bitArray[k] = bitArray[k - 1];
            }
            bitArray[0] = 0;
            return bitArray;
        }
       
        byte[] ChangeToByte(int[] bitArrayInt)
        {
            byte[] bitArrayByte = new byte[bitArrayInt.Length];
            for (int i =0; i< bitArrayInt.Length; i++)
            {
                bitArrayByte[i] = Convert.ToByte(bitArrayInt[i]);             
            }
            return bitArrayByte;
        }

        private static void ChangeToInt(byte[]byteArray,int[]intArray)
        {
            for (int i = byteArray.Length-1; i >= 0; i--)
            {
                intArray[i] = Convert.ToInt32(byteArray[i]);              
            }
        }

        int[] CalculateSubArray(int wantedBase, byte[] bitArrayOne, byte[] bitArrayTwo)
        {
            Array.Reverse(bitArrayOne); Array.Reverse(bitArrayTwo);
            int maxLength = Math.Max(bitArrayOne.Length, bitArrayTwo.Length);
            var bitArraySub = new int[maxLength];
            for (int i = 0; i < maxLength; i++) 
            {
                bitArraySub[i] = (int)(ValueAtIndex(bitArrayOne, i) - ValueAtIndex(bitArrayTwo, i) - bitArraySub[i]);
                if (bitArraySub[i] < 0)
                {
                    bitArraySub[i] =bitArraySub[i] + wantedBase;
                    if (i == maxLength-1)  Array.Resize(ref bitArraySub, bitArraySub.Length + 1);                       
                    bitArraySub[i + 1] =1;
                }             
            }
            Array.Reverse(bitArraySub);
            return bitArraySub;
        }

        byte[] CalculateSumArray(byte[] bitArrayOne, byte[] bitArrayTwo, int wantedBase)
        {
            Array.Reverse(bitArrayOne);Array.Reverse(bitArrayTwo);   
            int maxLength = Math.Max(bitArrayOne.Length, bitArrayTwo.Length);
            byte[] bitArrayS = new byte[maxLength];
            for (int i =0; i <maxLength; i++)
            {
                bitArrayS[i] = (byte)(bitArrayS[i] + ValueAtIndex(bitArrayOne, i) + ValueAtIndex(bitArrayTwo, i));
                if (bitArrayS[i] == wantedBase)
                {
                    bitArrayS[i] = 0;
                    if (i == maxLength-1) Array.Resize(ref bitArrayS, bitArrayS.Length + 1);
                    bitArrayS[i + 1] += 1;
                }
                else if (bitArrayS[i] > wantedBase)
                {
                    bitArrayS[i] = (byte)(bitArrayS[i] % wantedBase);
                    if (i == maxLength-1) Array.Resize(ref bitArrayS, bitArrayS.Length + 1);                   
                    bitArrayS[i + 1] += 1;
                }
            }
            Array.Reverse(bitArrayS);      
            return bitArrayS;         
        }
       
        private static bool Equals(byte[]bitArrayOne,byte[]bitArrayTwo)
        {
           if (bitArrayOne.Length == bitArrayTwo.Length)
            { 
                for (int i = 0; i < bitArrayOne.Length; i++)
                    if (bitArrayOne[i] != bitArrayTwo[i]) return false;               
                return true;
            }
            return false;
        }  

        byte ValueAtIndex(byte[] bitArray,int i)
        {
            return (i < bitArray.Length ) ? bitArray[i] :(byte) 0;
        }

        private static bool IfLessThan(byte[] bitArrayOne, byte[] bitArrayTwo)
        {                     
            int maxLength = Math.Max(bitArrayOne.Length, bitArrayTwo.Length);
            int minLength = Math.Min(bitArrayOne.Length, bitArrayTwo.Length);
            if (bitArrayOne.Length < maxLength) return true;
            else if (bitArrayOne.Length > minLength) return false;
            for (int i = 0; i < minLength; i++)
            {
                if (bitArrayTwo[i] > bitArrayOne[i])
                {
                    return true;
                }
                else if (bitArrayTwo[i] < bitArrayOne[i])
                {
                    return false;
                }
            }
            return false;

        }

        private static byte[] AddOrRemoveFromTheBeginning(byte[] bitArrayOne,int count)
        {
            Array.Reverse(bitArrayOne);
            Array.Resize(ref bitArrayOne, bitArrayOne.Length + count);
            Array.Reverse(bitArrayOne);
            return bitArrayOne;
        }

        byte[] CalculateShiftRightArray(int shiftRight,byte[] bitArray)
        {        
            Array.Resize(ref bitArray, bitArray.Length - shiftRight);                
            return bitArray;          
        }

        byte[] CalculateShiftLeftArray(int shiftLeft, byte[] bitArray)
        {       
        Array.Resize(ref bitArray, bitArray.Length + shiftLeft);   
            return bitArray;          
        }

        byte CalculateXOrArray(byte bitArrayOne, byte bitArrayTwo)
        {                             
            return (bitArrayOne == bitArrayTwo) ? (byte)0 : (byte)1;            
        }

        byte CalculateAndArray(byte bitArrayOne, byte bitArrayTwo)
        {         
            return (bitArrayOne == 1 && bitArrayTwo == 1) ? (byte)1 : (byte)0;  
        }

        byte CalculateOrArray(byte bitArrayOne, byte bitArrayTwo)
        {
            return (bitArrayOne == 0 && bitArrayTwo == 0)? (byte)0 : (byte)1;               
        }

        byte[] ConvertToByte(byte[] bitArray)
        {
            Array.Reverse(bitArray);
            decimal length = bitArray.Length;
            for (int i = bitArray.Length; i < (Math.Ceiling(length/8))*8; i++)
            {
                Array.Resize(ref bitArray, bitArray.Length + 1);
                bitArray[i] = 0;
            }
            Array.Reverse(bitArray);
            return bitArray;
        }

        byte[] CalculateNot(byte[] bitArray)
        {
            for (int i = bitArray.Length-1; i >=0; i--)
            {
                if (bitArray[i] == 0)
                {
                    bitArray[i] += 1;           
                }            

                else
                {
                    bitArray[i] -= 1;
                }
            }
            return bitArray;
        }

        byte[] CalculateBinaryNumberInArray(int number, int wantedBase)
        {
            byte[] bitArray =new byte[0];
            while (number != 0)
            {
                Array.Resize(ref bitArray, bitArray.Length + 1);
                bitArray[bitArray.Length - 1] = (byte)(number % wantedBase);
                number = number / wantedBase;               
            }
            Array.Reverse(bitArray);
            return bitArray;
        }

        byte[]InvertArray(byte[] bitArray)
        {
            int n = 0;
            byte[] newBitArray = new byte[bitArray.Length];
            for (int i = bitArray.Length - 1; i >= 0; i--)
            {
                newBitArray[n] = bitArray[i];
                n++;
            }

            return newBitArray;
        }

        byte[] TrimArray(byte[] bitArray)
        {
            for(int i = 0; i < bitArray.Length; i++)
            {
                if (bitArray[i] == 0)
                {
                    bitArray=AddOrRemoveFromTheBeginning(bitArray, -1);
                    i--;
                }                
                else break;
            }
            return bitArray;
        }
    }
}
