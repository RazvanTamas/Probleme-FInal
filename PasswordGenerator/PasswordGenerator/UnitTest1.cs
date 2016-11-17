using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PasswordGenerator
{
    public struct PasswordOptions
    {
        public int PasswordLength;
        public int UpperCase;
        public int Digits;
        public int Symbols;
        public bool LowerCase;
        public bool WithoutAmbiguousChars;
        public bool WithoutSimilarChars;
        
        public PasswordOptions(int PasswordLength,int UpperCase,int Digits,int Symbols,bool LowerCase,bool WithoutAmbiguousChars,bool WithoutSimilarChars)
        {
            this.PasswordLength = PasswordLength;
            this.UpperCase = UpperCase;
            this.Digits = Digits;
            this.Symbols = Symbols;
            this.LowerCase = LowerCase;
            this.WithoutAmbiguousChars = WithoutAmbiguousChars;
            this.WithoutSimilarChars = WithoutSimilarChars;
        }
    }
    [TestClass]
    public class PasswordGeneratorTest
    {
        [TestMethod]
        public void TestPassword()
        {
            var options = new PasswordOptions(12,2,2,2,true,false,false);
            var result = PasswordGenerator(options);
            Assert.AreEqual("Pass", result);
        }
        [TestMethod]
        public void TestUpperCaseChars()
        {
            var options = new PasswordOptions(12, 2, 2, 2, false,true,false);
            var result = PasswordGenerator(options);
            int numberOfUpperCaseChars = 0;
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] >= 'A' && result[i] <= 'Z') numberOfUpperCaseChars++;
            }
            Assert.AreEqual(2,numberOfUpperCaseChars);
        }
        [TestMethod]
        public void TestDigitChars()
        {
            var options = new PasswordOptions(12,0,2,0,true,false,true);
            var result = PasswordGenerator(options);
            int numberOfDigitChars = 0;
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] >= '0' && result[i] <= '9') numberOfDigitChars++;
            }
            Assert.AreEqual(2, numberOfDigitChars);
        }
        [TestMethod]
        public void TestSymbolChars()
        {
            var options = new PasswordOptions(12,0,0,4,true,true,false);
            var result = PasswordGenerator(options);
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
            var options = new PasswordOptions(12,3,3,2,true,false,false);
            var result = PasswordGenerator(options);
            int numberOfLowerCaseChars = 0;
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] >= 'a' && result[i] <= 'z') numberOfLowerCaseChars++;
            }
            Assert.AreEqual(4, numberOfLowerCaseChars); 
        }
         
        string PasswordGenerator(PasswordOptions options)
        {
            Random rand = new Random();
            string password = string.Empty;
            string rest = string.Empty;          
            if (options.PasswordLength < (options.Symbols + options.UpperCase + options.Digits)) return "Password needs more characters";         
            GeneratePasswordUsingOnlyTheOptions(options, rand, ref password, ref rest);
            FillThePasswordUsingThePoolOfUsableChars(options,ref password, ref rest, rand);                
            char[] passArray = ShufflePassword(ref password, rand);
            return new string(passArray);         
        }

        private void GeneratePasswordUsingOnlyTheOptions(PasswordOptions options, Random rand, ref string password, ref string rest)
        {
            if (options.UpperCase > 0)
                GenerateUpperCaseLowerCaseAndDigitChars(ref password, options.UpperCase, 'A', 26, rand, options.WithoutSimilarChars);
            else
                GeneratePoolOfUsableCharsToFillThePassword(ref rest, 'A', 26, rand, options.WithoutSimilarChars);
            if (options.Digits > 0)
                GenerateUpperCaseLowerCaseAndDigitChars(ref password, options.Digits, '0', 9, rand, options.WithoutSimilarChars);
            else
                GeneratePoolOfUsableCharsToFillThePassword(ref rest, '0', 9, rand, options.WithoutSimilarChars);
            if (options.Symbols > 0)
                GenerateSymbolChars(ref password, options.Symbols, rand, options.WithoutAmbiguousChars);
            else
            {
                if (options.WithoutAmbiguousChars)
                {
                    string symbols = "!@#$%^&*+-?";
                    var symbolsArray = symbols.ToCharArray();
                    for (int i = 0; i < symbolsArray.Length; i++)
                        rest += symbolsArray[i];
                }
                else
                {
                    var symbolsArray = new char[] { '#', '$', '%', '^', '&', '*', '?', '!', '+', '-', '{', '}', '[', ']', '(', ')', '/', '\\', '\'', '~', '"', ',', ';', '.', '<', '>' };
                    for (int i = 0; i < symbolsArray.Length; i++)
                        rest += symbolsArray[i];
                }                
            }
            int neededLowerCaseChars = options.PasswordLength - password.Length;
            if (options.LowerCase)
                GenerateUpperCaseLowerCaseAndDigitChars(ref password, neededLowerCaseChars, 'a', 26, rand, options.WithoutSimilarChars);
            else GeneratePoolOfUsableCharsToFillThePassword(ref rest, 'a', 26, rand, options.WithoutSimilarChars);
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

        private void FillThePasswordUsingThePoolOfUsableChars(PasswordOptions options, ref string password,ref string rest,Random rand)
        {
            int remainingNumberOfChars = options.PasswordLength - password.Length;
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
