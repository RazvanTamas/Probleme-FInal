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
        public void TestUpperCaseChars()
        {
            var options = new PasswordOptions[] { new PasswordOptions("UpperCase", 5) };
            var result = PasswordGenerator(8, options);
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
            var result = PasswordGenerator(8, options);
            int numberOfDigitChars = 0;
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] >= '0' && result[i] <= '9') numberOfDigitChars++;
            }
            Assert.AreEqual(5, numberOfDigitChars);
        }
       
        string PasswordGenerator(int passwordLength,PasswordOptions[] options)
        {
            Random rand = new Random();
            string password = string.Empty;
            string rest = string.Empty;
            for (int i = 0; i < options.Length; i++)
            {
                if (options[i].option == "UpperCase" && options[i].numberOfChars > 0)
                    GenerateUpperCaseLowerCaseAndDigitChars(ref password, options[i].numberOfChars, 'A', 26, rand);
                else if (options[i].option == "UpperCase" && options[i].numberOfChars == 0)
                    GenerateRest(ref rest, 'A', 26, rand);
                else if (options[i].option == "Digits" && options[i].numberOfChars > 0)
                    GenerateUpperCaseLowerCaseAndDigitChars(ref password, options[i].numberOfChars, '0', 9, rand);
                else if (options[i].option == "Digits" && options[i].numberOfChars == 0)
                    GenerateRest(ref rest, '0', 9, rand);
            }
               
            return password;   
        }
        public void GenerateUpperCaseLowerCaseAndDigitChars(ref string password,int neededChars,char firstChar,int range,Random rand)
        {
            for (int i = 0; i < neededChars; i++)
            {
                password += (char)(firstChar + rand.Next(0, range));
            }
        }
        public void GenerateRest(ref string rest, char firstChar, int range, Random rand)
        {
            for (int i = 0; i < range; i++)
            {
                rest += (char)(firstChar + i);
            }
        }
    }  

}
