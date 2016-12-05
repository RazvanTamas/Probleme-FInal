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
            Assert.AreEqual("AB AC BC ", ShowMovesForHanoiTowers(2));
        }
        string ShowMovesForHanoiTowers(int numberOfDisks)
        {
            string moves = string.Empty;
            MovesForTwoTowers(numberOfDisks, 'A', 'B', 'C',ref moves);
            return moves;
        }
        public void MovesForTwoTowers(int numberOfDisks,char sourceDisk,char helperDisk,char destinationDisk,ref string moves)
        {
            if (numberOfDisks > 0)
            {
                MovesForTwoTowers(numberOfDisks - 1, sourceDisk, destinationDisk, helperDisk,ref moves);              
                moves += sourceDisk;
                moves += destinationDisk;
                moves += " ";
                MovesForTwoTowers(numberOfDisks - 1, helperDisk, sourceDisk, destinationDisk,ref moves);
            }

        }
    }
}
