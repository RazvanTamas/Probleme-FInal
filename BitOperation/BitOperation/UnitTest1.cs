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
            CollectionAssert.AreEqual(ToBase(20,2), CalculateSum(CalculateBinaryNumberInArray(15,2),CalculateBinaryNumberInArray(5,2), 2));
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
        [TestMethod]
        public void TestAndOrXorCases()
        {
            CollectionAssert.AreEqual(ToBase(6, 2), CalculateAndOrXOrOperation("XOr", CalculateBinaryNumberInArray(5, 2), CalculateBinaryNumberInArray(3, 2), 2));
        }
        [TestMethod]
        public void TestAndOrXOrOperationTypeTwo()
        {
            CollectionAssert.AreEqual(ToBase(6, 2), CalculateAndOrXOrOperationTypeTwo("XOr", CalculateBinaryNumberInArray(5, 2), CalculateBinaryNumberInArray(3, 2), 2));
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
                bitArrayOr[i] = (bitArrayOne[i] == 0 && bitArrayTwo[i] == 0) ? (byte)0 : (byte)1;
            return bitArrayOr;
        }

        byte[] CalculateAndOperation(byte[] bitArrayOne, byte[] bitArrayTwo, int wantedBase)
        {
            bitArrayOne = ConvertToByte(bitArrayOne);
            bitArrayTwo = ConvertToByte(bitArrayTwo);
            byte[] bitArrayAnd = new byte[bitArrayOne.Length];
            for (int i = 0; i < bitArrayOne.Length; i++)
                bitArrayAnd[i] = (bitArrayOne[i] == 1 && bitArrayTwo[i] == 1) ? (byte)1 : (byte)0;
            return bitArrayAnd;
        }

        byte[] CalculateXOrOperation(byte[] bitArrayOne, byte[] bitArrayTwo, int wantedBase)
        {
            bitArrayOne = ConvertToByte(bitArrayOne);
            bitArrayTwo = ConvertToByte(bitArrayTwo);
            byte[] bitArrayXOr = new byte[bitArrayOne.Length];
            for (int i = 0; i < bitArrayOne.Length; i++)
                   bitArrayXOr[i] = (bitArrayOne[i] == bitArrayTwo[i]) ? (byte)0 : (byte)1;                
            return bitArrayXOr;
        }

        byte[] CalculateAndOrXOrOperation(string operation,byte[] bitArrayOne,byte[]bitArrayTwo,int wantedBase)
        {          
            switch (operation)
            {
                case "And":
                    var bitArrayResultAnd = CalculateAndOperation(bitArrayOne, bitArrayTwo, wantedBase);
                    return bitArrayResultAnd;
                case "Or":
                    var bitArrayResultOr = CalculateOrOperation(bitArrayOne, bitArrayTwo, wantedBase);
                    return bitArrayResultOr;
                case "XOr":
                    var bitArrayResultXOr = CalculateXOrOperation(bitArrayOne, bitArrayTwo, wantedBase);
                    return bitArrayResultXOr;
            }
            return new byte[]{ 0,0,0};                   
        }

        byte[] CalculateAndOrXOrOperationTypeTwo(string operation, byte[] bitArrayOne, byte[] bitArrayTwo, int wantedBase)
        {
            bitArrayOne = ConvertToByte(bitArrayOne);
            bitArrayTwo = ConvertToByte(bitArrayTwo);
            byte[] bitArrayResult = new byte[bitArrayOne.Length];
            for (int i = 0; i < bitArrayOne.Length; i++)
            {
                switch (operation)
                {
                    case "And":
                        bitArrayResult[i] = (bitArrayOne[i] == 1 && bitArrayTwo[i] == 1) ? (byte)1 : (byte)0; 
                        break;
                    case "Or":
                        bitArrayResult[i] = (bitArrayOne[i] == 0 && bitArrayTwo[i] == 0) ? (byte)0 : (byte)1;
                        break;
                    case "XOr":
                        bitArrayResult[i] = (bitArrayOne[i] == bitArrayTwo[i]) ? (byte)0 : (byte)1;
                        break;
                }
            }
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
            var bitArraySub = CalculateSubArray(wantedBase, bitArrayOne, bitArrayTwo);                   
            bitArraySub = ConvertToByte(bitArraySub);          
            return bitArraySub; 
        }
 
        byte[] CalculateMultiplication(byte[] bitArrayOne, byte[] bitArrayTwo,int wantedBase)
        {        
            byte[] bitArrayMult= CalculateMultArray(wantedBase,bitArrayOne, bitArrayTwo);
            bitArrayMult =ConvertToByte(bitArrayMult);      
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
                        divident =CalculateSubArray(wantedBase, divident, bitArrayTwo);
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

        byte[] CalculateMultArray(int wantedBase,byte[] bitArrayOne, byte[] bitArrayTwo)
        {            
            byte[] bitArrayMult = { 0 };
            for (byte[] i = { 0 }; IfLessThan(i, bitArrayTwo); i = CalculateSumArray(i, new byte[] { 1 }, wantedBase))
            {
               bitArrayMult= CalculateSumArray(bitArrayMult, bitArrayOne, wantedBase);
            }           
            return bitArrayMult;

        }  

        byte[] CalculateSubArray(int wantedBase, byte[] bitArrayOne, byte[] bitArrayTwo)
        {
            Array.Reverse(bitArrayOne); Array.Reverse(bitArrayTwo);         
            var bitArraySub = new byte[Math.Max(bitArrayOne.Length, bitArrayTwo.Length)];
            int borrow = 0;
            for (int i = 0; i < Math.Max(bitArrayOne.Length, bitArrayTwo.Length); i++) 
            {
                int sub= ValueAtIndex(bitArrayOne, i) - ValueAtIndex(bitArrayTwo, i) - borrow;
                borrow = (sub < 0) ? 1 : 0;
                sub = Math.Abs(sub);              
                bitArraySub[i] =(byte)(sub%wantedBase);                                                       
            }                  
            Array.Reverse(bitArraySub);
            return bitArraySub;
        }

        byte[] CalculateSumArray(byte[] bitArrayOne, byte[] bitArrayTwo, int wantedBase)
        {
            Array.Reverse(bitArrayOne);Array.Reverse(bitArrayTwo);              
            byte[] bitArrayS = new byte[Math.Max(bitArrayOne.Length, bitArrayTwo.Length) +1];       
            int carry = 0;
            for (int i =0; i <Math.Max(bitArrayOne.Length, bitArrayTwo.Length); i++)
            {
                int add = ValueAtIndex(bitArrayOne, i) + ValueAtIndex(bitArrayTwo, i) + carry;
                bitArrayS[i] = (byte)(add % wantedBase);
                carry = (byte)(add / wantedBase);                  
            }
            bitArrayS[bitArrayS.Length - 1] =(byte)carry;
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

        public bool IfLessThan(byte[] bitArrayOne, byte[] bitArrayTwo)
        {
            
            for (int i = Math.Max(bitArrayOne.Length, bitArrayTwo.Length); i >= 0; i--)
            {
                if (ValueAtIndex(bitArrayOne, i) != ValueAtIndex(bitArrayTwo, i))
                {
                    return (ValueAtIndex(bitArrayOne, i) < ValueAtIndex(bitArrayTwo, i));
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
