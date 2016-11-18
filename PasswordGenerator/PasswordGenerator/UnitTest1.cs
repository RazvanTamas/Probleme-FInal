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
            var options = new PasswordOptions(12,2,2,2,false,true,true);           
            Assert.AreEqual("Pass", PasswordGenerator(options));
        }
        [TestMethod]
        public void TestUpperCaseChars()
        {
            var options = new PasswordOptions(12, 2, 2, 2, false, true, false);
            var result = PasswordGenerator(options);
            Assert.AreEqual(2, CalculateNumberOfUpperCaseChars(result));
        }

        private static int CalculateNumberOfUpperCaseChars(string result)
        {
            int numberOfUpperCaseChars = 0;
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] >= 'A' && result[i] <= 'Z') numberOfUpperCaseChars++;
            }

            return numberOfUpperCaseChars;
        }

        [TestMethod]
        public void TestDigitChars()
        {
            var options = new PasswordOptions(12, 0, 2, 0, true, false, true);
            var result = PasswordGenerator(options);        
            Assert.AreEqual(2, CalculateNumberOfDigitChars(result));
        }

        private static int CalculateNumberOfDigitChars(string result)
        {
            int numberOfDigitChars = 0;
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] >= '0' && result[i] <= '9') numberOfDigitChars++;
            }

            return numberOfDigitChars;
        }

        [TestMethod]
        public void TestSymbolChars()
        {
            var options = new PasswordOptions(12, 0, 0, 4, true, true, false);
            var result = PasswordGenerator(options);            
            Assert.AreEqual(4, CalculateNumberOfSymbolChars(result));
        }

        private static int CalculateNumberOfSymbolChars(string result)
        {
            string symbols = "~`!@#$%^&*()_+-={}[]:;'\"<,>.?/|\\";           
            int numberOfSymbolChars = 0;
            for (int i = 0; i < result.Length; i++)
                for (int j = 0; j < symbols.Length; j++)
                    if (result[i] == symbols[j]) numberOfSymbolChars++;
            return numberOfSymbolChars;
        }

        [TestMethod]
        public void TestLowerCaseChars()
        {
            var options = new PasswordOptions(12, 3, 3, 2, true, false, false);
            var result = PasswordGenerator(options);
            Assert.AreEqual(4, CalculateNumberOfLowerCaseChars(result));
        }

        private static int CalculateNumberOfLowerCaseChars(string result)
        {
            int numberOfLowerCaseChars = 0;
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] >= 'a' && result[i] <= 'z') numberOfLowerCaseChars++;
            }

            return numberOfLowerCaseChars;
        }

        string PasswordGenerator(PasswordOptions options)
        {
            Random rand = new Random();
            string password = string.Empty;         
            string rest = string.Empty;          
            if (options.PasswordLength < (options.Symbols + options.UpperCase + options.Digits))
                return "Password needs more characters";

            password = string.Concat(GenerateUpperCaseLowerCaseAndDigitChars(options.UpperCase, 'A', 26, options.WithoutSimilarChars, rand), password);
            password = string.Concat(GenerateUpperCaseLowerCaseAndDigitChars(options.Digits, '0', 9, options.WithoutSimilarChars, rand), password);
            password = string.Concat(GenerateSymbolChars(options.Symbols, options.WithoutAmbiguousChars, rand), password);
            int neededLowerCaseChars = options.PasswordLength - password.Length;
            if (options.LowerCase)
                password = string.Concat(GenerateUpperCaseLowerCaseAndDigitChars(neededLowerCaseChars, 'a', 26, options.WithoutSimilarChars, rand), password);
            rest = GeneratePoolOfUsableCharsForTheRestOfThePassword(options);
            int lastChars = options.PasswordLength - password.Length;
            password = string.Concat(CompletePasswordWithCharsFromThePool(lastChars, ref rest, rand), password);   
                    
            char[] passArray = ShufflePassword(ref password,rand);
            return new string(passArray);         
        }

        string GenerateUpperCaseLowerCaseAndDigitChars(int neededChars, char firstChar, int range, bool withoutSimilarities, Random rand)
        {
            string partOfPassword = string.Empty;
            bool similar;
            for (int i = 0; i < neededChars; i++)
            {
                partOfPassword += (char)(firstChar + rand.Next(0, range));
                if (withoutSimilarities)
                {
                    do
                    {
                        similar = GenerateUpperCaseLowerCaseAndDigitCharsWithoutSimilarities(ref partOfPassword, firstChar, range, rand);
                    }
                    while (similar);
                }
            }
            return partOfPassword;
        }

        private static bool GenerateUpperCaseLowerCaseAndDigitCharsWithoutSimilarities(ref string password, char firstChar, int range, Random rand)
        {
            var arrayOfSimilarChars = new char[] { 'I', '1', 'l', 'o', 'O', '0' };
            bool similar = false;
            for (int j = 0; j < arrayOfSimilarChars.Length; j++)
                if (password[password.Length - 1] == arrayOfSimilarChars[j])
                {
                    similar = true;
                    password = password.Replace(password[password.Length - 1], (char)(firstChar + rand.Next(0, range)));
                }

            return similar;
        }

        string GenerateSymbolChars(int neededChars, bool withoutAmbiguousChars, Random rand)
        {
            string partOfPassword = string.Empty;
            string symbols = string.Empty;
            symbols = (withoutAmbiguousChars) ? "!@#$%^&*+-?" : "~`!@#$%^&*()_+-={}[]:;'\"<,>.?/|\\";
            for (int i = 0; i < neededChars; i++)
                partOfPassword += symbols[rand.Next(0, symbols.Length - 1)];
            return partOfPassword;
        }  

        string GeneratePoolOfUsableCharsForTheRestOfThePassword(PasswordOptions options)
        {
            string rest = string.Empty;
            if (options.LowerCase == false)
                rest = string.Concat(PoolOfUsableUpperCaseLowerCaseAndDigitChars('a', 26, options.WithoutSimilarChars), rest);
            if (options.UpperCase == 0)
                rest = string.Concat(PoolOfUsableUpperCaseLowerCaseAndDigitChars('A', 26, options.WithoutSimilarChars), rest);
            if (options.Digits == 0)
                rest = string.Concat(PoolOfUsableUpperCaseLowerCaseAndDigitChars('0', 9, options.WithoutSimilarChars), rest);
            if (options.Symbols == 0)
                rest = string.Concat(PoolOfUsableSymbolChars(options.WithoutAmbiguousChars), rest);
            return rest;                    
        }

        string PoolOfUsableUpperCaseLowerCaseAndDigitChars(char firstChar, int range, bool withoutSimilarities)
        {
            string rest = string.Empty;
            bool similar;
            for (int i = 0; i < range; i++)
            {
                rest += (char)(firstChar + i);
                if (withoutSimilarities)
                {
                    do
                        similar = FindPoolOfUsableCharsWithoutSimilarities(ref rest, firstChar, ref i);
                    while (similar);
                }
            }
            return rest;
        }
       
        string PoolOfUsableSymbolChars(bool withoutAmbiguousChars)
        {
            string rest = string.Empty;
            string symbols = string.Empty;
            symbols = (withoutAmbiguousChars) ? "!@#$%^&*+-?" : "~`!@#$%^&*()_+-={}[]:;'\"<,>.?/|\\";         
            for (int i = 0; i < symbols.Length; i++)
                rest += symbols[i];
            return rest;
        }

        private static bool FindPoolOfUsableCharsWithoutSimilarities(ref string rest, char firstChar,ref int i)
        {
            var arrayOfSimilarChars = new char[] { 'I', '1', 'l', 'o', 'O', '0' };
            bool similar;
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

            return similar;
        }

        string CompletePasswordWithCharsFromThePool(int neededChars,ref string rest,Random rand)
        {
            string lastPartOfPassword = string.Empty;      
            for (int i = 0; i < neededChars; i++)
                lastPartOfPassword += rest[rand.Next(0, rest.Length - 1)];
            return lastPartOfPassword;
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
 

       

      

       

    }  

}
