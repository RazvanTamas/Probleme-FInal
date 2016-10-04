using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Panagram
{
    [TestClass]
    public class PanagramTest
    {
        [TestMethod]
        public void TestParagramCorrect()
        {
            Assert.AreEqual( true,IsPangram("The quick brown fox jumps over the LAZY dog brown"));
        }
        private static bool IsPangram(string sentence)
        {
            string sentenceLowercase = sentence.ToLower();         
            bool containsLetter = true;
            for (char i = 'a'; i <= 'z'; i++)
            {
                if (!sentenceLowercase.Contains(Convert.ToString(i)))
                {
                   containsLetter = false;
                    break;
                }
            }
            return containsLetter;
        }

        
            
        
    }
}
