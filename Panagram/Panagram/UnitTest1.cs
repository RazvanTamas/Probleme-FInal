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
            CollectionAssert.IsSubsetOf(new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' }, CalculateIfParagram("The quick brown fox jumps over the LAZY dog brown"));
        }
        char[] CalculateIfParagram(string sentence)
        {
            char[] sentenceChars = sentence.ToCharArray();
            LowerCaseLetters(sentenceChars);
            return sentenceChars;
        }

        private static void LowerCaseLetters(char[] sentenceChars)
        {
            for (int i = 0; i < sentenceChars.Length; i++)
            {
                char letter = sentenceChars[i];
                if (char.IsUpper(letter))
                    sentenceChars[i] = char.ToLower(letter);
            }
        }
    }
}
