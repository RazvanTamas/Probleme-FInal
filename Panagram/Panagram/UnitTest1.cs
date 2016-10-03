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
            string[] alphabet = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            bool containsLetter = true;
            for (int i = 0; i < alphabet.Length; i++)
            {
                if (!sentenceLowercase.Contains(alphabet[i]))
                {
                   containsLetter = false;
                }
            }
            return containsLetter;
        }

        
            
        
    }
}
