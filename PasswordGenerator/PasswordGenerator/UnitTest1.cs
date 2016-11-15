﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PasswordGenerator
{
    public struct PasswordOptions
    {
        public string option;
        public int numberOfChars;
        public PasswordOptions(string option,int numberOfChars)
        {
            this.option = option;
            this.numberOfChars = numberOfChars;
        }
    }
    public struct PasswordBoolOptions
    {
        public string option;
        public bool chosen;
        public PasswordBoolOptions(string option, bool chosen)
        {
            this.option = option;
            this.chosen = chosen;
        }
    }
    [TestClass]
    public class PasswordGeneratorTest
    {
        [TestMethod]
        public void TestUpperCaseChars()
        {
            var options = new PasswordOptions[] { new PasswordOptions("UpperCase", 5) };
            var boolOptions = new PasswordBoolOptions[] { new PasswordBoolOptions("Lowercase", true), new PasswordBoolOptions("Without ambiguous chars", false), new PasswordBoolOptions("Without similar chars", false) };
            var result = PasswordGenerator(8, options,boolOptions);
            int numberOfUpperCaseChars = 0;
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] >= 'A' && result[i] <= 'Z') numberOfUpperCaseChars++;
            }
            Assert.AreEqual(5,numberOfUpperCaseChars);
        }
        [TestMethod]
        public void TestDigitChars()
        {
            var options = new PasswordOptions[] { new PasswordOptions("UpperCase", 3), new PasswordOptions("Digits", 5) };
            var boolOptions = new PasswordBoolOptions[] { new PasswordBoolOptions("Lowercase", true), new PasswordBoolOptions("Without ambiguous chars", false), new PasswordBoolOptions("Without similar chars", false) };
            var result = PasswordGenerator(8, options,boolOptions);
            int numberOfDigitChars = 0;
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] >= '0' && result[i] <= '9') numberOfDigitChars++;
            }
            Assert.AreEqual(5, numberOfDigitChars);
        }
        [TestMethod]
        public void TestSymbolChars()
        {
            var options = new PasswordOptions[] { new PasswordOptions("UpperCase", 2), new PasswordOptions("Digits", 2), new PasswordOptions("Symbols", 4) };
            var boolOptions = new PasswordBoolOptions[] { new PasswordBoolOptions("Lowercase", true), new PasswordBoolOptions("Without ambiguous chars", false), new PasswordBoolOptions("Without similar chars", false) };
            var result = PasswordGenerator(8, options,boolOptions);
            var symbolsArray = new char[] { '#', '$', '%', '^', '&', '*', '?', '!', '+', '-', '{', '}', '[', ']', '(', ')', '/', '\\', '\'', '~', '"', ',', ';', '.', '<', '>' };
            int numberOfSymbolChars = 0;
            for (int i = 0; i < result.Length; i++)
                for (int j = 0; j < symbolsArray.Length; j++)
                    if (result[i] == symbolsArray[j]) numberOfSymbolChars++;
            Assert.AreEqual(4, numberOfSymbolChars);
        }
        [TestMethod]
        public void TestLowerCaseChars()
        {
            var options= new PasswordOptions[] { new PasswordOptions("UpperCase", 2), new PasswordOptions("Digits", 2), new PasswordOptions("Symbols", 4) };
            var boolOptions = new PasswordBoolOptions[] { new PasswordBoolOptions("LowerCase", true), new PasswordBoolOptions("Without ambiguous chars", false), new PasswordBoolOptions("Without similar chars", false) };
            var result = PasswordGenerator(12, options,boolOptions);
            int numberOfLowerCaseChars = 0;
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] >= 'a' && result[i] <= 'z') numberOfLowerCaseChars++;
            }
            Assert.AreEqual(4, numberOfLowerCaseChars); 
        }
       
        public void PasswordAfterBoolOptions(int passwordLength,ref string password,ref string rest, PasswordBoolOptions[] boolOptions)
        {
            Random rand = new Random();
            for (int i=0;i<boolOptions.Length;i++)
                switch (boolOptions[i].option)
                {
                    case "LowerCase":
                        if (boolOptions[i].chosen)
                        {
                            int neededLowerCaseChars = passwordLength - password.Length;
                            GenerateUpperCaseLowerCaseAndDigitChars(ref password, neededLowerCaseChars, 'a', 26, rand);
                        }
                        else GenerateRest(ref rest, 'a', 26, rand);
                        break;
                    case "Without ambiguous chars":
                        break;
                    case "Without similar chars":
                        break;
                }          
        }

        string PasswordGenerator(int passwordLength,PasswordOptions[] options,PasswordBoolOptions[]boolOptions)
        {
            Random rand = new Random();
            string password = string.Empty;
            string rest = string.Empty;
            int allNeededChars = 0;
            for (int i = 0; i < options.Length; i++)
            {
                allNeededChars = allNeededChars + options[i].numberOfChars;
            }
            if (allNeededChars > passwordLength) return "Password length needs to be larger";
            PasswordWithoutConditions(options, rand, ref password, ref rest);
            PasswordAfterBoolOptions(passwordLength, ref password, ref rest, boolOptions);
            return password;
        }

        private void PasswordWithoutConditions(PasswordOptions[] options, Random rand, ref string password, ref string rest)
        {
            for (int i = 0; i < options.Length; i++)
            {
                switch (options[i].option)
                {
                    case "UpperCase":
                        if (options[i].numberOfChars > 0)
                            GenerateUpperCaseLowerCaseAndDigitChars(ref password, options[i].numberOfChars, 'A', 26, rand);
                        else GenerateRest(ref rest, 'A', 26, rand);
                        break;
                    case "Digits":
                        if (options[i].numberOfChars > 0)
                            GenerateUpperCaseLowerCaseAndDigitChars(ref password, options[i].numberOfChars, '0', 9, rand);
                        else GenerateRest(ref rest, '0', 9, rand);
                        break;
                    case "Symbols":
                        if (options[i].numberOfChars > 0)
                            GenerateSymbolChars(ref password, options[i].numberOfChars, rand);
                        else
                        {
                            var symbolsArray = new char[] { '#', '$', '%', '^', '&', '*', '?', '!', '+', '-', '{', '}', '[', ']', '(', ')', '/', '\\', '\'', '~', '"', ',', ';', '.', '<', '>' };
                            for (int j = 0; j < symbolsArray.Length; j++)
                                rest += symbolsArray[j];
                        }
                        break;

                }
            }
        }

        public void GenerateSymbolChars(ref string password, int neededChars,Random rand)
        {
            var symbolsArray = new char[] { '#', '$', '%', '^', '&', '*', '?', '!', '+', '-', '{', '}', '[', ']', '(', ')', '/', '\\', '\'', '~', '"', ',', ';', '.', '<', '>' };
            for (int i = 0; i< neededChars; i++)
            {
                password += symbolsArray[rand.Next(0, symbolsArray.Length - 1)];
            }
        }

        public void GenerateUpperCaseLowerCaseAndDigitChars(ref string password,int neededChars,char firstChar,int range,Random rand)
        {
            for (int i = 0; i < neededChars; i++)
            {
                password += (char)(firstChar + rand.Next(0, range));
            }
        }

        public void GenerateRest(ref string rest, char firstChar, int range, Random rand)
        {
            for (int i = 0; i < range; i++)
            {
                rest += (char)(firstChar + i);
            }
        }
    }  

}
