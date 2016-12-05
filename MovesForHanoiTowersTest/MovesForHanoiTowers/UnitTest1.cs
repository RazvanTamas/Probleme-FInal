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
            Assert.AreEqual("AB AC BC", ShowMovesForHanoiTowers(2));
        }
        string ShowMovesForHanoiTowers(int numberOfDisks)
        {
            string moves = string.Empty;
            MovesForTwoDisks(numberOfDisks, 'A', 'B', 'C',ref moves);
            string movesWithoutSpaceAtTheEnd = moves.Substring(0, moves.Length - 1);
            return movesWithoutSpaceAtTheEnd;
        }
        public void MovesForTwoDisks(int numberOfDisks,char sourceDisk,char helperDisk,char destinationDisk,ref string moves)
        {
            if (numberOfDisks > 0)
            {
                MovesForTwoDisks(numberOfDisks - 1, sourceDisk, destinationDisk, helperDisk,ref moves);              
                moves += sourceDisk;
                moves += destinationDisk;
                moves += " ";
                MovesForTwoDisks(numberOfDisks - 1, helperDisk, sourceDisk, destinationDisk,ref moves);
            }

        }
    }
}
