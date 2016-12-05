using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MovesForHanoiTowers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestForHanoiTowers()
        {
            Assert.AreEqual("1AB 2AC 1BC 3AB 1CA 2CB 1AB 4AC 1BC 2BA 1CA 3BC 1AB 2AC 1BC", ShowMovesForHanoiTowers(4));
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
                moves += numberOfDisks;             
                moves += sourceDisk;
                moves += destinationDisk;
                moves += " ";
                GenerateMoves(numberOfDisks - 1, helperDisk, sourceDisk, destinationDisk,ref moves);
            }

        }
    }
}
