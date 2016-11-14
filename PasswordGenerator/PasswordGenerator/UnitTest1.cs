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
            var options = new PasswordOptions("UpperCase", 5);
            var result = PasswordGenerator(8, options);
            int numberOfUpperCaseChars = 0;
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] >= 'A' && result[i] <= 'Z') numberOfUpperCaseChars++;
            }
            Assert.AreEqual(5,numberOfUpperCaseChars);
        }
       
        string PasswordGenerator(int passwordLength,PasswordOptions options)
        {
            Random rand = new Random();
            string password = string.Empty; 
            if (options.option == "UpperCase")
            {
                for (int i=0;i<options.numberOfChars;i++) password += (char)('A' + rand.Next(0, 26));
            }          
            return password;   
        }
    }  

}
