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
            string result = PasswordGenerator(20, 63, 4, 4, 4);
            Assert.AreEqual("NOT", result);
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
            UpperCases(numberOfDigits, chosenConditions, neededUpperCaseChars,ref password, rand,ref rest);
            Digits(numberOfDigits, chosenConditions, neededDigitChars,ref password, rand,ref rest);
            Symbols(numberOfDigits, chosenConditions, neededSymbolsChars,ref password, rand,ref rest);
            Lowercase(numberOfDigits, chosenConditions,ref password, rand,ref rest);
            GenerateRemainderOfPassword(numberOfDigits,ref password, rand,ref rest);
            WithoutSimilarities(chosenConditions,ref password, rand);
            WithoutAmbiguousChars(chosenConditions,ref password, rand,ref rest);
            string randomPassword = string.Empty;
            int i = numberOfDigits;
            char[] passArray = password.ToCharArray();
            while (i > 1)
            {
                i--;
                int k=rand.Next(0, i - 1);
                char switchVariable = passArray[k];
                passArray[k] = passArray[i];
                passArray[i] = switchVariable;
            }
            return new string(passArray);
        }

        private static void WithoutAmbiguousChars(int chosenConditions,ref string password, Random rand,ref string rest)
        {
            if ((chosenConditions & (byte)Conditions.WithoutAmbiguousChars) == (byte)Conditions.WithoutAmbiguousChars)
            {
                char[] symbolsArray = new char[] { '#', '$', '%', '^', '&', '*', '?', '!', '+','-' };
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
                                password=password.Replace(password[i],symbolsArray[rand.Next(0, symbolsArray.Length - 1)]);
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
            var symbolsArray = new char[] { '#', '$', '%', '^', '&', '*', '!', '?', '!', '"', '\'', '+', ',', '.', '/', '-', '(', ')' };
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

        private static void Digits(int numberOfDigits, int chosenConditions, int neededDigitChars,ref string passwordArray, Random rand,ref string rest)               
        {
            if ((chosenConditions & (byte)Conditions.Digits) == (byte)Conditions.Digits)
            {
                for (int i = 0; i < neededDigitChars; i++)
                {
                    passwordArray += (char)('0' + rand.Next(0, 9));
                }
            }
            else
                for (int i = 0; i < 9; i++)
                {
                    rest += (char)('0' + i);
                }

        }
        
    

        public static void Lowercase(int numberOfDigits, int chosenConditions,ref string passwordArray, Random rand,ref string rest)
        {
            int neededLowerCaseChars = numberOfDigits - passwordArray.Length;
            if ((chosenConditions & (byte)Conditions.LowerCase) == (byte)Conditions.LowerCase)
            {
                for (int i = 0; i < neededLowerCaseChars; i++)
                    passwordArray += (char)('a' + rand.Next(0, 26));
            }
            else 
                for(int i = 0; i < 26; i++)
                {
                    rest += (char)('a' + i);
                }
        }

        private void UpperCases(int numberOfDigits, int chosenConditions, int neededUpperCaseChars,ref string passwordArray, Random rand,ref string rest)
        {
            if ((chosenConditions & (byte)Conditions.UpperCase) == (byte)Conditions.UpperCase)
            {
                for (int i = 0; i < neededUpperCaseChars; i++)
                {
                    passwordArray += (char)('A' + rand.Next(0, 26));
                }
            }
            else
                for (int i = 0; i < 26; i++)
                {
                    rest += (char)('A' + i);
                }
                                  
        }
    }
  }
  
