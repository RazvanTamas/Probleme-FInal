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
            Assert.AreEqual("aaaaaaaa", PasswordGenerator(8, 5, 2, 2, 2));
        }
        [Flags]
        enum Conditions
        {
            LowerCase = 1,
            UpperCase = 2,
            Digits = 4,
            Symbols = 8,
            WithoutSimilarities = 16,
            WithoutAmbiguousChars = 32
        }
        string PasswordGenerator(int numberOfDigits, int chosenConditions, int neededUpperCaseChars, int neededDigitChars, int neededSymbolsChars)
        {
            if (neededUpperCaseChars + neededDigitChars + neededSymbolsChars > numberOfDigits) return "Password needs more digits or select fewer condition digits";
            var passwordArray = new char[numberOfDigits];
            for (int i = 0; i < passwordArray.Length; i++) passwordArray[i] = '\0';
            string password = string.Empty;
            Random rand = new Random();
            Lowercase(numberOfDigits, chosenConditions, passwordArray, rand);
            UpperCase(numberOfDigits, chosenConditions, neededUpperCaseChars, passwordArray, rand);
            Digits(numberOfDigits, chosenConditions, neededDigitChars, passwordArray, rand);
            Symbols(numberOfDigits, chosenConditions, neededSymbolsChars, passwordArray, rand);
            GenerateRemainderOfPassword(numberOfDigits, passwordArray, rand);
            WithoutSimilarities(numberOfDigits, chosenConditions, passwordArray, rand);
            WithoutAmbiguousChars(numberOfDigits, chosenConditions, passwordArray, rand);
            for (int i = 0; i < numberOfDigits; i++) password += passwordArray[i];
            return password;
        }

        private static void WithoutAmbiguousChars(int numberOfDigits, int chosenConditions, char[] passwordArray, Random rand)
        {
            if ((chosenConditions & (byte)Conditions.WithoutAmbiguousChars) == (byte)Conditions.WithoutAmbiguousChars)
            {
                char[] ambiguousChars = new char[] { '{', '}', '[', ']', '(', ')', '/', '\\', '\'', '~', '"', ',', ';', '.', '<', '>' };
                bool similar = false;
                do
                {
                    similar = false;
                    for (int i = 0; i < numberOfDigits; i++)
                    {
                        for (int j = 0; j < ambiguousChars.Length; j++)
                        {
                            if (passwordArray[i] == ambiguousChars[j])
                            {
                                similar = true;
                                passwordArray[i] = (char)rand.Next(32, 126);
                            }
                        }
                    }
                }
                while (similar == true);
            }
        }

        private static void WithoutSimilarities(int numberOfDigits, int chosenConditions, char[] passwordArray, Random rand)
        {
            if ((chosenConditions & (byte)Conditions.WithoutSimilarities) == (byte)Conditions.WithoutSimilarities)
            {
                var arrayOfSimilarChars = new char[] { 'I', '1', 'l', 'o', 'O', '0' };
                bool similar = false;
                do
                {
                    similar = false;
                    for (int i = 0; i < numberOfDigits; i++)
                    {
                        for (int j = 0; j < arrayOfSimilarChars.Length; j++)
                        {
                            if (passwordArray[i] == arrayOfSimilarChars[j])
                            {
                                similar = true;
                                passwordArray[i] = (char)rand.Next(32, 126);
                            }
                        }
                    }
                }
                while (similar == true);
            }
        }

        private static void GenerateRemainderOfPassword(int numberOfDigits, char[] passwordArray, Random rand)
        {
            for (int i = 0; i < numberOfDigits; i++)
            {
                if (passwordArray[i] == '\0') passwordArray[i] = (char)rand.Next(32, 126);
            }
        }

        private static void Symbols(int numberOfDigits, int chosenConditions, int neededSymbolsChars, char[] passwordArray, Random rand)
        {
            if ((chosenConditions & (byte)Conditions.Symbols) == (byte)Conditions.Symbols)
            {
                var symbolsArray = new char[] { '#', '$', '%', '^', '&', '*', '!', '?', '!', '"', '\'', '+', ',', '.', '/', '-', '(', ')' };
                for (int i = 0; i < neededSymbolsChars; i++)
                {
                    int k = rand.Next(0, symbolsArray.Length - 1);
                    int j = rand.Next(0, numberOfDigits - 1);
                    if (passwordArray[j] == '\0' || (passwordArray[j] >= 'a' && passwordArray[j] <= 'z')) passwordArray[j] = symbolsArray[k];
                    else i--;
                }
            }
        }

        private static void Digits(int numberOfDigits, int chosenConditions, int neededDigitChars, char[] passwordArray, Random rand)
        {
            if ((chosenConditions & (byte)Conditions.Digits) == (byte)Conditions.Digits)
            {
                for (int i = 0; i < neededDigitChars; i++)
                {
                    int j = rand.Next(0, numberOfDigits - 1);
                    if (passwordArray[j] == '\0' || (passwordArray[j] >= 'a' && passwordArray[j] <= 'z')) passwordArray[j] = (char)('0' + rand.Next(0, 9));
                    else i--;
                }
            }
        }

        private static void UpperCase(int numberOfDigits, int chosenConditions, int neededUpperCaseChars, char[] passwordArray, Random rand)
        {
            if ((chosenConditions & (byte)Conditions.UpperCase) == (byte)Conditions.UpperCase)
            {
                for (int i = 0; i < neededUpperCaseChars; i++)
                {
                    int j = rand.Next(0, numberOfDigits - 1);
                    if (passwordArray[j] == '\0' || (passwordArray[j] > 'a' && passwordArray[j] < 'z')) passwordArray[j] = (char)('A' + rand.Next(0, 26));
                    else i--;
                }

            }
        }

        private static void Lowercase(int numberOfDigits, int chosenConditions, char[] passwordArray, Random rand)
        {
            if ((chosenConditions & (byte)Conditions.LowerCase) == (byte)Conditions.LowerCase)
            {
                for (int i = 0; i < numberOfDigits; i++) passwordArray[i] = (char)('a' + rand.Next(0, 26));
            }
        }
    }
  }
  
