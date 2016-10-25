using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PasswordGenerator
{
    [TestClass]
    public class PasswordGeneratorTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual("password", PasswordGenerator(8, 3));
        }
        [Flags]
        enum Conditions 
        {
            LowerCase = 1, 
            UpperCase = 2,
            Digits =4,
            Symbols  =8,
            WithoutSimilarities = 16,
            WithoutAmbiguousChars = 32
        }

        string PasswordGenerator(int x,byte condition)
        {
            Random rand = new Random();
            char[] passwordArray = new char[x];
            string password = string.Empty;
            RandomPasswordGenerator(x, rand, passwordArray);
            LowerCase(x, condition, rand, passwordArray);
            UpperCase(x, condition, rand, passwordArray);
            Digits(x, condition, rand, passwordArray);
            Symbols(x, condition, rand, passwordArray);
            WithoutSimilarities(x, condition, rand, passwordArray);
            WithoutAmbiguousChars(x, condition, rand, passwordArray);
            for (int i = 0; i < x; i++) password += passwordArray[i];
            return password;
        }

        private void WithoutAmbiguousChars(int x, byte condition, Random rand, char[] passwordArray)
        {
            if ((condition & (byte)Conditions.WithoutAmbiguousChars) == (byte)Conditions.WithoutAmbiguousChars)
            {
                char[] ambiguousArray = new char[] { '{', '}', '[', ']', '(', ')', '/', '\\', '\'', '~', '"', ',', ';', '.', '<', '>' };
                while (WithCommonChars(passwordArray, ambiguousArray, x)) ;
                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < ambiguousArray.Length; i++)
                    {
                        passwordArray[i] = (passwordArray[i] == ambiguousArray[j]) ? (char)(rand.Next(33, 126)) : passwordArray[i];
                    }
                }
            }
        }

        private void WithoutSimilarities(int x, byte condition, Random rand, char[] passwordArray)
        {
            if ((condition & (byte)Conditions.WithoutSimilarities) == (byte)Conditions.WithoutSimilarities)
            {
                char[] similaritiesArray = new char[] { 'l', '1', 'I', 'o', 'O', '0' };
                while (WithCommonChars(passwordArray, similaritiesArray, x)) ;
                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < similaritiesArray.Length; i++)
                    {
                        passwordArray[i] = (passwordArray[i] == similaritiesArray[j]) ? (char)(rand.Next(33, 126)) : passwordArray[i];
                    }
                }
            }
        }

        private static void Symbols(int x, byte condition, Random rand, char[] passwordArray)
        {
            if ((condition & (byte)Conditions.Symbols) == (byte)Conditions.Symbols)
            {
                int neededNumbers = 1;
                char[] symbolsArray = new char[] { '`', '~', '!', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '=', '+', '{', '[', '}', ']', ';', ':', '"', ',', '<', '>', '.', '/', '?', '|' };
                for (int i = 0; i < neededNumbers; i++)
                {
                    int j = rand.Next(0, x - 1);
                    int k = rand.Next(0, 28);
                    passwordArray[j] = symbolsArray[k];
                }
            }
        }

        private static void Digits(int x, byte condition, Random rand, char[] passwordArray)
        {
            if ((condition & (byte)Conditions.Digits) == (byte)Conditions.Digits)
            {
                int neededNumbers = 2;
                for (int i = 0; i < neededNumbers; i++)
                {
                    int j = rand.Next(0, x - 1);
                    if (passwordArray[j] > '0' && passwordArray[j] < '9') i--;
                    else passwordArray[j] = (char)('0' + rand.Next(0, 9));
                }
            }
        }

        private static void UpperCase(int x, byte condition, Random rand, char[] passwordArray)
        {
            if ((condition & (byte)Conditions.UpperCase) == (byte)Conditions.UpperCase)
            {
                int neededNumbers = 3;
                for (int i = 0; i < neededNumbers; i++)
                {
                    int newCharacter = rand.Next(0, 26);
                    int j = rand.Next(0, x - 1);
                    if ((passwordArray[j] > 'A') && (passwordArray[j] < 'Z')) i--;
                    else passwordArray[j] = (char)('A' + newCharacter);
                }
            }
        }

        private static void LowerCase(int x, byte condition, Random rand, char[] passwordArray)
        {
            if ((condition & (byte)Conditions.LowerCase) == (byte)Conditions.LowerCase)
            {
                int neededNumbers = x;
                for (int i = 0; i < neededNumbers; i++)
                {
                    int newCharacter = rand.Next(0, 26);
                    passwordArray[i] = (char)('a' + newCharacter);
                }
            }
        }

        private static void RandomPasswordGenerator(int x, Random rand, char[] passwordArray)
        {
            for (int i = 0; i < x; i++)
            {
                passwordArray[i] = (char)(rand.Next(33, 126));
            }
        }

        bool WithCommonChars(char[] passwordArray,char[] similarArray,int x)
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < similarArray.Length; i++)
                {
                    return (passwordArray[i] == similarArray[j]);
                }
            }
            return false;
        }
    }  

}
