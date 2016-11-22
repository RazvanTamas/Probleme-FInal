using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PasswordGenerator
{
    public struct Chars
    {
        public string charsInString;
        public string charsInStringWithoutSimilaritiesOrAmbiguous;   
        public Chars(string charsInString,string charsInStringWithoutSimilaritiesOrAmbiguous)
        {
            this.charsInString = charsInString;
            this.charsInStringWithoutSimilaritiesOrAmbiguous = charsInStringWithoutSimilaritiesOrAmbiguous;
        }      
    }
    public struct PasswordOptions
    {
        public int passwordLength;
        public int numberOfUpperCaseChars;
        public int numberOfDigitChars;
        public int numberOfSymbolChars;
        public bool lowerCase;
        public bool withoutAmbiguousChars;
        public bool withoutSimilarChars;
        
        public PasswordOptions(int PasswordLength,int NumberOfUpperCaseChars,int NumberOfDigitChars,int NumberOfSymbolChars,bool LowerCase,bool WithoutAmbiguousChars,bool WithoutSimilarChars)
        {
            this.passwordLength = PasswordLength;
            this.numberOfUpperCaseChars = NumberOfUpperCaseChars;
            this.numberOfDigitChars = NumberOfDigitChars;
            this.numberOfSymbolChars = NumberOfSymbolChars;
            this.lowerCase = LowerCase;
            this.withoutAmbiguousChars = WithoutAmbiguousChars;
            this.withoutSimilarChars = WithoutSimilarChars;
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
            var chars = new Chars[] { new Chars("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "ABCDEFGHJKLMNPQRSTUVWXYZ"), new Chars("0123456789", "23456789"), new Chars("abcdefghijklmnopqrstuvwxyz", "abcdefghijkmnpqrstuvwxyz"), new Chars("~`!@#$%^&*()_+-={}[]:;'\"<,>.?/|\\", "!@#$%^&*+-?") };
            Random rand = new Random();
            string password = string.Empty;
            string rest = string.Empty;
            if (options.passwordLength < (options.numberOfSymbolChars + options.numberOfUpperCaseChars + options.numberOfDigitChars))
                return "Password needs more characters";

            password = string.Concat(GenerateNeededChars(chars[0], options.numberOfUpperCaseChars, options.withoutSimilarChars, rand), password);
            password = string.Concat(GenerateNeededChars(chars[1], options.numberOfDigitChars, options.withoutSimilarChars, rand), password);
            password = string.Concat(GenerateNeededChars(chars[3], options.numberOfSymbolChars, options.withoutAmbiguousChars, rand), password);
            int neededLowerCaseChars = options.passwordLength - password.Length;
            if (options.lowerCase)
                password = string.Concat(GenerateNeededChars(chars[2], neededLowerCaseChars, options.withoutSimilarChars, rand), password);
            rest = GeneratePoolOfUsableCharsWithoutSimilarities(options, chars, rest);
            rest = GeneratePoolOfUsableCharsForTheRestOfThePassword(chars[3], options.withoutAmbiguousChars);
            int lastChars = options.passwordLength - password.Length;
            password = string.Concat(CompletePasswordWithCharsFromThePool(lastChars, ref rest, rand), password);
            char[] passArray = ShufflePassword(ref password, rand);

            return new string(passArray);
        }
 
        string GenerateNeededChars(Chars chars,int neededChars,bool withoutSimilarities,Random rand)
        {                        
            string partOfPassword = string.Empty;
            string characters = (withoutSimilarities) ? chars.charsInStringWithoutSimilaritiesOrAmbiguous : chars.charsInString;                              
            for (int i = 0; i < neededChars; i++)
            {
                partOfPassword += characters[rand.Next(0, characters.Length - 1)];
            }
            return partOfPassword;
        }

        string GeneratePoolOfUsableCharsForTheRestOfThePassword(Chars chars,bool withoutSimilaritiesOrAmbiguous)
        {
            string rest = string.Empty;
            string charsToAdd = (withoutSimilaritiesOrAmbiguous) ? chars.charsInStringWithoutSimilaritiesOrAmbiguous : chars.charsInString;
            rest = string.Concat(rest, charsToAdd);
            return rest;                
        }

        private string GeneratePoolOfUsableCharsWithoutSimilarities(PasswordOptions options, Chars[] chars, string rest)
        {
            for (int i = 0; i < 3; i++)
            {
                rest = GeneratePoolOfUsableCharsForTheRestOfThePassword(chars[i], options.withoutSimilarChars);
            }

            return rest;
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
