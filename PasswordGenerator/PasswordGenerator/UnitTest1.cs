using System;
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
    [TestClass]
    public class PasswordGeneratorTest
    {
        [TestMethod]
        public void TestPassword()
        {
            var options = new PasswordOptions[] { new PasswordOptions("UpperCase", 3), new PasswordOptions("Digits", 1), new PasswordOptions("Symbols", 0) };           
            var result = PasswordGenerator(12, options, false,true, true);
            Assert.AreEqual("Pass", result);
        }
        [TestMethod]
        public void TestUpperCaseChars()
        {
            var options = new PasswordOptions[] { new PasswordOptions("UpperCase", 5) };
            var result = PasswordGenerator(8, options,true,false,false);
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
            var result = PasswordGenerator(8, options,true,false,false);
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
            var result = PasswordGenerator(8, options,true,false,false);
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
            var result = PasswordGenerator(12, options,true,false,false);
            int numberOfLowerCaseChars = 0;
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] >= 'a' && result[i] <= 'z') numberOfLowerCaseChars++;
            }
            Assert.AreEqual(4, numberOfLowerCaseChars); 
        }
         
        string PasswordGenerator(int passwordLength,PasswordOptions[] options,bool lowerCase,bool withoutAmbiguousChars,bool withoutSimilarities)
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
            GeneratePasswordUsingOnlyTheOptions(passwordLength,options, rand, ref password, ref rest, withoutAmbiguousChars, withoutSimilarities, lowerCase);
            FillThePasswordUsingThePoolOfUsableChars(passwordLength, ref password, ref rest, rand, lowerCase);                
            char[] passArray = ShufflePassword(ref password, rand);
            return new string(passArray);         
        }

        private void GeneratePasswordUsingOnlyTheOptions(int passwordLength,PasswordOptions[] options, Random rand, ref string password, ref string rest, bool withoutAmbiguousChars, bool withoutSimilarities, bool lowerCase)
        {
            for (int i = 0; i < options.Length; i++)
            {
                switch (options[i].option)
                {
                    case "UpperCase":
                        if (options[i].numberOfChars > 0)
                            GenerateUpperCaseLowerCaseAndDigitChars(ref password, options[i].numberOfChars, 'A', 26, rand,withoutSimilarities);
                        else GeneratePoolOfUsableCharsToFillThePassword(ref rest, 'A', 26, rand, withoutSimilarities);
                        break;
                    case "Digits":
                        if (options[i].numberOfChars > 0)
                            GenerateUpperCaseLowerCaseAndDigitChars(ref password, options[i].numberOfChars, '0', 9, rand,withoutSimilarities);
                        else GeneratePoolOfUsableCharsToFillThePassword(ref rest, '0', 9, rand, withoutSimilarities);
                        break;
                    case "Symbols":
                        if (options[i].numberOfChars > 0)
                            GenerateSymbolChars(ref password, options[i].numberOfChars, rand,withoutAmbiguousChars);
                        else
                        {
                           if (withoutAmbiguousChars)
                            {
                                char[]symbolsArray = new char[] { '#', '$', '%', '^', '&', '*', '?', '!', '+', '-' };
                                for (int j = 0; j < symbolsArray.Length; j++)
                                    rest += symbolsArray[j];
                            }
                           else
                            {
                                char[]symbolsArray=new char[]{ '#', '$', '%', '^', '&', '*', '?', '!', '+', '-', '{', '}', '[', ']', '(', ')', '/', '\\', '\'', '~', '"', ',', ';', '.', '<', '>' };
                                for (int j = 0; j < symbolsArray.Length; j++)
                                    rest += symbolsArray[j];
                            }                   
                        }
                        break;
                }
            }
            if (lowerCase)
            {
                int neededLowerCaseChars = passwordLength - password.Length;
                GenerateUpperCaseLowerCaseAndDigitChars(ref password, neededLowerCaseChars, 'a', 26, rand, withoutSimilarities);
            }
            else GeneratePoolOfUsableCharsToFillThePassword(ref rest, 'a', 26, rand, withoutSimilarities);
        }

        public void GeneratePoolOfUsableCharsToFillThePassword(ref string rest, char firstChar, int range, Random rand, bool withoutSimilarities)
        {
            bool similar;
            for (int i = 0; i < range; i++)
            {
                rest += (char)(firstChar + i);
                if (withoutSimilarities)
                {
                    var arrayOfSimilarChars = new char[] { 'I', '1', 'l', 'o', 'O', '0' };
                    do
                    {
                        similar = false;
                        for (int j = 0; j < arrayOfSimilarChars.Length; j++)
                            if (rest[rest.Length - 1] == arrayOfSimilarChars[j])
                            {
                                similar = true;
                                i++;
                                rest = rest.Replace(rest[rest.Length - 1], (char)(firstChar + i));
                            }
                    }
                    while (similar);
                }
            }
        }

        private void FillThePasswordUsingThePoolOfUsableChars(int passwordLength,ref string password,ref string rest,Random rand,bool lowerCase)
        {
            int remainingNumberOfChars = passwordLength - password.Length;
            for (int i = 0; i < remainingNumberOfChars; i++)
                password += rest[rand.Next(0, rest.Length - 1)];
        }
      
        char[] ShufflePassword(ref string password,Random rand)
        {
            int i = password.Length;
            char[] passArray = password.ToCharArray();
            while (i > 1)
            {
                i--;
                int k = rand.Next(0, i - 1);
                char switchVariable = passArray[k];
                passArray[k] = passArray[i];
                passArray[i] = switchVariable;
            }

            return passArray;
        }
 
        public void GenerateSymbolChars(ref string password, int neededChars,Random rand,bool withoutAmbiguousChars)
        {
            bool ambiguous;
            var symbolsArray = new char[] { '#', '$', '%', '^', '&', '*', '?', '!', '+', '-', '{', '}', '[', ']', '(', ')', '/', '\\', '\'', '~', '"', ',', ';', '.', '<', '>' };
            for (int i = 0; i< neededChars; i++)
            {
                password += symbolsArray[rand.Next(0, symbolsArray.Length - 1)];
                if (withoutAmbiguousChars)
                {
                    char[] ambiguousChars = new char[] { '{', '}', '[', ']', '(', ')', '/', '\\', '\'', '~', '"', ',', ';', '.', '<', '>' };
                    do
                    {
                        ambiguous= false;
                        for (int j = 0; j < ambiguousChars.Length; j++)
                            if (password[password.Length - 1] == ambiguousChars[j])
                            {
                                ambiguous = true;
                                password = password.Replace(password[password.Length - 1],symbolsArray[rand.Next(0,symbolsArray.Length-1)]);
                            }
                    }
                    while (ambiguous);
                }
            }
        }

        public void GenerateUpperCaseLowerCaseAndDigitChars(ref string password,int neededChars,char firstChar,int range,Random rand,bool withoutSimilarities)
        {
            bool similar;
            for (int i = 0; i < neededChars; i++)
            {
                password += (char)(firstChar + rand.Next(0, range));
                if (withoutSimilarities)
                {
                    var arrayOfSimilarChars = new char[] { 'I', '1', 'l', 'o', 'O', '0' };
                    do
                    {
                        similar = false;
                        for (int j = 0; j < arrayOfSimilarChars.Length; j++)
                            if (password[password.Length - 1] == arrayOfSimilarChars[j])
                            {
                                similar = true;
                                password = password.Replace(password[password.Length - 1], (char)(firstChar + rand.Next(0, range)));
                            }
                    }
                    while (similar);
                }                  
            }
        }

     
    }  

}
