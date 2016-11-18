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
            var options = new PasswordOptions(12,3,3,3,true,true,true);           
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
            var symbolsArray = symbols.ToCharArray();
            int numberOfSymbolChars = 0;
            for (int i = 0; i < result.Length; i++)
                for (int j = 0; j < symbolsArray.Length; j++)
                    if (result[i] == symbolsArray[j]) numberOfSymbolChars++;
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
            if (options.PasswordLength < (options.Symbols + options.UpperCase + options.Digits)) return "Password needs more characters";                 
            GenerateUpperCaseLowerCaseAndDigitChars(ref password, options.UpperCase, 'A', 26, options.WithoutSimilarChars, rand);
            GenerateUpperCaseLowerCaseAndDigitChars(ref password, options.Digits, '0', 9, options.WithoutSimilarChars, rand);
            GenerateSymbolChars(ref password, options.Symbols, options.WithoutAmbiguousChars, rand);
            int neededLowerCaseChars = options.PasswordLength - password.Length;
            if (options.LowerCase)
                GenerateUpperCaseLowerCaseAndDigitChars(ref password, neededLowerCaseChars, 'a', 26, options.WithoutSimilarChars, rand);
            GeneratePoolOfUsableCharsForTheRestOfThePassword(options, ref password, ref rest, rand);                
            char[] passArray = ShufflePassword(ref password,rand);
            return new string(passArray);         
        }

        private void GeneratePoolOfUsableCharsForTheRestOfThePassword(PasswordOptions options, ref string password, ref string rest,Random rand)
        {                                                      
            if (options.LowerCase==false)              
              FillPoolOfUsableCharsWithUpperCaseLowerCaseAndDigitChars(ref rest, 'a', 26, options.WithoutSimilarChars);
            if (options.UpperCase == 0)
                FillPoolOfUsableCharsWithUpperCaseLowerCaseAndDigitChars(ref rest, 'A', 26, options.WithoutSimilarChars);
            if (options.Digits == 0)
                FillPoolOfUsableCharsWithUpperCaseLowerCaseAndDigitChars(ref rest, '0', 9, options.WithoutSimilarChars);
            if (options.Symbols == 0)
                FillPoolOfUsableCharsWithSymbolChars(ref rest, options.WithoutAmbiguousChars);                      
        }

        public void FillPoolOfUsableCharsWithSymbolChars(ref string rest,bool withouthAmbiguousChars)
        {
            if (withouthAmbiguousChars)
            {
                string symbols = "!@#$%^&*+-?";
                for (int i = 0; i < symbols.Length; i++)
                    rest += symbols[i];
            }
            else
            {
                string symbols = "~`!@#$%^&*()_+-={}[]:;'\"<,>.?/|\\";
                for (int i = 0; i < symbols.Length; i++)
                    rest += symbols[i];                
            }   
        }

        public void FillPoolOfUsableCharsWithUpperCaseLowerCaseAndDigitChars(ref string rest, char firstChar, int range, bool withoutSimilarities)
        {

            bool similar;
            for (int i = 0; i < range; i++)
            {
                rest += (char)(firstChar + i);
                if (withoutSimilarities)
                {
                    var arrayOfSimilarChars = new char[] { 'I', '1', 'l', 'o', 'O', '0' };
                    do
                        similar = PoolOfUsableCharsWithoutSimilarities(ref rest, firstChar, ref i, arrayOfSimilarChars);
                    while (similar);
                }
            }
        }

        private static bool PoolOfUsableCharsWithoutSimilarities(ref string rest, char firstChar, ref int i, char[] arrayOfSimilarChars)
        {
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

        private void CompletePasswordWithCharsFromThePool(PasswordOptions options, ref string password,ref string rest,Random rand)
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
 
        public void GenerateSymbolChars(ref string password, int neededChars,bool withoutAmbiguousChars,Random rand)
        {
           
            bool ambiguous;
            string symbols = "~`!@#$%^&*()_+-={}[]:;'\"<,>.?/|\\";
            string ambiguousChars = "{}[]()/\\'~\",.:;<>|";
            var symbolsArray = symbols.ToCharArray();          
            var ambiguousCharsArray = ambiguousChars.ToCharArray();
            for (int i = 0; i< neededChars; i++)
            {
                password += symbolsArray[rand.Next(0, symbolsArray.Length - 1)];
                if (withoutAmbiguousChars)
                {                   
                    do
                    {
                        ambiguous = GenerateSymbolCharsWhithoutAmbiguousChars(ref password, rand, ambiguousCharsArray, symbolsArray);
                    }
                    while (ambiguous);
                }
            }
        }

        private static bool GenerateSymbolCharsWhithoutAmbiguousChars(ref string password, Random rand, char[] ambiguousCharsArray, char[] symbolsArray)
        {
            bool ambiguous = false;
            for (int j = 0; j < ambiguousCharsArray.Length; j++)
                if (password[password.Length - 1] == ambiguousCharsArray[j])
                {
                    ambiguous = true;
                    password = password.Replace(password[password.Length - 1], symbolsArray[rand.Next(0, symbolsArray.Length - 1)]);
                }

            return ambiguous;
        }

        public void GenerateUpperCaseLowerCaseAndDigitChars(ref string password,int neededChars,char firstChar,int range,bool withoutSimilarities,Random rand)
        {                   
                       
            bool similar;
            for (int i = 0; i < neededChars; i++)
            {
                password += (char)(firstChar + rand.Next(0, range));
                if (withoutSimilarities)
                {                 
                    do
                    {
                        similar = GenerateUpperCaseLowerCaseAndDigitCharsWithoutSimilarities(ref password, firstChar, range, rand);
                    }
                    while (similar);
                }                  
            }
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

    }  

}
