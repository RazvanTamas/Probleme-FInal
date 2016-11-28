using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReplaceCharInString
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestWithoutRecursion()
        {
            Assert.AreEqual("aaaaaaStringAddedaaaa",ReplaceCharInString("aaaaaabaaaa",'b',"StringAdded"));
        }

        [TestMethod]
        public void TestWithRecursion()
        {
            Assert.AreEqual("aaaaaaStringAddedaaaa", ReplaceCharInStringWithRecursion("aaaaaabaaaa", 'b', "StringAdded"));
        }

        [TestMethod]
        public void TestWithEmptyString()
        {
            Assert.AreEqual("String is empty", ReplaceCharInStringWithRecursion("", 'a', "StringAdded"));
        }

        string ReplaceCharInString(string stringGiven,char charToReplace,string stringToAddInPlaceOfChar)
        {
            if (stringGiven.Length == 0)
                return "String is empty";
            string charToReplaceConvertedToString = charToReplace.ToString();
            stringGiven = stringGiven.Replace(charToReplaceConvertedToString, stringToAddInPlaceOfChar);
            return stringGiven;
        }

        string ReplaceCharInStringWithRecursion(string stringGiven,char charToReplace,string stringToAddInPlaceOfChar)
        {
            if (stringGiven.Length == 0)
                return "String is empty";
            int i = stringGiven.Length - 1;
            string newString = RecursiveFunction(stringGiven, charToReplace, stringToAddInPlaceOfChar, i);
            return newString;
        }
        string RecursiveFunction(string stringGiven,char charToReplace,string stringToAddInPlaceOfChar,int i)
        {
            if (i > 0)
            {
                string stringToAdd = (stringGiven[i] == charToReplace) ? stringToAddInPlaceOfChar : stringGiven[i].ToString();
                return RecursiveFunction(stringGiven, charToReplace, stringToAddInPlaceOfChar, i - 1) + stringToAdd;            
            }
            else return stringGiven[i].ToString();
        }
    }
}
