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
            CollectionAssert.IsSubsetOf(new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' }, CalculateIfParagram("the quick brown fox jumps over the lazy dog brown"));
        }
        char[] CalculateIfParagram(string sentence)
        {
            char[] SentenceChars = sentence.ToCharArray();
            return SentenceChars;
        }
    }
}
