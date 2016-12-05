using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MovesForHanoiTowers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestForTwoTowers()
        {
            Assert.AreEqual("AB AC BC AB CA CB AB AC BC BA CA BC AB AC BC", ShowMovesForHanoiTowers(4));
        }
        string ShowMovesForHanoiTowers(int numberOfDisks)
        {
            string moves = string.Empty;
            GenerateMoves(numberOfDisks, 'A', 'B', 'C',ref moves);
            string movesWithoutSpaceAtTheEnd = moves.Substring(0, moves.Length - 1);
            return movesWithoutSpaceAtTheEnd;
        }
        public void GenerateMoves(int numberOfDisks,char sourceDisk,char helperDisk,char destinationDisk,ref string moves)
        {
            if (numberOfDisks > 0)
            {
                GenerateMoves(numberOfDisks - 1, sourceDisk, destinationDisk, helperDisk,ref moves);              
                moves += sourceDisk;
                moves += destinationDisk;
                moves += " ";
                GenerateMoves(numberOfDisks - 1, helperDisk, sourceDisk, destinationDisk,ref moves);
            }

        }
    }
}
