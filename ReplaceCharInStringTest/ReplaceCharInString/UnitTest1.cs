using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReplaceCharInString
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual("aaaaaaStringAddedaaaa",ReplaceCharInString("aaaaaabaaaa",'b',"StringAdded"));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual("aaaaaaStringAddedaaaa", ReplaceCharInStringWithRecursion("aaaaaabaaaa", 'b', "StringAdded"));
        }

        string ReplaceCharInString(string stringGiven,char charToReplace,string stringToAddInPlaceOfChar)
        {
            string charToReplaceConvertedToString = charToReplace.ToString();
            stringGiven = stringGiven.Replace(charToReplaceConvertedToString, stringToAddInPlaceOfChar);
            return stringGiven;
        }

        string ReplaceCharInStringWithRecursion(string stringGiven,char charToReplace,string stringToAddInPlaceOfChar)
        {
            string newString = "";
            int i = stringGiven.Length - 1;
            newString = RecursiveFunction(stringGiven, charToReplace, stringToAddInPlaceOfChar, i);
            return newString;
        }
        string RecursiveFunction(string stringGiven,char charToReplace,string stringToAddInPlaceOfChar,int i)
        {
            if (i > 0)
            {
                if (stringGiven[i] == charToReplace)
                    return RecursiveFunction(stringGiven, charToReplace, stringToAddInPlaceOfChar, i-1)+ stringToAddInPlaceOfChar;
                else
                    return  RecursiveFunction(stringGiven, charToReplace, stringToAddInPlaceOfChar, i-1)+stringGiven[i];
            }
            else return stringGiven[i].ToString();
        }
    }
}
