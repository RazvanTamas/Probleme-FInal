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
            Simbols  =8,
            WithoutSimilarities = 16,
            WithoutAmbiguousChars = 32
        }

        string PasswordGenerator(int x,byte condition)
        {
            Conditions lowerCase = Conditions.LowerCase;
            Conditions upperCase = Conditions.UpperCase;
            Conditions digits = Conditions.Digits;
            Conditions symbols = Conditions.Simbols;
            Conditions withoutSimilarities = Conditions.WithoutSimilarities;
            Conditions withoutAmbiguousChars = Conditions.WithoutAmbiguousChars;             
            Random rand = new Random();
            char[] passwordArray = new char[x];
            string password = string.Empty;
            for (int i = 0; i < x; i++)
            {
                passwordArray[i] = (char)(rand.Next(33, 126));
            }                 
            if ((condition & (byte)lowerCase) == (byte)lowerCase)
            {
                int neededNumbers = x;
                for (int i = 0; i <neededNumbers; i++)
                {
                    int newCharacter = rand.Next(0, 26);
                    passwordArray[i] = (char)('a'+newCharacter);  
                }
            }
            if ((condition & (byte)upperCase) == (byte)upperCase)
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
            if ((condition & (byte)digits) == (byte)digits)
            {
                int neededNumbers = 2;
                for (int i = 0; i < neededNumbers; i++)
                {                  
                    int j = rand.Next(0, x - 1);
                    if (passwordArray[j] > '0' && passwordArray[j] < '9') i--;                             
                    else passwordArray[j]=(char)('0'+rand.Next(0,9));
                }
            }
            if ((condition & (byte)symbols) == (byte)symbols) 
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
            if ((condition & (byte)withoutSimilarities ) == (byte)withoutSimilarities)
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
            if ((condition & (byte)withoutAmbiguousChars) == (byte)withoutAmbiguousChars)
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
            for (int i = 0; i < x; i++) password += passwordArray[i];                  
            return password;

            // litere mici 
            //litere mari și numărul lor
            //cifre și numărul lor
            //simboluri și numărul lor
            //să nu includă caracterele similare: l, 1, I, o, 0, O
            //să nu includă caractere ambigue: {}
            //[]()/\'"~,;.<>

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
