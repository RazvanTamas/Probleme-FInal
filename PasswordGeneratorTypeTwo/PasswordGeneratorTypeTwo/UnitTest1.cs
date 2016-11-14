using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PasswordGeneratorTypeTwo
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string result = PasswordGenerator(20, 63, 3, 4, 5);
            Assert.AreEqual("NOT", result);
        }

        [TestMethod]
        public void UpperCaseTest()
        {
            string result = PasswordGenerator(20, 63, 3, 4, 5);
            int numberOfUpperCaseLetters = 0;
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] >= 'A' && result[i] <= 'Z') numberOfUpperCaseLetters++;
            }
            Assert.AreEqual(3,numberOfUpperCaseLetters);
        }

        [TestMethod]
        public void DigitsTest()
        {
            string result = PasswordGenerator(20, 63, 3, 4, 5);
            int numberOfDigits = 0;
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] >= '0' && result[i] <= '9') numberOfDigits++;
            }
            Assert.AreEqual(4,numberOfDigits);
        }

        [TestMethod]
        public void SymbolsTest()
        {
            string result = PasswordGenerator(20, 63, 3, 4, 5);
            int numberOfSymbols = 0;
            var symbolsArray = new char[] { '#', '$', '%', '^', '&', '*', '?', '!', '+', '-', '{', '}', '[', ']', '(', ')', '/', '\\', '\'', '~', '"', ',', ';', '.', '<', '>' };
            for (int i = 0; i < result.Length; i++)
            {
                for(int j = 0; j < symbolsArray.Length; j++)
                {
                    if (result[i] == symbolsArray[j]) numberOfSymbols++;
                }
            }
            Assert.AreEqual(5, numberOfSymbols);
        }

        [TestMethod]
        public void LowerCaseTest()
        {
            string result = PasswordGenerator(20, 63, 3, 4, 5);
            int numberOfLowerCaseChars = 0;
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] >= 'a' && result[i] <= 'z') numberOfLowerCaseChars++;
            }
            Assert.AreEqual(8, numberOfLowerCaseChars);
        }

        [TestMethod]
        public void WhithoutSimilaritiesTest()
        {
            var arrayOfSimilarChars = new char[] { 'I', '1', 'l', 'o', 'O', '0' };
            string result = PasswordGenerator(20, 63, 3, 4, 5);
            bool similar = false;
            for(int i = 0; i < result.Length; i++)
            {
                for(int j = 0; j < arrayOfSimilarChars.Length; j++)
                {
                    if (result[i] == arrayOfSimilarChars[j]) similar = true;
                }
            }
            Assert.AreEqual(false, similar);
        }

        [TestMethod]
        public void WithoutAmbiguousTest()
        {
            char[] ambiguousChars = new char[] { '{', '}', '[', ']', '(', ')', '/', '\\', '\'', '~', '"', ',', ';', '.', '<', '>' };
            string result = PasswordGenerator(20, 54, 3, 4, 5);
            bool ambiguous = false;
            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < ambiguousChars.Length; j++)
                {
                    if (result[i] == ambiguousChars[j]) ambiguous = true;
                }
            }
            Assert.AreEqual(false, ambiguous);
        }

        [Flags]
        enum Conditions
        {
            None = 0,
            LowerCase = 1,
            UpperCase = 2,
            Digits = 4,
            Symbols = 8,
            WithoutSimilarities = 16,
            WithoutAmbiguousChars = 32
        }
         string PasswordGenerator(int numberOfDigits, int chosenConditions, int neededUpperCaseChars, int neededDigitChars, int neededSymbolsChars)
        {
            string rest = "";
            if (neededUpperCaseChars + neededDigitChars + neededSymbolsChars > numberOfDigits) return "Password needs more digits or select fewer condition digits";
            string password = "";
            Random rand = new Random();
            if ((chosenConditions & (byte)Conditions.UpperCase) == (byte)Conditions.UpperCase)
                LowerCaseUpperCaseAndDigits(numberOfDigits, neededUpperCaseChars, 'A', 26, ref password, rand);
            else Rest('A', 26, ref rest);
            if ((chosenConditions & (byte)Conditions.Digits) == (byte)Conditions.Digits)
                LowerCaseUpperCaseAndDigits(numberOfDigits, neededDigitChars, '0', 9, ref password, rand);
            else Rest('0', 9, ref rest);
            Symbols(numberOfDigits, chosenConditions, neededSymbolsChars, ref password, rand, ref rest);
            int neededLowerCaseChars = numberOfDigits - password.Length;
            if ((chosenConditions & (byte)Conditions.LowerCase) == (byte)Conditions.LowerCase)
                LowerCaseUpperCaseAndDigits(numberOfDigits, neededLowerCaseChars, 'a', 26, ref password, rand);
            GenerateRemainderOfPassword(numberOfDigits, ref password, rand, ref rest);
            WithoutSimilarities(chosenConditions, ref password, rand);
            WithoutAmbiguousChars(chosenConditions, ref password, rand, ref rest);
            char[] passArray = RandomizePassword(numberOfDigits, password, rand);
            return new string(passArray);
        }

        private static char[] RandomizePassword(int numberOfDigits, string password, Random rand)
        {
            int i = numberOfDigits;
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

        private static void WithoutAmbiguousChars(int chosenConditions,ref string password, Random rand,ref string rest)
        {
            if ((chosenConditions & (byte)Conditions.WithoutAmbiguousChars) == (byte)Conditions.WithoutAmbiguousChars)
            {
                char[] symbolsArrayWithoutAmbiguous = new char[] { '#', '$', '%', '^', '&', '*', '?', '!', '+','-' };
                char[] ambiguousChars = new char[] { '{', '}', '[', ']', '(', ')', '/', '\\', '\'', '~', '"', ',', ';', '.', '<', '>' };                
                bool similar = false;
                do
                {
                    similar = false;
                    for (int i = 0; i < password.Length; i++)
                    {
                        for (int j = 0; j < ambiguousChars.Length; j++)
                        {
                            if (password[i] == ambiguousChars[j])
                            {
                                similar = true;
                                password=password.Replace(password[i],symbolsArrayWithoutAmbiguous[rand.Next(0, symbolsArrayWithoutAmbiguous.Length - 1)]);
                            }
                        }
                    }
                }
                while (similar == true);
            }
        }

        private static void WithoutSimilarities(int chosenConditions,ref string password, Random rand)
        {
            if ((chosenConditions & (byte)Conditions.WithoutSimilarities) == (byte)Conditions.WithoutSimilarities)
            {
                var arrayOfSimilarChars = new char[] { 'I', '1', 'l', 'o', 'O', '0' };
                bool similar = false;
                do
                {
                    similar = false;
                    for (int i = 0; i < password.Length; i++)
                    {
                        for (int j = 0; j < arrayOfSimilarChars.Length; j++)
                        {
                            if (password[i] == arrayOfSimilarChars[j])
                            {
                                similar = true;
                                if (password[i] >= 'a' && password[i] <= 'z')
                                    password=password.Replace(password[i], (char)('a' + rand.Next(0, 26)));
                                else if (password[i] >= 'A' && password[i] <= 'Z')
                                    password=password.Replace(password[i], (char)('A' + rand.Next(0, 26)));
                                else if (password[i] >= '0' && password[i] <= '9')
                                    password=password.Replace(password[i], (char)('0'+ rand.Next(0, 9)));                               
                            }
                        }
                    }
                }
                while (similar == true);
            }
        }
                                                                            
        private static void GenerateRemainderOfPassword(int numberOfDigits,ref string password, Random rand,ref string rest)
        {
            int neededRemainingChars = numberOfDigits - password.Length;      
            for (int i = 0; i < neededRemainingChars; i++)
            {
                password += rest[rand.Next(0, rest.Length - 1)];
            }
        }

        private static void Symbols(int numberOfDigits, int chosenConditions, int neededSymbolsChars,ref string password, Random rand,ref string rest)
        {
            var symbolsArray = new char[] { '#', '$', '%', '^', '&', '*', '?', '!', '+', '-', '{', '}', '[', ']', '(', ')', '/', '\\', '\'', '~', '"', ',', ';', '.', '<', '>' };
            if ((chosenConditions & (byte)Conditions.Symbols) == (byte)Conditions.Symbols)
            {
                for (int i = 0; i < neededSymbolsChars; i++)
                {
                    int k = rand.Next(0, symbolsArray.Length - 1);
                    password += symbolsArray[k];

                }
            }
            else
                rest += String.Join("", symbolsArray);
        }

        public static void LowerCaseUpperCaseAndDigits(int numberOfDigits,int neededChars,char firstChar,int range,ref string password,Random rand)
        {
            for (int i = 0; i < neededChars; i++)
                password += (char)(firstChar + rand.Next(0, range));
        }

        public static void Rest(char firstChar, int range,ref string rest)
        {
            for (int i = 0; i < range; i++)
            {
                rest += (char)('A' + i);
            }
        }
    }
  }
  
