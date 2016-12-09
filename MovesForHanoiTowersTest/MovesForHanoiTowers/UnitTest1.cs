using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace MovesForHanoiTowers
{

    [TestClass]
    public class UnitTest1
    {
        public static string moves = string.Empty;     
        [TestMethod]
        public void TestForHanoiTowers()
        {
           Assert.AreEqual("1AB 2AC 1BC 3AB 1CA 2CB 1AB 4AC 1BC 2BA 1CA 3BC 1AB 2AC 1BC", ShowMovesForHanoiTowers(4));
        }
        public string ShowMovesForHanoiTowers(int numberOfDisks)
        {
            string moves = string.Empty;          
            moves += GenerateMoves(numberOfDisks, 'A', 'B', 'C');
            moves = moves.Substring(0, moves.Length - 1);
            return moves;
        }
        string GenerateMoves(int numberOfDisks, char sourceDisk, char helperDisk, char destinationDisk)
        {          
            if (numberOfDisks > 0)
            {                
                GenerateMoves(numberOfDisks - 1, sourceDisk, destinationDisk, helperDisk);
                moves += numberOfDisks;
                moves += sourceDisk;
                moves += destinationDisk;
                moves += " ";            
                GenerateMoves(numberOfDisks - 1, helperDisk, sourceDisk, destinationDisk);
                return moves;
            }
            return moves;
                          
        }
    }
}
